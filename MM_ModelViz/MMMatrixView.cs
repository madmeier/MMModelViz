using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Visio;
using Page = Microsoft.Office.Interop.Visio.Page;
using Shape = Microsoft.Office.Interop.Visio.Shape;

namespace MM_ModelViz
{
    public partial class MMMatrixView : Form
    {

        private readonly object _missing = System.Reflection.Missing.Value;

        public MMMatrixView()
        {
            InitializeComponent();
            selectedLogFileName.Text = MMTraceUtil.LogFileName("Matrix");

        }

        private void MmMatrixViewLoad(object sender, EventArgs e)
        {

        }


 



        private void MapItButtonClick(object sender, EventArgs e)
        {
            // open log if not yet open
            var tr2 = new TextWriterTraceListener(File.CreateText(selectedLogFileName.Text));
            Trace.Listeners.Add(tr2);

            // Excel related aspects

            var xlApp = new Microsoft.Office.Interop.Excel.Application { Visible = true };

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            // open the excel file
            String excelFileName = mapFileName.Text;
            Workbook xlWorkBook = xlApp.Workbooks.Open(excelFileName,
                                                       _missing, _missing, _missing, _missing, _missing, _missing, _missing, _missing,
                                                       _missing, _missing, _missing, _missing, _missing, _missing);


            // read the columns of the sheets containing the map and the elements


            // reference column number --> tag for the elements
            var elementColumnMap = new Dictionary<int, string>();
            int elementMaxColumnNr;
            int elementNameColumnNr;
            MmExcelUtil.BuildColumnMap(xlWorkBook, elementSheetName.Text, elementNameColumnName.Text , elementColumnMap, out elementMaxColumnNr, out elementNameColumnNr);


            // reference column number --> tag for the map
            var taxXColumnMap = new Dictionary<int, string>();
            int taxXMaxColumnNr;
            int taxXNameColumnNr;
            MmExcelUtil.BuildColumnMap(xlWorkBook, xTaxonomySheetName.Text, xTaxonomyNameColumnName.Text, taxXColumnMap, out taxXMaxColumnNr, out taxXNameColumnNr);

            // reference column number --> tag for the map
            var taxYColumnMap = new Dictionary<int, string>();
            int taxYMaxColumnNr;
            int taxYNameColumnNr;
            MmExcelUtil.BuildColumnMap(xlWorkBook, yTaxonomySheetName.Text, yTaxonomyNameColumnName.Text, taxYColumnMap, out taxYMaxColumnNr, out taxYNameColumnNr);

            // list of all the elements to be maped
            var elementList = new List<GenericElement>();
            MmExcelUtil.BuildList(xlWorkBook, elementSheetName.Text, elementNameColumnNr, elementMaxColumnNr, elementColumnMap, elementList, elementNameColumnName.Text);

            // list of all the constituents of the map
            var xTaxonomyList = new List<GenericElement>();
            MmExcelUtil.BuildList(xlWorkBook, xTaxonomySheetName.Text, taxXNameColumnNr, taxXMaxColumnNr, taxXColumnMap, xTaxonomyList, xTaxonomyNameColumnName.Text);

            // list of all the constituents of the map
            var yTaxonomyList = new List<GenericElement>();
            MmExcelUtil.BuildList(xlWorkBook, yTaxonomySheetName.Text, taxYNameColumnNr, taxYMaxColumnNr, taxYColumnMap, yTaxonomyList, yTaxonomyNameColumnName.Text);


            // xTaxonomyMapping
            var xTaxonomyMappingList = new List<Mapping>();
            MmExcelUtil.BuildMapping(xlWorkBook, xTaxonomyMappingList, xMapSheetName.Text, xMapElementNameColumnName.Text,
                                     xMapXTaxNameColumnName.Text);

            var yTaxonomyMappingList = new List<Mapping>();
            MmExcelUtil.BuildMapping(xlWorkBook, yTaxonomyMappingList, yMapSheetName.Text, yMapElementNameColumnName.Text,
                                     yMapYTaxNameColumnName.Text);

            // create the map

            int x = 0;
            int y = 0;
            var matrix = new List<String>[xTaxonomyList.Count, yTaxonomyList.Count];

            for (int xi = 0; xi < xTaxonomyList.Count(); xi ++)
            {
                for (int yi = 0; yi < yTaxonomyList.Count(); yi++)
                {
                    matrix[xi,yi] = new List<String>();
                }
            }


            foreach (GenericElement yElement in yTaxonomyList)
            {
                x = 0;
                foreach (GenericElement xElement in xTaxonomyList)
                {
                    Trace.WriteLine("  checking for x " + xElement.Name + " and y " + yElement.Name);


                    foreach (GenericElement element in elementList)
                    {
                        // if there is a mapping element to x and y taxonomy then add the element to the matrix

                        Mapping yMap = yTaxonomyMappingList.Find(
                            delegate(Mapping me)
                                {
                                    return
                                        me.ElementName == element.Name &&
                                        me.MapName == yElement.Name;
                                }
                            );
                        Mapping xMap = xTaxonomyMappingList.Find(
                            delegate(Mapping me)
                                {
                                    return
                                        me.ElementName == element.Name &&
                                        me.MapName == xElement.Name;
                                }
                            );

                        if (xMap != null && yMap != null)
                        {
                            matrix[x,y].Add(element.Name);
                        }

                    }
                    x += 1;
                }
                y += 1;
            }

            // determine per row the number of different applications and the max number in a cell

            int[] maxNumApplications = new int [yTaxonomyList.Count];
            int totalMaxNumApplications = 0;
            int[] diffNumApplications = new int[yTaxonomyList.Count];
            int totalDiffNumApplications = 0;
            int emptyRows = 0;

            for (int yi = 0; yi < yTaxonomyList.Count(); yi++)
            {
                maxNumApplications[yi] = 0;
                List<String> appNames = new List<string>();
                for (int xi = 0; xi < xTaxonomyList.Count(); xi++)
                {
                    maxNumApplications[yi] = Math.Max(maxNumApplications[yi], matrix[xi, yi].Count);
                    foreach (String s in matrix[xi, yi])
                    {
                        if (!appNames.Contains(s))
                        {
                            appNames.Add(s);
                        }
                    }
                }
                diffNumApplications[yi] = appNames.Count;
                totalDiffNumApplications += diffNumApplications[yi];
                totalMaxNumApplications += maxNumApplications[yi];
                if (maxNumApplications[yi] == 0)
                    emptyRows++;

                Trace.WriteLine(" Row " + yi + " max num application " + maxNumApplications[yi] + " diff num applications " + diffNumApplications[yi]);
            }

            Trace.WriteLine("Max total number applications " + totalMaxNumApplications);
            Trace.WriteLine("Total number of different applications " + totalDiffNumApplications);
            Trace.WriteLine("Number of empty rows " + emptyRows);

            // Visio related aspects

            var visapp = new Microsoft.Office.Interop.Visio.Application();

            // Prepare Visio
            Document landscape = visapp.Documents.Open(visioFileName.Text);
            Document stencil = visapp.Documents.OpenEx(stencilFileName.Text, (short)VisOpenSaveArgs.visOpenDocked);
            Page page = visapp.ActivePage;

            
            Master elementStencil = stencil.Masters[elementStencilName.Text];
            Master taxonomyXStencil = stencil.Masters[xTaxonomyStencilName.Text];
            Master taxomomyYStencil = stencil.Masters[yTaxonomyStencilName.Text];

            if (elementStencil == null) throw new ArgumentNullException("elementStencil");
            if (taxonomyXStencil == null) throw new ArgumentNullException("taxonomyXStencil");
            if (taxomomyYStencil == null) throw new ArgumentNullException("taxomomyYStencil");

            Shape elementShape = page.Drop(elementStencil, 0.0, 0.0);
            Shape taxonomyXShape = page.Drop(taxonomyXStencil, 0.0, 0.0);
            Shape taxonomyYShape = page.Drop(taxomomyYStencil, 0.0, 0.0);

            double pageWidth = page.PageSheet.CellsU["PageWidth"].ResultIU;
            double pageHight = page.PageSheet.CellsU["PageHeight"].ResultIU;

            double elementWidth = elementShape.CellsU["Width"].ResultIU;
            double elementHeight = elementShape.CellsU["Height"].ResultIU;

            double taxonomyXHeight = taxonomyXShape.CellsU["Height"].ResultIU;
            double taxonomyXWidth =  taxonomyXShape.CellsU["Width"].ResultIU;
            double taxonomyYHeight = taxonomyYShape.CellsU["Height"].ResultIU;
            double taxonomyYWidth = taxonomyYShape.CellsU["Width"].ResultIU;
        

            double space = double.Parse(spaceText.Text);

            elementShape.Delete();
            taxonomyXShape.Delete();
            taxonomyYShape.Delete();

            Trace.WriteLine("Size of an page    " + pageWidth + " " + pageHight);
            Trace.WriteLine("Size of an element " + elementWidth + " " + elementHeight);

            double yTaxonomyYRoot = pageHight - 2*space - taxonomyXHeight;
            double xTaxonomyXRoot = 2*space + taxonomyYWidth;

            double taxYHeight = 0.0;
            if (emptyRowSuppressionCheckBox.Checked)
            {
                taxYHeight = (yTaxonomyYRoot - 2 * space) / totalDiffNumApplications;
            }
            else
            {
                taxYHeight = (yTaxonomyYRoot - 2 * space) / (totalDiffNumApplications + emptyRows);                
            }
            double taxXWidth = (pageWidth - xTaxonomyXRoot - 2*space)/xTaxonomyList.Count;


            double yPos = yTaxonomyYRoot;
 

            for (int xi = 0; xi < xTaxonomyList.Count; xi ++)
            {
                MmVisioUtil.PlaceGenericElement(page, taxonomyXStencil, xTaxonomyList[xi],
                                                xTaxonomyXRoot + (xi + 0.5) * taxXWidth,
                                                yTaxonomyYRoot + taxonomyXHeight * 0.5,
                                                taxXWidth,
                                                taxonomyXHeight,
                                                taxXColumnMap,
                                                false);
            }



            for (int yi = 0; yi < yTaxonomyList.Count(); yi++)
            {
                double xPos = space*2.0 + taxonomyXWidth/2.0;

                if (emptyRowSuppressionCheckBox.Checked && diffNumApplications[yi] == 0)
                {
                    // do noting
                }
                else
                {
                    double height = Math.Max(1, diffNumApplications[yi])*taxYHeight;

                    MmVisioUtil.PlaceGenericElement(page, taxomomyYStencil, yTaxonomyList[yi],
                                                    xPos, yPos - height/2,
                                                    taxonomyYWidth, height,
                                                    taxYColumnMap,
                                                    false);

                    // draw applications

                    List<String> appNames = new List<string>();

                    for (int xi = 0; xi < xTaxonomyList.Count; xi++)
                    {
                        foreach (String s in matrix[xi, yi])
                        {
                            if (!appNames.Contains(s))
                            {
                                appNames.Add(s);
                            }
                        }
                    }

                    int nApp = 0;
                    foreach (String Name in appNames)
                    {
                        GenericElement app = elementList.Find(
                            delegate(GenericElement ele)
                                {
                                    return ele.Name == Name;
                                }
                            );

                        if (app != null)
                        {
                            elementShape = null;

                            for (int xi = 0; xi < xTaxonomyList.Count; xi++)
                            {
                                if (matrix[xi, yi].Contains(Name))
                                {
                                    if (mergeApplicationsCheckBox.Checked && elementShape != null)
                                    {
                                        elementShape.CellsU["Width"].ResultIU += taxXWidth;
                                        elementShape.CellsU["PinX"].ResultIU += taxXWidth/2;

                                    }
                                    else
                                    {
                                        if (applySpaceCheckBox.Checked)
                                        {
                                            elementShape = MmVisioUtil.PlaceGenericElement(page, elementStencil, app,
                                                                                           xTaxonomyXRoot +
                                                                                           (xi + 0.5)*(taxXWidth),
                                                                                           yPos -
                                                                                           (nApp + 0.5)*taxYHeight,
                                                                                           taxXWidth - space, taxYHeight,
                                                                                           elementColumnMap,
                                                                                           false);
                                        }
                                        else
                                        {
                                            elementShape = MmVisioUtil.PlaceGenericElement(page, elementStencil, app,
                                                                                           xTaxonomyXRoot +
                                                                                           (xi + 0.5)*taxXWidth,
                                                                                           yPos -
                                                                                           (nApp + 0.5)*taxYHeight,
                                                                                           taxXWidth, taxYHeight,
                                                                                           elementColumnMap,
                                                                                           false);
                                        }

                                    }
                                }
                                else
                                {
                                    elementShape = null;
                                }
                            }
                            nApp++;
                        }
                        else
                        {
                            String error = "### unknown element " + elementShape.Name;
                            Trace.WriteLine(error);
                            errorListBox.Items.Add(error);

                        }
                    }


                    yPos -= height;
                }

            }


            Trace.Flush();
            Trace.Close();

        }

