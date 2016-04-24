using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Visio;
using Page = Microsoft.Office.Interop.Visio.Page;
using Shape = Microsoft.Office.Interop.Visio.Shape;
using System.Diagnostics;



namespace MM_ModelViz
{
    class MmVisioUtil
    {

        /// <summary>
        /// Creates a list of all the shapes with the given type on the specified page
        /// </summary>
        /// <param name="shapeType">Identify the master shape</param>
        /// <param name="page">the page to analyze</param>
        /// <param name="tag">The tag with the name or identifier </param>
        /// <param name="placedShapes">the identified and placed shapes</param>
        public static void GetShapeList(String shapeType, Page page, String tag, Dictionary<String, ShapeRef> placedShapes)
        {
            foreach (Shape shape in page.Shapes)
            {

                String prop = "prop." + tag.Replace(" ", "_"); 

                if (shape.MasterShape != null &&
                    shape.MasterShape.Name.StartsWith(shapeType) &&
                    shape.CellExists[prop, 0] != 0)
                {
                    String key = shape.Cells[prop].Formula;
                    key = key.Replace("\"", "");

                    if (!placedShapes.ContainsKey(key))
                    {
                        placedShapes.Add(key, new ShapeRef(shape));
                    }
                    else
                    {
                        Trace.WriteLine("  Already known " + shapeType + " " + key);
                    }
                }

            }

            Trace.WriteLine("On visio  " + shapeType + " " + placedShapes.Count + " entries");
        }

        /// <summary>
        /// Calculates the Y coordinates for a given row 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="elementHeight"></param>
        /// <param name="space"></param>
        /// <returns></returns>
        public static double CalculateY(int row, double elementHeight, double space)
        {

            return (space + elementHeight / 2 + (row - 1) * (elementHeight + space));

        }

        /// <summary>
        /// Calculates the X coordinates for a given column
        /// </summary>
        /// <param name="column">Column number</param>
        /// <param name="elementWidth">the width of the element</param>
        /// <param name="space">the space between the elements</param>
        /// <returns></returns>
        public static double CalculateX(int column, double elementWidth, double space)
        {
            return 5 * space + elementWidth / 2 + (column - 1) * (elementWidth + space);
        }

        public static Shape PlaceGenericElement(Page page,
                                   Master elementStencil,
                                   GenericElement element,
                                   int row, int column, double space,
                                   Dictionary<int, String> columnMap,
                                   bool showNotes)
        {
            Shape elementShape = page.Drop(elementStencil, 0.0, 0.0);

            DecorateShape(element, columnMap, showNotes, elementShape);

            double elementWidth = elementShape.CellsU["Width"].ResultIU;
            double elementHeight = elementShape.CellsU["Height"].ResultIU;
            elementShape.Cells["PinX"].ResultIU = CalculateX(column, elementWidth, space);
            elementShape.Cells["PinY"].ResultIU = CalculateY(row, elementHeight, space);

            return elementShape;

        }


        public static Shape PlaceGenericElement(Page page,
                                         Master elementStencil,
                                         GenericElement element,
                                         double ex, double ey,
                                         Dictionary<int, String> columnMap,
                                         bool showNotes)
        {


            Shape elementShape = page.Drop(elementStencil, 0.0, 0.0);

            DecorateShape(element, columnMap, showNotes, elementShape);


            elementShape.Cells["PinX"].ResultIU = ex;
            elementShape.Cells["PinY"].ResultIU = ey;

            return elementShape;

        }

        public static Shape PlaceGenericElement(Page page,
                                               Master elementStencil,
                                               GenericElement element,
                                               double ex, double ey,
                                               double ew, double eh,
                                               Dictionary<int, String> columnMap,
                                               bool showNotes)

        {
            Shape elementShape = page.Drop(elementStencil, 0.0, 0.0);

            DecorateShape(element, columnMap, showNotes, elementShape);


            elementShape.Cells["PinX"].ResultIU = ex;
            elementShape.Cells["PinY"].ResultIU = ey;
            elementShape.Cells["Width"].ResultIU = ew;
            elementShape.Cells["Height"].ResultIU = eh;

            return elementShape;

        }



