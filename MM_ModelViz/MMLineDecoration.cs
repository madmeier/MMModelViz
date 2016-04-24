using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml.Serialization;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Visio;
using Page = Microsoft.Office.Interop.Visio.Page;
using Shape = Microsoft.Office.Interop.Visio.Shape;

namespace MM_ModelViz
{
    public partial class MMLineDecoration : Form
    {

        private readonly object _missing = System.Reflection.Missing.Value;

        public MMLineDecoration()
        {
            InitializeComponent();
            selectedLogFileName.Text = MMTraceUtil.LogFileName("Map");

        }

        private void decorate_Click(object sender, EventArgs e)
        {

            // open log if not yet open
            var tr2 = new TextWriterTraceListener(File.CreateText(selectedLogFileName.Text));
            Trace.Listeners.Add(tr2);

            // do it with Excel ....
            // all the excel stuff
            var connectionList = new List<ShapeConnection>();


            // Excel related aspects

            var xlApp = new Microsoft.Office.Interop.Excel.Application {Visible = true};

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            // open the excel file
            String excelFileName = connectionsFileName.Text;
            Workbook xlWorkBook = xlApp.Workbooks.Open(excelFileName,
                                                       _missing, _missing, _missing, _missing, _missing, _missing,
                                                       _missing, _missing,
                                                       _missing, _missing, _missing, _missing, _missing, _missing);




            if (excelFileName != "" && File.Exists(excelFileName))
            {
                xlWorkBook = xlApp.Workbooks.Open(excelFileName,
                                                  _missing, _missing, _missing, _missing, _missing, _missing, _missing,
                                                  _missing,
                                                  _missing, _missing, _missing, _missing, _missing, _missing);

                var xlWorkSheet = (Worksheet) xlWorkBook.Sheets[connectionsSheetName.Text];


                int sourceElementNameCol = MmExcelUtil.ColumnNumber(xlWorkSheet, sourceElementColumnName.Text);
                int targetElementNameCol = MmExcelUtil.ColumnNumber(xlWorkSheet, targetElementColumnName.Text);

                Trace.WriteLine("  source element name column " + sourceElementNameCol);
                Trace.WriteLine("  target element name column " + targetElementNameCol);


                int row = 2;
                bool finished = false;

                while (!finished)
                {
                    String sourceElement = MmExcelUtil.GetCell(xlWorkSheet, row, sourceElementNameCol);
                    String targetElement = MmExcelUtil.GetCell(xlWorkSheet, row, targetElementNameCol);


                    finished = sourceElement == "" && targetElement == "";

                    if (!finished)
                    {
                        connectionList.Add(
                            new ShapeConnection(sourceElement, targetElement));
                    }
                    row++;
                }

                Trace.WriteLine("  connections read from Excel " + connectionList.Count);
            }

            // Visio related aspects

            var visapp = new Microsoft.Office.Interop.Visio.Application();



           Document landscape = visapp.Documents.Open(visioFileName.Text);
           Page page = visapp.ActivePage;

         
 
            Trace.WriteLine("Landscape Masters " + landscape.Masters.Count);
            foreach (Master m in landscape.Masters)
            {
                Trace.WriteLine("VisioStencil Master " + m.Name);
               
            }





            Master connectorMaster = landscape.Masters[connectorStencilName.Text];
           


           var placedMapShapes = new Dictionary<String, ShapeRef>();
           MmVisioUtil.GetShapeList(shapeName.Text, page, elementTagName.Text, placedMapShapes);


           Trace.WriteLine("  shapes in Visio " + placedMapShapes.Count);


           // filter internal flows
           for (int con = connectionList.Count - 1; con >= 1; con--)
           {
               if (connectionList[con].SourceElement == connectionList[con].TargetElement)
               {
                   connectionList.RemoveAt(con);
               }
           }
           Trace.WriteLine("  number of cross system connections  " + connectionList.Count);


           if (summarizeCheckBox.Checked)
           {
               connectionList.Sort((c1, c2) => String.CompareOrdinal(c1.ConnectionName(), c2.ConnectionName()));

               for (int con = connectionList.Count - 1; con >= 1; con--)
               {
                   if (connectionList[con - 1].ConnectionName() == connectionList[con].ConnectionName())
                   {
                       connectionList[con - 1].Weight = (connectionList[con].Weight + 1);
                       connectionList.RemoveAt(con);
                   }
                   else
                   {
                       Trace.WriteLine(connectionList[con].ConnectionName() + " " + connectionList[con].Weight);
                   }
               }

               Trace.WriteLine("  summarized to  " + connectionList.Count);
           }





           int progressValue = 0;
           decorationProgressBar.Minimum = 0;
           decorationProgressBar.Maximum = connectionList.Count - 1;

           // tweak performance
           bool pInhibitSelectChange = visapp.InhibitSelectChange;
           short pDeferRecalc = visapp.DeferRecalc;
           bool pShowChanges = visapp.ShowChanges;
           short pScreenUpdating = visapp.ScreenUpdating;
           int pOnDataChangeDelay = visapp.OnDataChangeDelay;

           visapp.InhibitSelectChange = true;
           visapp.DeferRecalc = 1;
           visapp.ShowChanges = false;
           visapp.ScreenUpdating = 0;
           visapp.OnDataChangeDelay = -2;


            foreach (ShapeConnection con in connectionList)
            {
                decorationProgressBar.Value = progressValue++;
                if (progressValue%50 == 0)
                {
                    Trace.Flush();
                }

                ShapeRef source = null;
                ShapeRef target = null;

                if (placedMapShapes.ContainsKey(con.SourceElement))
                {
                    source = placedMapShapes[con.SourceElement];

                }

                if (placedMapShapes.ContainsKey(con.TargetElement))
                {
                    target = placedMapShapes[con.TargetElement];

                }

                if (source != null && target != null)
                {
                    Shape connector = page.Drop(connectorMaster, 4.50, 4.50);
                    MmVisioUtil.ConnectShapes(source.Shape, target.Shape, connector);
                    // connector.Cells["EndArrow"].Formula = "=5";

                }
                else
                {
                    Trace.WriteLine(" cannot add connector between " + con.SourceElement + " to " + con.TargetElement);
                }

            }




            Trace.WriteLine("  decorations read from Excel " + connectionList.Count);

           // Reset Visio properties
           visapp.InhibitSelectChange = pInhibitSelectChange;
           visapp.DeferRecalc = pDeferRecalc;
           visapp.ShowChanges = pShowChanges;
           visapp.ScreenUpdating = pScreenUpdating;
           visapp.OnDataChangeDelay = pOnDataChangeDelay;



            Trace.Flush();
            Trace.Close();
        }


