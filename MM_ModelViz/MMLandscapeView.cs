using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Visio;
using Page = Microsoft.Office.Interop.Visio.Page;
using Shape = Microsoft.Office.Interop.Visio.Shape;


namespace MM_ModelViz
{
    public partial class MmLandscapeView : Form
    {

        private readonly object _missing = System.Reflection.Missing.Value;

 



        public MmLandscapeView()
        {
            InitializeComponent();

            selectedLogFileName.Text = MMTraceUtil.LogFileName("Map");
        }




        /// <summary>
        /// Determines the shapes which are currently not placed on the diagram
        /// </summary>
        /// <param name="mapList"></param>
        /// <param name="mapShapes"></param>
        /// <param name="missingMapShapes"></param>
        private void DetermineMissingMapShapes(List<GenericElement> mapList, 
                                               Dictionary<String, ShapeRef> mapShapes, 
                                               List<String> missingMapShapes)
        {
            foreach (GenericElement e in mapList)
            {
                missingMapShapes.Add(e.Name);
            }

            foreach (String name in mapShapes.Keys)
            {
                 missingMapShapes.Remove(name.Replace("\"", ""));
            }

            Trace.WriteLine(missingMapShapes.Count + " map shapes not on map");
            foreach (String name in missingMapShapes)
            {
                Trace.WriteLine( " missing as map shape on map " + name);
            }
        }




 

        /// <summary>
        /// Combines the background elements in the mapList with the elements to be mappend
        /// in the elementList using the mappings in the mappingList.
        /// </summary>
        /// <param name="mapList"></param>
        /// <param name="elementList"></param>
        /// <param name="mappingList"></param>
        /// <param name="mapLayout"></param>
        private void PopulateMapLayout(List<GenericElement> mapList, 
                                       List<GenericElement> elementList, 
                                       List<Mapping> mappingList, 
                                       Dictionary<String, MapLayoutElement>mapLayout)
        {
            // create a dictionary between element names and their position in the element list
            var elementIndex = new Dictionary<String, int>();
            int elementPos = 0;
            foreach (GenericElement element in elementList)
            {
                if (!elementIndex.ContainsKey(element.Name))
                {

                    elementIndex.Add(element.Name, elementPos);
                    elementPos++;
                }
                else
                {
                    String error = "### Duplicate Name " + element.Name;
                    Trace.WriteLine(error);
                    errorListBox.Items.Add(error);
                }
            }

            
            int mapPos = 0;
            foreach (GenericElement mapElement in mapList)
            {
                var mapLayoutElement = new MapLayoutElement(mapElement.Name, mapPos);

                foreach (Mapping mapping in mappingList)
                {
                    if (mapping.MapName == mapElement.Name)
                    {
                        if (elementIndex.ContainsKey(mapping.ElementName))
                        {
                            mapLayoutElement.AddMappedElement(mapping.ElementName);
                        }
                        else
                        {
                            String error = "### Invalid mapping of element " + mapping.ElementName + " (not existing) to " + mapping.MapName;
                            Trace.WriteLine(error);
                            errorListBox.Items.Add(error);
                        }
                    }
                }

                if (!mapLayout.ContainsKey(mapElement.Name))
                {
                    mapLayout.Add(mapElement.Name, mapLayoutElement);
                }
                else
                {
                    String error = "### Duplicate mapping " + mapElement.Name + " to " + mapLayoutElement.Name;
                    Trace.WriteLine(error);
                    errorListBox.Items.Add(error);
                }
                mapPos++;
            }

            foreach (MapLayoutElement me in mapLayout.Values)
            {
                Trace.WriteLine("MapLayoutElement " + me.Name + " to be used for " + me.NumMappedElements());
            }
        }

        /// <summary>
        /// Utility function to help to prepare a map. It puts elements in a grid onto the visio
        /// and allows to tune the rough layout of the map background elements. Once the elements have been 
        /// put onto the map, all map background elements are right sized and aligned. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrepareClick(object sender, EventArgs e)
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

            // reference column number --> column name for the map
            var mapColumnMap = new Dictionary<int, string>();
            int mapMaxColumn;
            int mapNameColumn;
            MmExcelUtil.BuildColumnMap(xlWorkBook, mapSheetName.Text, mapNameColumnName.Text, mapColumnMap, out mapMaxColumn, out mapNameColumn);