        /// <summary>
        /// Decorates the shape with tags if column names (with '_') and shape parameter names match
        /// </summary>
        /// <param name="element"></param>
        /// <param name="columnMap"></param>
        /// <param name="showNotes"></param>
        /// <param name="elementShape"></param>
        public static void DecorateShape(GenericElement element, Dictionary<int, string> columnMap, bool showNotes, Shape elementShape)
        {
            for (int ndx = 1; ndx <= columnMap.Keys.Count; ndx++)
            {
                String tag = columnMap[ndx];
                String value = element.GetValue(tag);

                String cellName = "Prop." + tag.Replace(" ", "_");
                String cellValue = cellName + ".Value";

                //                Trace.WriteLine("Cell  " + cellName + " --> " + cellValue);


                if (elementShape.CellExists[cellName, 0] != 0)
                {
                    elementShape.Cells[cellValue].FormulaU = "\"" + value + "\"";
                }
                else if (tag == "Description" && showNotes)
                {
                    elementShape.Text = value;
                }
            }
        }


        /// <summary>
        /// Places a decorated shape over an already placed shape
        /// </summary>
        /// <param name="page"></param>
        /// <param name="elementShape">the already placed element - to be decorated</param>
        /// <param name="decorationStencil">the stencial to be used for decoration</param>
        /// <param name="decorationElement">the element with the decoration parameters</param>
        /// <param name="columnMap">the mapping between column names and numbers</param>
        /// <param name="showNotes"></param>
        public static void PlaceDecorationElement(Page page, Shape elementShape, Master decorationStencil, GenericElement decorationElement,
                                            Dictionary<int, String> columnMap,
                                            bool showNotes)
        {

            Shape decorShape = page.Drop(decorationStencil, 0.0, 0.0);

            DecorateShape(decorationElement, columnMap, showNotes, decorShape);

            decorShape.Cells["PinX"].ResultIU = elementShape.CellsU["PinX"].ResultIU;
            decorShape.Cells["PinY"].ResultIU = elementShape.CellsU["PinY"].ResultIU;


        }

        /// <summary>
        /// Actually a visio utility function which connects two shapes with a connector
        /// </summary>
        /// <param name="shape1"></param>
        /// <param name="shape2"></param>
        /// <param name="connector"></param>
        public static void ConnectShapes(Shape shape1, Shape shape2, Shape connector)
        {
            // get the cell from the source side of the connector
            Cell beginXCell = connector.CellsSRC[(short)VisSectionIndices.visSectionObject, (short)VisRowIndices.visRowXForm1D, (short)VisCellIndices.vis1DBeginX];
            // glue the source side of the connector to the first Shape
            beginXCell.GlueTo(shape1.CellsSRC[(short)VisSectionIndices.visSectionObject, (short)VisRowIndices.visRowXFormOut, (short)VisCellIndices.visXFormPinX]);
            // get the cell from the destination side of the connector
            Cell endXCell = connector.CellsSRC[(short)VisSectionIndices.visSectionObject, (short)VisRowIndices.visRowXForm1D, (short)VisCellIndices.vis1DEndX];
            // glue the destination side of the connector to the second Shape
            endXCell.GlueTo(shape2.CellsSRC[(short)VisSectionIndices.visSectionObject, (short)VisRowIndices.visRowXFormOut, (short)VisCellIndices.visXFormPinX]);
        }

    }


    #region Nested type: ShapeConnection

    /// <summary>
    /// The class ShapeConnection represents a connection of to elements on the landscape
    /// </summary>
    public class ShapeConnection
    {
        public ShapeConnection(String sourceElement, String targetElement)
        {
            SourceElement = sourceElement;
            TargetElement = targetElement;
            Weight = 0;
        }

        public String SourceElement { get; private set; }
        public String TargetElement { get; private set; }
        public int Weight { get; set; }




        public String ConnectionName()
        {
            return SourceElement + "->" + TargetElement;
        }
    }

    #endregion

    #region Nested type: ShapeRef

    /// <summary>
    /// The class ShapeRef build the cross reference between visio shapes
    /// and their identifiers
    /// </summary>
    public class ShapeRef
    {
        public ShapeRef(Shape pShape)
        {
            Shape = pShape;
        }

        public Shape Shape { get; private set; }
    }

    #endregion
}
