using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;

namespace MM_ModelViz
{
    class MmExcelUtil
    {
        public static String GetCell(Worksheet xlWorkSheet, int row, int col)
        {
            var rg = (Range)xlWorkSheet.Cells[row, col];
            if (rg.Value2 == null)
                return "";
            return rg.Value2.ToString();
        }


        /// <summary>
        /// returns the column number with the given name 
        /// assumes that the column names are in row 1
        /// </summary>
        /// <returns></returns>
        public static int ColumnNumber(Worksheet xlWorkSheet, String columnName)
        {
            int columnFound = -1;
            int column = 1;
            String nameFound;

            do
            {
                nameFound = (GetCell(xlWorkSheet, 1, column));

                if (nameFound == columnName)
                {
                    columnFound = column;
                    break;
                }
                column++;
            } while (nameFound != "");

            return columnFound;
        }

        /// <summary>
        /// Builds a map of column names and column numbers
        /// </summary>
        /// <param name="xlWorkBook">the excel workbook</param>
        /// <param name="sheetName">the sheet to be mapped</param>
        /// <param name="tagName">The name of the columns which is used as the link (usually 'Name') </param>
        /// <param name="columnMap">the actual map which is built</param>
        /// <param name="maxColumn">the max column number used in the sheet</param>
        /// <param name="nameColumn">the column containing the name</param>
        public static void BuildColumnMap(Workbook xlWorkBook, String sheetName, String tagName,
                                           Dictionary<int, string> columnMap,
                                           out int maxColumn, out int nameColumn)
        {

            maxColumn = 1;
            nameColumn = -1;
            String columnName;

            var xlWorkSheet = (Worksheet)xlWorkBook.Worksheets[sheetName];
            do
            {
                columnName = (GetCell(xlWorkSheet, 1, maxColumn));

                if (columnName == tagName)
                {
                    nameColumn = maxColumn;
                }
                columnMap.Add(maxColumn, columnName);
                maxColumn++;
            } while (columnName != "");

            Trace.WriteLine("ColumnMap built from sheet " + sheetName + " with " + columnMap.Count + " entries and mapping name in " + nameColumn);
        }

        /// <summary>
        /// Converts a sheet into a list of gereric elements
        /// </summary>
        /// <param name="xlWorkBook">the execl workbook</param>
        /// <param name="sheetName">the excel sheet</param>
        /// <param name="nameColumn">the column containing the name</param>
        /// <param name="maxColumn">the max column in the sheet</param>
        /// <param name="columnMap">the column map built with BuildColumnMap for this sheet</param>
        /// <param name="elementList">the resulting list of generic elements</param>
        /// <param name="nameColumnName"></param>
        public static void BuildList(Workbook xlWorkBook, String sheetName, int nameColumn,
                                      int maxColumn, Dictionary<int, String> columnMap,
                                      List<GenericElement> elementList,
                                      String nameColumnName)
        {
            var xlWorkSheet = (Worksheet)xlWorkBook.Worksheets[sheetName];
            int row = 2;

            while (GetCell(xlWorkSheet, row, nameColumn) != "")
            {
                var ge = new GenericElement(xlWorkSheet, row, maxColumn, columnMap, nameColumnName);
                elementList.Add(ge);
                row++;
            }
            Trace.WriteLine("List built from sheet " + sheetName + " with " + elementList.Count + " entries");

        }


        /// <summary>
        /// Read the mappings from the respective excel sheet
        /// </summary>
        /// <param name="xlWorkBook">the excel work book</param>
        /// <param name="mappingList">the resulting list of mappings</param>
        /// <param name="mappingSheetName"></param>
        /// <param name="elementColumnName"></param>
        public static void BuildMapping(Workbook xlWorkBook, List<Mapping> mappingList, String mappingSheetName, String elementColumnName, String mappingColumnName)
        {
            var xlWorkSheet = (Worksheet)xlWorkBook.Worksheets[mappingSheetName];
            int column = 1;
            int elementColumnNumber = 0;
            int mappingColumnNumber = 0;
            String cellValue;

            do
            {
                cellValue = MmExcelUtil.GetCell(xlWorkSheet, 1, column);
                if (cellValue == elementColumnName)
                    elementColumnNumber = column;
                if (cellValue == mappingColumnName)
                    mappingColumnNumber = column;
                column++;
            } while (!String.IsNullOrEmpty(cellValue));

            Trace.WriteLine("Mapping element column " + elementColumnNumber + " mapping column " + mappingColumnNumber);

            int row = 2;

            if (mappingColumnNumber != 0 &&
                elementColumnNumber != 0)
            {
                while (MmExcelUtil.GetCell(xlWorkSheet, row, 1) != "")
                {
                    var mapping = new Mapping(MmExcelUtil.GetCell(xlWorkSheet, row, elementColumnNumber),
                                              MmExcelUtil.GetCell(xlWorkSheet, row, mappingColumnNumber));

//                    Trace.WriteLine("   adding mapping " + mapping.ElementName + " to " + mapping.MapName);
                    mappingList.Add(mapping);
                    row++;
                }
            }

            Trace.WriteLine("List built " + mappingSheetName + " " + mappingList.Count + " entries");

        }


    }


    #region Nested type: Mapping

    /// <summary>
    /// The class ShapeRef build the cross reference between visio shapes
    /// and their identifiers
    /// </summary>
    public class Mapping
    {
        public Mapping(String pElementName, String pMapName)
        {
            ElementName = pElementName;
            MapName = pMapName;
        }

        public String ElementName { get; private set; }
        public String MapName { get; private set; }

    }

    #endregion
 

    class GenericElement
    {
        private readonly Dictionary<String, String> _tagValues;

        public GenericElement(Worksheet sheet, int row, int maxColumn, Dictionary<int, String> columnMap, String NameColumnName)
        {
            _tagValues = new Dictionary<string, string>();

            for (int column = 1; column < maxColumn; column++)
            {
                String tag = columnMap[column];
                String value = MmExcelUtil.GetCell(sheet, row, column);

                if (tag == NameColumnName)
                {
                    Name = value;
                }
                _tagValues.Add(tag, value);

            }

        }


        public String GetValue(String tagName)
        {
            return _tagValues[tagName];
        }

        public String Name { get; private set; }


    }
}