            // reference column number --> tag for the elements
            var elementColumnMap = new Dictionary<int, string>();
            int elementMaxColumn;
            int elementNameColumn;
            MmExcelUtil.BuildColumnMap(xlWorkBook, elementSheetName.Text, elementNameColumnName.Text, elementColumnMap, out elementMaxColumn, out elementNameColumn);

            // list of all the constituents of the map
            var mapList = new List<GenericElement>();
            MmExcelUtil.BuildList(xlWorkBook, mapSheetName.Text, mapNameColumn, mapMaxColumn, mapColumnMap, mapList, mapNameColumnName.Text);

            // list of all the elements to be maped
            var elementList = new List<GenericElement>();
            MmExcelUtil.BuildList(xlWorkBook, elementSheetName.Text, elementNameColumn, elementMaxColumn, elementColumnMap, elementList, elementNameColumnName.Text);

 
            // Visio related aspects

            var visapp = new Microsoft.Office.Interop.Visio.Application();

            // Prepare Visio
            Document landscape = visapp.Documents.Open(visioFileName.Text);
            Document stencil = visapp.Documents.OpenEx(stencilFileName.Text, (short)VisOpenSaveArgs.visOpenDocked);
            Page page = visapp.ActivePage;


            

 
            Master elementStencil = stencil.Masters[elementStencilName.Text];
            if (elementStencil == null) throw new ArgumentNullException("elementStencil");

            Shape  elementShape =  page.Drop(elementStencil, 0.0, 0.0);

            double pageWidth = page.PageSheet.CellsU["PageWidth"].ResultIU;
            double pageHight = page.PageSheet.CellsU["PageHeight"].ResultIU;

            double elementWidth = elementShape.CellsU["Width"].ResultIU;
            double elementHeight = elementShape.CellsU["Height"].ResultIU;
            double space = double.Parse(spaceText.Text);
            
            double numColumns = (pageWidth  - space) / (elementWidth + space);
            double numRows = (pageHight - space) / (elementHeight + space);


            Trace.WriteLine("Size of an page    " + pageWidth + " " + pageHight);
            Trace.WriteLine("Size of an element " + elementWidth + " " + elementHeight);
            Trace.WriteLine("Number " + numRows + " rows " + numColumns + " columns");

            for (int r = 1; r < numRows; r++)
            {
                for (int c = 1; c < numColumns; c++)
                {
                    if (r == 1  && c == 1)
                    {
                        elementShape.Cells["PinX"].ResultIU = MmVisioUtil.CalculateX(c, elementWidth, space);
                        elementShape.Cells["PinY"].ResultIU = MmVisioUtil.CalculateY(r, elementHeight, space); 
                    }
                    else
                    {
                        elementShape = page.Drop(elementStencil, MmVisioUtil.CalculateX(c, elementWidth, space), MmVisioUtil.CalculateY(r, elementHeight, space));
                    }

                    double elementX = elementShape.CellsU["PinX"].ResultIU;
                    double elementY = elementShape.CellsU["PinY"].ResultIU;
                    String coordinates = "Element at " + String.Format("{0:0.00}", elementX) + "/" + String.Format("{0:0.00}", elementY);
                    elementShape.Text = coordinates;
                }
            }


            var placedMapShapes = new Dictionary<String, ShapeRef>();

            MmVisioUtil.GetShapeList(mapStencilName.Text, page, mapNameColumnName.Text, placedMapShapes);

            // Place missing map Elements on Landscape
            var missingMapShapes = new List<String>();
            DetermineMissingMapShapes(mapList, placedMapShapes, missingMapShapes);


            Master mapStencil = stencil.Masters[mapStencilName.Text];


            foreach (GenericElement ge in mapList)
            {
                if (missingMapShapes.Contains(ge.Name))
                {
                   MmVisioUtil.PlaceGenericElement(page, mapStencil, ge, 0, 0, space, mapColumnMap, false);
                }
            }


            Trace.Flush();
            Trace.Close();

        }

