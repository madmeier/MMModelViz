using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Visio;
using Page = Microsoft.Office.Interop.Visio.Page;

namespace MM_ModelViz
{
    public partial class MMShapeDecoration : Form
    {

        private readonly object _missing = System.Reflection.Missing.Value;

        public MMShapeDecoration()
        {
            InitializeComponent();
            selectedLogFileName.Text = MMTraceUtil.LogFileName("Map");
        }



        private void DecorGenerateClick(object sender, EventArgs e)
        {
            // open log if not yet open
            var tr2 = new TextWriterTraceListener(File.CreateText(selectedLogFileName.Text));
            Trace.Listeners.Add(tr2);

            // Excel related aspects

            var xlApp = new Microsoft.Office.Interop.Excel.Application { Visible = true };

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            // open the excel file
            String excelFileName = decorExcelFileName.Text;
            Workbook xlWorkBook = xlApp.Workbooks.Open(excelFileName,
                                                       _missing, _missing, _missing, _missing, _missing, _missing, _missing, _missing,
                                                       _missing, _missing, _missing, _missing, _missing, _missing);


            String decorationsTagName = decorElementCoilumnName.Text;

            // reference column number --> tag for the elements
            var decorationColumnMap = new Dictionary<int, string>();
            int decorationMaxColumn;
            int decorationTagColumn;
            MmExcelUtil.BuildColumnMap(xlWorkBook, decorSheetName.Text, decorationsTagName, decorationColumnMap, out decorationMaxColumn, out decorationTagColumn);

            // list of all the constituents of the map
            var decorationsList = new List<GenericElement>();
            MmExcelUtil.BuildList(xlWorkBook, decorSheetName.Text, decorationTagColumn, decorationMaxColumn, decorationColumnMap, decorationsList, decorElementCoilumnName.Text);


            // Visio related aspects

            var visapp = new Microsoft.Office.Interop.Visio.Application();

            // Prepare Visio
            Document landscape = visapp.Documents.Open(decorVisioFileName.Text);
            Document stencil = visapp.Documents.OpenEx(decorStencilFileName.Text, (short)VisOpenSaveArgs.visOpenDocked);
            Page page = visapp.ActivePage;


            var placedElementShapes = new Dictionary<String, ShapeRef>();
            String elementStencilName = decorElementStencilName.Text;

            MmVisioUtil.GetShapeList(elementStencilName, page, decorationsTagName, placedElementShapes);

            int numUnplaceableDecorations = 0;
            int numPlaceableDecorations = 0;

            Trace.Flush();

            Master decorationStencil = stencil.Masters[decorStencilName.Text];

            foreach (GenericElement genericElement in decorationsList)
            {
                String key = genericElement.Name;

                if (placedElementShapes.ContainsKey(key))
                {
                    Trace.WriteLine("  Decorating " + key);

                    MmVisioUtil.PlaceDecorationElement(page, placedElementShapes[key].Shape, decorationStencil, genericElement,
                                           decorationColumnMap, false);

                    numPlaceableDecorations++;

                }
                else
                {
                    numUnplaceableDecorations++;
                }
            }
            Trace.WriteLine("  Decoration statistics " + numPlaceableDecorations + " placed and " + numUnplaceableDecorations + " ignored");



            Trace.Flush();
            Trace.Close();


        }

        private void DecorMapFileNameTextChanged(object sender, EventArgs e)
        {
            MMTraceUtil.UpdateLogFileName(logAtFilePath, decorExcelFileName, selectedLogFileName);

        }

        private void DecorStencilFileNameTextChanged(object sender, EventArgs e)
        {
            MMTraceUtil.UpdateLogFileName(logAtFilePath, decorStencilFileName, selectedLogFileName);

        }

        private void DecorVisioFileNameTextChanged(object sender, EventArgs e)
        {
            MMTraceUtil.UpdateLogFileName(logAtFilePath, decorVisioFileName, selectedLogFileName);
        }

 

        /// <summary>
        /// Adjust the log file directory to the directory used here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void SaveConfigButtonClick(object sender, EventArgs e)
        {
            saveConfigFileDialog.Filter = "XML File|*.xml";
            saveConfigFileDialog.Title = "Save a Config File";
            saveConfigFileDialog.FileName = mapName.Text + "." + mapVersion.Text;

            if (saveConfigFileDialog.ShowDialog() == DialogResult.OK)
            {
                String configFileName = saveConfigFileDialog.FileName;

                var matrixConfig = new DecorShapeConfig();

                matrixConfig.Name = mapName.Text;
                matrixConfig.Version = mapVersion.Text;
                matrixConfig.VisioMapFile = decorVisioFileName.Text;
                matrixConfig.VisioStencilFile = decorStencilFileName.Text;
                matrixConfig.ExcelFile = decorExcelFileName.Text;
                matrixConfig.DecorSheetName = decorSheetName.Text;
                matrixConfig.DecorStencilName = decorStencilName.Text;
                matrixConfig.DecorElementColumnName = decorElementCoilumnName.Text;
                matrixConfig.DecorationElementStencilName = decorElementStencilName.Text;

                var serializer = new XmlSerializer(matrixConfig.GetType());
                TextWriter textWriter = new StreamWriter(configFileName);
                serializer.Serialize(textWriter, matrixConfig);
                textWriter.Close();

            }
        }

        private void DecorFileNameSelectClick(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Excel old|*.xlsx|Excel New |*.xls";
            openFileDialog.Title = "Open Excel File with Decorations";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                decorExcelFileName.Text = openFileDialog.FileName;
            }
        }

        private void DecorStencilFileNameSelectClick(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Visio Stencil File|*.vss";
            openFileDialog.Title = "Open Visio Stencil File";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                decorStencilFileName.Text = openFileDialog.FileName;
            }

        }

        private void DecorMapFileNameSelectClick(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Visio File|*.vsd";
            openFileDialog.Title = "Open Vision Map File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                decorVisioFileName.Text = openFileDialog.FileName;
            }
        }

        private void LoadConfigButton_Click(object sender, EventArgs e)
        {
            openConfigFileDialog.Filter = "XML File|*.xml";
            openConfigFileDialog.Title = "Open a Config File";
            if (openConfigFileDialog.ShowDialog() == DialogResult.OK)
            {
                String configFileName = openConfigFileDialog.FileName;

                var deserializer = new XmlSerializer(typeof(DecorShapeConfig));
                TextReader textReader = new StreamReader(configFileName);
                var matrixConfig = (DecorShapeConfig)deserializer.Deserialize(textReader);
                textReader.Close();

                mapName.Text = matrixConfig.Name;
                mapVersion.Text = matrixConfig.Version;

                decorVisioFileName.Text = matrixConfig.VisioMapFile;
                decorStencilFileName.Text = matrixConfig.VisioStencilFile;
                decorExcelFileName.Text = matrixConfig.ExcelFile;
                decorSheetName.Text = matrixConfig.DecorSheetName;
                decorStencilName.Text = matrixConfig.DecorStencilName;
                decorElementCoilumnName.Text = matrixConfig.DecorElementColumnName;
                decorElementStencilName.Text = matrixConfig.DecorationElementStencilName;
            }

        }




    }



    #region Nested type: DecorShapeConfig

    public class DecorShapeConfig
    {

        public String Name { get; set; }
        public String Version { get; set; }
        public String VisioMapFile { get; set; }
        public String VisioStencilFile { get; set; }
        public String ExcelFile { get; set; }
        public String DecorSheetName { get; set; }
        public String DecorStencilName { get; set; }
        public String DecorElementColumnName { get; set; }
        public String DecorationElementStencilName { get; set; }


    }

    #endregion
}
