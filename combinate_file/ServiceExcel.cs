using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using _Excel = Microsoft.Office.Interop.Excel;

namespace combinate_file
{
    class ServiceExcel
    {
        string path = "";
        _Application excel = new _Excel.Application();

        Workbook wb;
        Worksheet ws;
        public ServiceExcel(string path, int Sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[Sheet];
        }

        public void ProtectWorkbook(string password)
        {
            //wb.Protect(password);
            wb.Password = password;
            Console.WriteLine("Se protegio el archivo");
            wb.Save();

        }
        public void Close()
        {
            wb.Close();
        }

        public String nameSheet()
        {
            return ws.Name;
        }

        public List<string> getCodeBrand()
        {
            List<string> codeBrandList = new List<string>();
            var rangeExcel = ws.UsedRange;
            if (rangeExcel != null)
            {
                int numbreRows = rangeExcel.Rows.Count;
                int numbreColumns = rangeExcel.Columns.Count;
                for (int initRow = 1; initRow <= numbreRows; initRow++)
                {
                    var codeBrand = ws.Cells[initRow, 2].Value;
                    codeBrandList.Add(codeBrand);

                }
            }
            Close();
            excel.Quit();
            return codeBrandList;
        }

        public char[] getChartPositionExcel()
        {
            string positionColumn = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] columnLabel = positionColumn.ToCharArray();
            return columnLabel;
        }

        public void insertDataExcel(string path, List<string> dataExcel, int rowInitWriteData)
        { 
            char[] columnLabel = this.getChartPositionExcel();
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[rowInitWriteData];
            for (var rowAccount = rowInitWriteData; rowAccount < dataExcel.Count; rowAccount++)
            {
                string[] columnData = dataExcel[rowAccount].Split('\t');
                string startColumn = columnLabel[0] + rowAccount.ToString();
                string endColumn = columnLabel[(columnData.Length - 1)] + rowAccount.ToString();
                string rangeData = startColumn + ":" + endColumn;
                Range cellRange = ws.Range[rangeData];
                cellRange.set_Value(XlRangeValueDataType.xlRangeValueDefault, columnData);
            }
            wb.Save();
            wb.Close();
            excel.Quit();
        }

        public void executeMacro(string path, string nameMAcro)
        {
            this.path = path;
            try {
                excel.Run(nameMAcro);
                wb.Save();
                wb.Close();
                excel.Quit();
            }
            catch {
                wb.Close(false);
                excel.Quit();
            }

        }
    }
}