        /// <summary>
        /// The main routine which generates the map based on the parameters specified in the
        /// dialog on the user interface. The resolut is the final map with placed elements
        /// and right sized and adjusted map in the background.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateLandscapeButtonClick(object sender, EventArgs e)
        {
            // open log if not yet open
            var tr2 = new TextWriterTraceListener(File.CreateText(selectedLogFileName.Text));
            Trace.Listeners.Add(tr2);

            var errorList = new List<String>();

            // Excel related aspects
            var xlApp = new Microsoft.Office.Interop.Excel.Application {Visible = true};

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            // open the excel file
            String excelFileName = mapFileName.Text;
            Workbook xlWorkBook = xlApp.Workbooks.Open(excelFileName,
                                                       _missing, _missing, _missing, _missing, _missing, _missing,
                                                       _missing, _missing,
                                                       _missing, _missing, _missing, _missing, _missing, _missing);


            // read the columns of the sheets containing the map and the elements

            // reference column number --> tag for the map
            var mapColumnMap = new Dictionary<int, string>();
            int mapMaxColumn;
            int mapNameColumn;
            MmExcelUtil.BuildColumnMap(xlWorkBook, mapSheetName.Text, mapNameColumnName.Text, mapColumnMap,
                                       out mapMaxColumn, out mapNameColumn);

            // reference column number --> tag for the elements
            var elementColumnMap = new Dictionary<int, string>();
            int elementMaxColumn;
            int elementNameColumn;
            MmExcelUtil.BuildColumnMap(xlWorkBook, elementSheetName.Text, elementNameColumnName.Text, elementColumnMap,
                                       out elementMaxColumn, out elementNameColumn);

            // list of all the constituents of the map
            var mapList = new List<GenericElement>();
            MmExcelUtil.BuildList(xlWorkBook, mapSheetName.Text, mapNameColumn, mapMaxColumn, mapColumnMap, mapList,
                                  mapNameColumnName.Text);

            // list of all the elements to be maped
            var elementList = new List<GenericElement>();
            MmExcelUtil.BuildList(xlWorkBook, elementSheetName.Text, elementNameColumn, elementMaxColumn,
                                  elementColumnMap, elementList, elementNameColumnName.Text);




            // Visio related aspects

            var visapp = new Microsoft.Office.Interop.Visio.Application();

            // Prepare Visio
            Document landscape = visapp.Documents.Open(visioFileName.Text);
            Document stencil = visapp.Documents.OpenEx(stencilFileName.Text, (short) VisOpenSaveArgs.visOpenDocked);
            Page page = visapp.ActivePage;


            var placedMapShapes = new Dictionary<String, ShapeRef>();
            var placedElementShapes = new Dictionary<String, ShapeRef>();

            MmVisioUtil.GetShapeList(mapStencilName.Text, page, mapNameColumnName.Text, placedMapShapes);
            MmVisioUtil.GetShapeList(elementStencilName.Text, page, elementNameColumnName.Text, placedElementShapes);


            var missingMapShapes = new List<String>();
            DetermineMissingMapShapes(mapList, placedMapShapes, missingMapShapes);


            // Read all the mappings

            var mappingList = new List<Mapping>();
            MmExcelUtil.BuildMapping(xlWorkBook, mappingList, mappingSheetName.Text, mappingElementNameColumnName.Text,
                                     mappingMapNameColumnName.Text);


            // Create the mapping layout data structure

            var mapLayout = new Dictionary<String, MapLayoutElement>();
            PopulateMapLayout(mapList, elementList, mappingList, mapLayout);


            Master elementStencil = stencil.Masters[elementStencilName.Text];

//            Master marker = stencil.Masters["Marker"];

            Shape elementShape = page.Drop(elementStencil, 0.0, 0.0);

            double pageWidth = page.PageSheet.CellsU["PageWidth"].ResultIU;
            double pageHight = page.PageSheet.CellsU["PageHeight"].ResultIU;

            double elementWidth = elementShape.CellsU["Width"].ResultIU;
            double elementHeight = elementShape.CellsU["Height"].ResultIU;
            double space = double.Parse(spaceText.Text);

            double numColumns = (pageWidth - space)/(elementWidth + space);
            double numRows = (pageHight - space)/(elementHeight + space);


            Trace.WriteLine("Size of an page     w " + pageWidth + " " + pageHight);
            Trace.WriteLine("Size of an element  w " + elementWidth + " " + elementHeight);
            Trace.WriteLine("Space                 " + space);
            Trace.WriteLine("Number                " + numRows + " rows " + numColumns + " columns");

            elementShape.Delete();

            // determines size of map stencil on drawing in terms of elements which can be placed on it
            // the results are kept in the MapLayoutElement 
            CaclulateMapLayout(mapLayout, placedMapShapes, elementHeight, elementWidth, space);

            // Move elements on map to lower left 

            foreach (ShapeRef sr in placedElementShapes.Values)
            {
                sr.Shape.Cells["PinX"].ResultIU = 0;
                sr.Shape.Cells["PinY"].ResultIU = 0;
            }

            // Populate Map with Elements

            if (optimitzeElementLayoutCheckBox.Checked)
            {
                foreach (MapLayoutElement mle in mapLayout.Values)
                {
                   String mapElementName = mle.Name;
                    if (placedMapShapes.ContainsKey(mapElementName))
                    {
                        Shape mapShape = placedMapShapes[mapElementName].Shape;


                        double mapWidth = mapShape.CellsU["Width"].ResultIU;
                        double mapHeight = mapShape.CellsU["Height"].ResultIU;
                        double mapX = mapShape.CellsU["PinX"].ResultIU;
                        double mapY = mapShape.CellsU["PinY"].ResultIU;

                        if (titleSpaceCheckBox.Checked)
                        {
                            mapHeight -= space * 1.5;
                            mapY -= space * 0.75;
                        }

                        double offsetX = elementWidth / 2 + (mapWidth - (mle.MaxColumn - mle.MinColumn + 1) * elementWidth - (mle.MaxColumn - mle.MinColumn) * space) / 2;
                        double offsetY = mapHeight - (mle.MaxRow - mle.MinRow + 1) * elementHeight - (mle.MaxRow - mle.MinRow) * space;

                        int row = mle.MaxRow;
                        int col = mle.MinColumn;

                        if (titleRowCheckBox.Checked)
                            row--;

                        int topRow = row; // keep to use below in layout

                        mle.mapElements().Sort();

                        foreach (String meName in mle.mapElements())
                        {

                            GenericElement ge = elementList.Find(delegate(GenericElement x)
                            {
                                return x.Name == meName;
                            });

                            double ex = mapX - mapWidth / 2 + (col - mle.MinColumn)*(elementWidth + space) + offsetX;
                            double ey = mapY - mapHeight / 2 + (row - mle.MinRow) * (elementHeight + space) + offsetY;
                            MmVisioUtil.PlaceGenericElement(page, elementStencil, ge, ex, ey, elementColumnMap, showDescriptionsCheckBox.Checked);


                            DetermineNextCell(mle, topRow, ref row, ref col);
                       }
                    }
                }
            }
            else
            {
                foreach (MapLayoutElement mle in mapLayout.Values)
                {
                    int row = mle.MaxRow;
                    int col = mle.MinColumn;

                    if (titleRowCheckBox.Checked)
                        row--;
                    int topRow = row; // keep to use below in layout

                    mle.mapElements().Sort();
                    
                    foreach (String meName in mle.mapElements())
                    {

                        GenericElement ge = elementList.Find(delegate(GenericElement x)
                        {
                            return x.Name == meName;
                        });


                        MmVisioUtil.PlaceGenericElement(page, elementStencil, ge, row, col, space, elementColumnMap, true);


                        DetermineNextCell(mle, topRow, ref row, ref col);
 
                    }

                }

            }

            // Beautify Map

            if (!freezeMapCheckBox.Checked)
            {

                foreach (MapLayoutElement mle in mapLayout.Values)
                {
                    String mapElementName = mle.Name;
                    if (placedMapShapes.ContainsKey(mapElementName))
                    {
                        Shape mapShape = placedMapShapes[mapElementName].Shape;



                        double x = MmVisioUtil.CalculateX(mle.MinColumn, elementWidth, space) +
                                   (MmVisioUtil.CalculateX(mle.MaxColumn, elementWidth, space) -
                                    MmVisioUtil.CalculateX(mle.MinColumn, elementWidth, space)) / 2;
                        double y = MmVisioUtil.CalculateY(mle.MinRow, elementHeight, space) + 0.2 * space +
                                   (MmVisioUtil.CalculateY(mle.MaxRow, elementHeight, space) -
                                    MmVisioUtil.CalculateY(mle.MinRow, elementHeight, space)) / 2;
                        double w = (mle.MaxColumn - mle.MinColumn + 1)*(elementWidth + space) - 0.2*space;
                        double h = (mle.MaxRow - mle.MinRow + 1)*(elementHeight + space) - 0.2*space;

                        Trace.WriteLine(mle.Name + " raw    " +
                                        " X= " + String.Format("{0:0.00}", x) + " Y= " + String.Format("{0:0.00}", y) +
                                        " W= " + String.Format("{0:0.00}", w) + " H= " + String.Format("{0:0.00}", h));

                        if (titleSpaceCheckBox.Checked)
                        {
                            h += space * 1.5;
                            y += space * 0.75;
                        }

                        Trace.WriteLine(mle.Name + " spaced " +
                                        " X= " + String.Format("{0:0.00}", x) + " Y= " + String.Format("{0:0.00}", y) +
                                        " W= " + String.Format("{0:0.00}", w) + " H= " + String.Format("{0:0.00}", h));


                        mapShape.Cells["PinX"].ResultIU = x;
                        mapShape.Cells["PinY"].ResultIU = y;
                        mapShape.Cells["Width"].ResultIU = w;
                        mapShape.Cells["Height"].ResultIU = h;

                    }
                }

            }

            Trace.Flush();
            Trace.Close();

        }

