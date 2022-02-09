using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace encriptExcel
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
            Console.WriteLine("Se abrio esta ruta"+path);
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
    }
}