        private void VsdFileNameButtonClick(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Visio File|*.vsd";
            openFileDialog.Title = "Open Vision Map File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                visioFileName.Text = openFileDialog.FileName;
            }
        }

        private void ConnectionExcelFileNameButtonClick(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Excel old|*.xlsx|Excel New |*.xls";
            openFileDialog.Title = "Open Excel File with Map";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                connectionsFileName.Text = openFileDialog.FileName;
            }
        }

        private void saveConfigButton_Click(object sender, EventArgs e)
        {
            saveConfigFileDialog.Filter = "XML File|*.xml";
            saveConfigFileDialog.Title = "Save a Config File";
            saveConfigFileDialog.FileName = mapName.Text + "." + mapVersion.Text;

            if (saveConfigFileDialog.ShowDialog() == DialogResult.OK)
            {
                String configFileName = saveConfigFileDialog.FileName;

                var connectionsConfig = new ConnectionsConfig();

                connectionsConfig.Name = mapName.Text;
                connectionsConfig.Version = mapVersion.Text;
                connectionsConfig.VisioMapFile = visioFileName.Text;

                connectionsConfig.ExcelFile = connectionsFileName.Text;
                connectionsConfig.ConnectionsSheet = connectionsSheetName.Text;

                connectionsConfig.SourceElementColumnName = sourceElementColumnName.Text;
                connectionsConfig.TargetElementColumnName = targetElementColumnName.Text;

                connectionsConfig.ElementShapeName = shapeName.Text;
                connectionsConfig.ElementTagName = elementTagName.Text;

                connectionsConfig.ConnectorStencilName = connectorStencilName.Text;

                var serializer = new XmlSerializer(connectionsConfig.GetType());
                TextWriter textWriter = new StreamWriter(configFileName);
                serializer.Serialize(textWriter, connectionsConfig);
                textWriter.Close();

            }
        }

        private void LoadConfigButton_Click(object sender, EventArgs e)
        {
            openConfigFileDialog.Filter = "XML File|*.xml";
            openConfigFileDialog.Title = "Open a Config File";
            if (openConfigFileDialog.ShowDialog() == DialogResult.OK)
            {
                String configFileName = openConfigFileDialog.FileName;

                var deserializer = new XmlSerializer(typeof(ConnectionsConfig));
                TextReader textReader = new StreamReader(configFileName);
                var connectionsConfig = (ConnectionsConfig)deserializer.Deserialize(textReader);
                textReader.Close();

                mapName.Text = connectionsConfig.Name;
                mapVersion.Text = connectionsConfig.Version;
                visioFileName.Text = connectionsConfig.VisioMapFile;

                connectionsFileName.Text = connectionsConfig.ExcelFile;
                connectionsSheetName.Text = connectionsConfig.ConnectionsSheet;

                sourceElementColumnName.Text = connectionsConfig.SourceElementColumnName;
                targetElementColumnName.Text = connectionsConfig.TargetElementColumnName;

                shapeName.Text = connectionsConfig.ElementShapeName;
                elementTagName.Text = connectionsConfig.ElementTagName;

                connectorStencilName.Text = connectionsConfig.ConnectorStencilName;

            }
        }




        #region Nested type: ConnectionsConfig

        public class ConnectionsConfig
        {

            public String Name { get; set; }
            public String Version { get; set; }
            public String VisioMapFile { get; set; }
            public String ExcelFile { get; set; }

            public String ConnectionsSheet { get; set; }
            public String SourceElementColumnName { get; set; }
            public String TargetElementColumnName { get; set; }

            public String ElementShapeName { get; set; }
            public String ElementTagName { get; set; }

            public String ConnectorStencilName { get; set; }

        }

        #endregion

        private void visioFileName_TextChanged(object sender, EventArgs e)
        {
            MMTraceUtil.UpdateLogFileName(logAtFilePath, visioFileName, selectedLogFileName);

        }

        private void connectionsFileName_TextChanged(object sender, EventArgs e)
        {
            MMTraceUtil.UpdateLogFileName(logAtFilePath, visioFileName, selectedLogFileName);

        }




    }


}