        private void  DetermineNextCell(MapLayoutElement mle, int topRow, ref int row, ref int col)
        {
            if (columnsFirstCheckBox.Checked)
            {
                row--;
                if (row < mle.MinRow)
                {
                    row = topRow;
                    col++;
                }
            }
            else
            {
                col++;
                if (col > mle.MaxColumn)
                {
                    col = mle.MinColumn;
                    row--;
                }
            }
        }

        private void CaclulateMapLayout(Dictionary<string, 
                                        MapLayoutElement> mapLayout, Dictionary<string, 
                                        ShapeRef> placedMapShapes, 
                                        double elementHeight,
                                        double elementWidth, double space)
        {
            foreach (MapLayoutElement mle in mapLayout.Values)
            {
                String mapElementName = mle.Name;
                if (placedMapShapes.ContainsKey(mapElementName))
                {
                    // get the map shape and determine geometrical information

                    Shape mapShape = placedMapShapes[mapElementName].Shape;

                    Trace.WriteLine(" Map " + mapElementName);

                    double x = mapShape.CellsU["PinX"].ResultIU;
                    double y = mapShape.CellsU["PinY"].ResultIU;

                    double height = mapShape.CellsU["Height"].ResultIU;
                    double width = mapShape.CellsU["Width"].ResultIU;


                    // include special title space into the calculations

                    if (titleSpaceCheckBox.Checked)
                    {
                        y -= space * 0.75;
                        height -= space * 1.5; // compensate or elements will be place a row upwards
                    }
                   

                    double minX = x - 0.5*width;
                    double maxX = x + 0.5*width;

                    double minY = y - 0.5*height;
                    double maxY = y + 0.5*height;


                    mle.MinColumn = Convert.ToInt32(Math.Truncate((minX)/(elementWidth + space))) + 1;
                    mle.MaxColumn = Convert.ToInt32(Math.Truncate((width + space)/(elementWidth + space)) + mle.MinColumn - 1);


                    mle.MinRow = Convert.ToInt32(Math.Truncate((minY)/(elementHeight + space))) + 1;
                    mle.MaxRow = Convert.ToInt32(Math.Truncate((height + space)/(elementHeight + space)) + mle.MinRow - 1);

                    Trace.WriteLine(" minX   " + String.Format("{0:0.00}", minX) +
                                    " maxX   " + String.Format("{0:0.00}", maxX) +
                                    " width  " + String.Format("{0:0.00}", elementWidth + space) +
                                    " minC   " + String.Format("{0:0.00}", mle.MinColumn) +
                                    " maxC   " + String.Format("{0:0.00}", mle.MaxColumn));
                    Trace.WriteLine(" minY   " + String.Format("{0:0.00}", minY) +
                                    " maxY   " + String.Format("{0:0.00}", maxY) +
                                    " height " + String.Format("{0:0.00}", elementHeight + space) +
                                    " minR   " + String.Format("{0:0.00}", mle.MinRow) +
                                    " maxR   " + String.Format("{0:0.00}", mle.MaxRow));


                    Trace.WriteLine("Columns  " + mle.MinColumn + " to " + mle.MaxColumn +
                                    " and rows " + mle.MinRow + " to " + mle.MaxRow);
                    Trace.WriteLine("Capacity " + mle.ElementSlots(titleRowCheckBox.Checked) + " for " +
                                    mle.NumMappedElements() + " elements");
                    if (mle.ElementSlots(titleRowCheckBox.Checked) < mle.NumMappedElements())
                    {
                        String error = "### ERROR #### insufficient capacity " +
                                       (mle.NumMappedElements() - mle.ElementSlots(titleRowCheckBox.Checked)) +
                                       " elements for " + mle.Name + "(" + mle.NumMappedElements() + "," + mle.ElementSlots(titleRowCheckBox.Checked) + ")";
                        Trace.WriteLine(error);
                        errorListBox.Items.Add(error);
                    }
                }
                else
                {
                    String error = "### Map " + mapElementName + " not found in placed map elements";
                    Trace.WriteLine(error);
                    errorListBox.Items.Add(error);
                }
            }
        }





