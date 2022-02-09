using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace validarDirectorios
{
    class ServiceExcel
    {
        string path = "";
        _Application excel = new Excel.Application();
        Workbook wb;
        Worksheet ws;
        Range excelRange;

        public ServiceExcel(string path, int Sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(@path);
            ws = wb.Worksheets[Sheet];
            excelRange = ws.UsedRange;
        }

        public void Close()
        {
            wb.Close();
        }

        public Array brandsConfig(int columna)
        {
            int rows = excelRange.Rows.Count;
       
            List<string> configBrandList = new List<string>();
           

            String dataConfig = "";

            for (int brand = 2; brand <= rows; brand++)
            {
                dataConfig = excelRange.Cells[brand, columna].Value2.ToString();
                configBrandList.Add(dataConfig);
            }
            Close();

            string[] brands = configBrandList.ToArray();
            return brands;

        }

       
    }
}