        private void CreateMapExcelButtonClick(object sender, EventArgs e)
        {

        }

        private void OpenVisioFileButtonClick(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Visio File|*.vsd";
            openFileDialog.Title = "Open Vision Map File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                visioFileName.Text = openFileDialog.FileName;
            }
        }

        private void OpenMapFileButtonClick(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Excel old|*.xlsx|Excel New |*.xls";
            openFileDialog.Title = "Open Excel File with Map";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                mapFileName.Text = openFileDialog.FileName;
            }
        }

        private void visioStencilSelect_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Visio Stencil File|*.vss";
            openFileDialog.Title = "Open Visio Stencil File";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                stencilFileName.Text = openFileDialog.FileName;
            }
        }

        private void XyMapCheckedChanged(object sender, EventArgs e)
        {
            if (xyMap.Checked)
            {
                yMapSheetName.Hide();
                yMapElementNameColumnName.Hide();
            }
            else
            {
                yMapSheetName.Show();
                yMapElementNameColumnName.Show();
            }
        }

        private void SaveConfigButtonClick(object sender, EventArgs e)
        {
            saveConfigFileDialog.Filter = "XML File|*.xml";
            saveConfigFileDialog.Title = "Save a Config File";
            saveConfigFileDialog.FileName = mapName.Text + "." + mapVersion.Text;

            if (saveConfigFileDialog.ShowDialog() == DialogResult.OK)
            {
                String configFileName = saveConfigFileDialog.FileName;

                var matrixConfig = new MatrixConfig();

                matrixConfig.Name = mapName.Text;
                matrixConfig.Version = mapVersion.Text;
                matrixConfig.VisioMapFile = visioFileName.Text;
                matrixConfig.VisioStencilFile = stencilFileName.Text;
                matrixConfig.ExcelFile = mapFileName.Text;
                matrixConfig.ElementSheetName = elementSheetName.Text;
                matrixConfig.ElementStencilName = elementStencilName.Text;
                matrixConfig.ElementNameColumn = elementNameColumnName.Text;
                matrixConfig.XYMap = xyMap.Checked;
                matrixConfig.XTaxonomySheetName = xTaxonomySheetName.Text;
                matrixConfig.XTaxonomyStencilName = xTaxonomyStencilName.Text;
                matrixConfig.XTaxonomyNameColumn = xTaxonomyNameColumnName.Text;
                matrixConfig.YTaxonomySheetName = yTaxonomySheetName.Text;
                matrixConfig.YTaxonomyStencilName = yTaxonomyStencilName.Text;
                matrixConfig.YTaxonomyNameColumn = yTaxonomyNameColumnName.Text;
                matrixConfig.XMapSheetName = xMapSheetName.Text;
                matrixConfig.XMapElementNameColumn = xMapElementNameColumnName.Text;
                matrixConfig.XMapXTaxNameColumn = xMapXTaxNameColumnName.Text;
                matrixConfig.YMapSheetName = yMapSheetName.Text;
                matrixConfig.YMapElementNameColumn = yMapElementNameColumnName.Text;
                matrixConfig.YMapYTaxNameColumn = yMapYTaxNameColumnName.Text;
                matrixConfig.MapSpace = spaceText.Text;
                matrixConfig.SuppressEmptyRows = emptyRowSuppressionCheckBox.Checked;
                matrixConfig.MergeApplications = mergeApplicationsCheckBox.Checked;
                matrixConfig.ApplySpace = applySpaceCheckBox.Checked;

                var serializer = new XmlSerializer(matrixConfig.GetType());
                TextWriter textWriter = new StreamWriter(configFileName);
                serializer.Serialize(textWriter, matrixConfig);
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

                var deserializer = new XmlSerializer(typeof(MatrixConfig));
                TextReader textReader = new StreamReader(configFileName);
                var matrixConfig = (MatrixConfig)deserializer.Deserialize(textReader);
                textReader.Close();

                mapName.Text = matrixConfig.Name;
                mapVersion.Text = matrixConfig.Version;
                visioFileName.Text = matrixConfig.VisioMapFile;
                stencilFileName.Text = matrixConfig.VisioStencilFile;
                mapFileName.Text = matrixConfig.ExcelFile;
                elementSheetName.Text = matrixConfig.ElementSheetName;
                elementStencilName.Text= matrixConfig.ElementStencilName;
                elementNameColumnName.Text = matrixConfig.ElementNameColumn;
                xyMap.Checked = matrixConfig.XYMap;
                xTaxonomySheetName.Text= matrixConfig.XTaxonomySheetName;
                xTaxonomyStencilName.Text= matrixConfig.XTaxonomyStencilName;
                xTaxonomyNameColumnName.Text= matrixConfig.XTaxonomyNameColumn;
                yTaxonomySheetName.Text= matrixConfig.YTaxonomySheetName;
                yTaxonomyStencilName.Text= matrixConfig.YTaxonomyStencilName;
                yTaxonomyNameColumnName.Text= matrixConfig.YTaxonomyNameColumn;
                xMapSheetName.Text= matrixConfig.XMapSheetName;
                xMapElementNameColumnName.Text= matrixConfig.XMapElementNameColumn;
                xMapXTaxNameColumnName.Text= matrixConfig.XMapXTaxNameColumn;
                yMapSheetName.Text= matrixConfig.YMapSheetName;
                yMapElementNameColumnName.Text= matrixConfig.YMapElementNameColumn;
                yMapYTaxNameColumnName.Text= matrixConfig.YMapYTaxNameColumn;
                spaceText.Text = matrixConfig.MapSpace;
                emptyRowSuppressionCheckBox.Checked = matrixConfig.SuppressEmptyRows;
                mergeApplicationsCheckBox.Checked = matrixConfig.MergeApplications;
                applySpaceCheckBox.Checked = matrixConfig.ApplySpace;

            }
        }



        #region Nested type: MatrixConfig

        public class MatrixConfig
        {

            public String Name { get; set; }
            public String Version { get; set; }
            public String VisioMapFile { get; set; }
            public String VisioStencilFile { get; set; }
            public String ExcelFile { get; set; }
            public bool XYMap { get; set; }
            public String ElementSheetName { get; set; }
            public String ElementStencilName { get; set; }
            public String ElementNameColumn { get; set; }
            public String XTaxonomySheetName{ get; set; }
            public String XTaxonomyStencilName{ get; set; }
            public String XTaxonomyNameColumn { get; set; }
            public String YTaxonomySheetName { get; set; }
            public String YTaxonomyStencilName { get; set; }
            public String YTaxonomyNameColumn { get; set; }
            public String XMapSheetName  { get; set; }
            public String XMapElementNameColumn { get; set; }
            public String XMapXTaxNameColumn { get; set; }
            public String YMapSheetName { get; set; }
            public String YMapElementNameColumn { get; set; }
            public String YMapYTaxNameColumn { get; set; }
            public String MapSpace { get; set; }
            public Boolean SuppressEmptyRows { get; set; }
            public Boolean MergeApplications { get; set; }
            public Boolean ApplySpace { get; set; }

        }

        #endregion

        private void MapFileNameTextChanged(object sender, EventArgs e)
        {
            MMTraceUtil.UpdateLogFileName(logAtFilePath, mapFileName, selectedLogFileName);
        }

        private void VisioFileNameTextChanged(object sender, EventArgs e)
        {
            MMTraceUtil.UpdateLogFileName(logAtFilePath, visioFileName, selectedLogFileName);
        }









    }


}