        /// <summary>
        /// Adjust the log file directory to the directory used here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapFileNameTextChanged(object sender, EventArgs e)
        {
            MMTraceUtil.UpdateLogFileName(logAtFilePath, mapFileName, selectedLogFileName);

        }

        /// <summary>
        /// Adjust the log file directory to the directory used here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StencilFileNameTextChanged(object sender, EventArgs e)
        {
            MMTraceUtil.UpdateLogFileName(logAtFilePath, stencilFileName, selectedLogFileName);

        }

        /// <summary>
        /// Adjust the log file directory to the directory used here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisioFileNameTextChanged(object sender, EventArgs e)
        {
            MMTraceUtil.UpdateLogFileName(logAtFilePath, visioFileName, selectedLogFileName);
        }

        /// <summary>
        /// Choose the appropriate File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisioFileSelectClick(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Visio File|*.vsd";
            openFileDialog.Title = "Open Vision Map File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                visioFileName.Text = openFileDialog.FileName;
            }
        }

        /// <summary>
        /// Choose the appropriate File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisioStencilSelectClick(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Visio Stencil File|*.vss";
            openFileDialog.Title = "Open Visio Stencil File";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                stencilFileName.Text = openFileDialog.FileName;
            }

        }

        /// <summary>
        /// Choose the appropriate File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapFileSelectClick(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Excel old|*.xlsx|Excel New |*.xls";
            openFileDialog.Title = "Open Excel File with Map";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                mapFileName.Text = openFileDialog.FileName;
            }
        }






        /// <summary>
        /// Save the current configuration
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
 
                var lvConfig = new LandscapeViewConfig();

                lvConfig.Name = mapName.Text;
                lvConfig.Version = mapVersion.Text;
                lvConfig.VisioMapFile = visioFileName.Text;
                lvConfig.VisioStencilFile = stencilFileName.Text;
                lvConfig.ExcelFile = mapFileName.Text;

                lvConfig.ElementStencil = elementStencilName.Text;
                lvConfig.ElementNameColumn = elementNameColumnName.Text;
                lvConfig.ElementSheet = elementSheetName.Text;

                lvConfig.MapStencil = mapStencilName.Text;
                lvConfig.MapNameColumn = mapNameColumnName.Text;
                lvConfig.MapSheet = mapSheetName.Text;

                lvConfig.MappingSheet = mappingSheetName.Text;
                lvConfig.MappingElementColumn = mappingElementNameColumnName.Text;
                lvConfig.MappingMapColumn = mappingMapNameColumnName.Text;

                lvConfig.MapSpace = spaceText.Text;
                lvConfig.MapTitleRowSpace = titleRowCheckBox.Checked;
                lvConfig.MapTitleSpace = titleSpaceCheckBox.Checked;
                lvConfig.FreezeMap = freezeMapCheckBox.Checked;
                lvConfig.OptimizeElements = optimitzeElementLayoutCheckBox.Checked;
                lvConfig.ColumnsFirst = columnsFirstCheckBox.Checked;
                lvConfig.ShowDescriptions = showDescriptionsCheckBox.Checked;


                var serializer = new XmlSerializer(lvConfig.GetType());
                TextWriter textWriter = new StreamWriter(configFileName);
                serializer.Serialize(textWriter, lvConfig);
                textWriter.Close();
 
            }
        }

        /// <summary>
        /// Load the current configuration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadConfigButtonClick(object sender, EventArgs e)
        {
            openConfigFileDialog.Filter = "XML File|*.xml";
            openConfigFileDialog.Title = "Open a Config File";
            if (openConfigFileDialog.ShowDialog() == DialogResult.OK)
            {
                String configFileName = openConfigFileDialog.FileName;

                var deserializer = new XmlSerializer(typeof(LandscapeViewConfig));
                TextReader textReader = new StreamReader(configFileName);
                var lvConfig = (LandscapeViewConfig) deserializer.Deserialize(textReader);
                textReader.Close();

                mapName.Text = lvConfig.Name;
                mapVersion.Text = lvConfig.Version;
                visioFileName.Text = lvConfig.VisioMapFile;
                stencilFileName.Text = lvConfig.VisioStencilFile;
                mapFileName.Text = lvConfig.ExcelFile;
                elementStencilName.Text = lvConfig.ElementStencil;
                elementNameColumnName.Text = lvConfig.ElementNameColumn;
                elementSheetName.Text = lvConfig.ElementSheet;

                mapStencilName.Text = lvConfig.MapStencil;
                mapNameColumnName.Text = lvConfig.MapNameColumn;
                mapSheetName.Text = lvConfig.MapSheet;

                mappingSheetName.Text = lvConfig.MappingSheet;
                mappingElementNameColumnName.Text = lvConfig.MappingElementColumn;
                mappingMapNameColumnName.Text = lvConfig.MappingMapColumn;

                spaceText.Text = lvConfig.MapSpace;
                titleRowCheckBox.Checked = lvConfig.MapTitleRowSpace;
                titleSpaceCheckBox.Checked = lvConfig.MapTitleSpace;
                freezeMapCheckBox.Checked = lvConfig.FreezeMap;
                optimitzeElementLayoutCheckBox.Checked = lvConfig.OptimizeElements;
                columnsFirstCheckBox.Checked = lvConfig.ColumnsFirst;
                showDescriptionsCheckBox.Checked = lvConfig.ShowDescriptions;

            }
        }

        /// <summary>
        /// Local Classes
        /// </summary>






       
        #region Nested type: MapLayoutElement

        public class MapLayoutElement
        {
            private List<String> MappedElements;

            public MapLayoutElement(String pName, int pMapElementIndex)
            {
                Name = pName;
                MinRow = 0;
                MaxRow = 0;
                MinColumn = 0;
                MaxColumn = 0;
                MapElementIndex = pMapElementIndex;
                MappedElements = new List<String>();
            }


            public String Name { get; private set; }
            public int MinRow { get; set; }
            public int MaxRow { get; set; }
            public int MinColumn { get; set; }
            public int MaxColumn { get; set; }
            public int MapElementIndex { get; set; }           // Index into MapElements

            public int ElementSlots(bool freeTitleRow)
            {
                if (freeTitleRow)
                    return (MaxRow - MinRow + 2)*(MaxColumn - MinColumn + 1);
                else
                    return (MaxRow - MinRow + 1) * (MaxColumn - MinColumn + 1);
            }

            public void AddMappedElement (String name)
            {
                MappedElements.Add(name);

            }

            public List<String> mapElements ()
            {
                return MappedElements;
            }

            public int NumMappedElements ()
            {
                return MappedElements.Count;
            }            
 

        }

        #endregion

        #region Nested type: LandscapeViewConfig

        public class LandscapeViewConfig
        {

            public String Name { get; set; }
            public String Version { get; set; }
            public String VisioMapFile { get; set; }
            public String VisioStencilFile { get; set; }
            public String ExcelFile { get; set; }

            public String ElementStencil { get; set; }
            public String ElementNameColumn { get; set; }
            public String ElementSheet { get; set; }

            public String MapStencil { get; set; }
            public String MapNameColumn { get; set; }
            public String MapSheet { get; set; }

            public String MappingSheet { get; set; }
            public String MappingElementColumn { get; set; }
            public String MappingMapColumn { get; set; }

            public String MapSpace { get; set; }
            public bool   MapTitleRowSpace { get; set; }
            public bool   MapTitleSpace { get; set; }
            public bool   FreezeMap { get; set; }
            public bool   OptimizeElements { get; set; }
            public bool ColumnsFirst { get; set; }
            public bool ShowDescriptions { get; set; }
  

        }

        #endregion

        private void OptimitzeElementLayoutCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (optimitzeElementLayoutCheckBox.Checked)
                freezeMapCheckBox.Checked = true;
        }






















    }
}
