using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using _Excel = Microsoft.Office.Interop.Excel;

namespace combinate_file
{
    class ServiceExcel
    {
        string path = "";
        public _Application excel = new _Excel.Application();

        public Workbook wb;
        public Worksheet ws;
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

        public int initRowWrite(string path, int sheetIndex)
        {
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheetIndex];
            var rangeExcel = ws.UsedRange;
            int initFileRow = rangeExcel.Rows.Count;
            wb.Save();
            wb.Close();
            excel.Quit();
            return initFileRow;
        }

        public void insertDataExcel(string path, List<string> dataExcel, int sheetIndex, int initRowWrite)
        { 
            char[] columnLabel = this.getChartPositionExcel();
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheetIndex];

            for (int rowAccount = 0; rowAccount < dataExcel.Count; rowAccount++)
            {
                string[] columnData = dataExcel[rowAccount].Split('\t');
                int initRow = rowAccount + initRowWrite;
                string startColumn = columnLabel[0] + initRow.ToString();
                string endColumn = columnLabel[(columnData.Length - 1)] + initRow.ToString();
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

        public Dictionary<string, object> countDataList(List<string> listData)
        {
            Dictionary<string, object> resultData = new Dictionary<string, object>();
           var dataCounting =  listData
            .GroupBy(x => x)
            .ToDictionary(y => y.Key, y => y.Count())
            .OrderByDescending(z => z.Value);

            foreach (var dataItem in dataCounting)
            {
                resultData.Add(dataItem.Key, dataItem.Value);
            }
            return resultData;
        }

        public void generateReport(List<string> codeBrandList, string pathReporte)
        {
            /*
            ServiceManagerTime timeManager = new ServiceManagerTime();
            Dictionary<string, string> timeExecute = timeManager.getTime();
            */
            var result = codeBrandList
            .GroupBy(x => x)
            .ToDictionary(y => y.Key, y => y.Count())
            .OrderByDescending(z => z.Value);

            foreach (var x in result)
            {
                Console.WriteLine(x.Key + ":" + x.Value);
            }

        }
        public List<string> getDataCanceladas()
        {
           var codeBrandList = new List<string>();
            var rangeExcel = ws.UsedRange;
            if (rangeExcel != null)
            {
                int numbreRows = rangeExcel.Rows.Count;
                for (int initRow = 2; initRow <= numbreRows; initRow++)
                {
                    string accountNumber = ws.Cells[initRow, 1].Value;
                    string codeBrand = ws.Cells[initRow, 14].Value;
                    if (accountNumber != null && !String.IsNullOrWhiteSpace(accountNumber.ToString()))
                    {
                        if(codeBrand == null)
                        {
                            codeBrandList.Add("Vacio");
                        }
                        else
                        {
                            codeBrandList.Add(codeBrand);
                        }
                    }else
                    {
                        break;
                    }

                }
            }
            Close();
            excel.Quit();
            return codeBrandList;
        }


    }
}
