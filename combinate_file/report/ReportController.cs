using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace combinate_file.report
{
    class ReportController 
    {
        public List<String> dataReport = new List<String>();
        public Dictionary<String, object> dataCode = new Dictionary<String, object>();

        //Obtener los datos desde el archivo de excel
        public void getDataReport(String pathReportMacro)
        {
            ServiceExcel reportCanceladas = new ServiceExcel(pathReportMacro, 4);
            this.dataReport = getDataCanceladas(reportCanceladas);
            this.dataCode = reportCanceladas.countDataList(this.dataReport);
        }
        public List<string> getDataCanceladas(ServiceExcel report)
        {
            var codeBrandList = new List<string>();
            var rangeExcel = report.ws.UsedRange;
            if (rangeExcel != null)
            {
                int numbreRows = rangeExcel.Rows.Count;
                for (int initRow = 2; initRow <= numbreRows; initRow++)
                {
                    dynamic accountNumber = Convert.ToString(report.ws.Cells[initRow, 1].Value);
                    dynamic codeBrand = Convert.ToString(report.ws.Cells[initRow, 14].Value);


                    if (accountNumber != null && !String.IsNullOrWhiteSpace(accountNumber.ToString()))
                    {
                        if (codeBrand == null || codeBrand == "-2146826246")
                        {
                            codeBrandList.Add("Vacio");
                        }
                        else
                        {
                            codeBrandList.Add(codeBrand);
                        }
                    }
                    else
                    {
                        break;
                    }

                }
            }
            report.Close();
            report.excel.Quit();
            return codeBrandList;
        }

        //Generar el reporte
        public void genereteReport(string pathReportExecuteSource, string hourInit, string pathReportDestiny)
        {
            Console.WriteLine("Vamos a abrir eñ archivo de: "+ pathReportExecuteSource);
            ServiceManagerTime timerExecute = new ServiceManagerTime();
            List<string> recorDataReport = new List<string>();

            Dictionary<string, string> timerTrack = new Dictionary<string, string>();

            timerTrack = timerExecute.getTime();

            this.getDataReport(pathReportExecuteSource);
            foreach (var itemData in this.dataCode)
            {
                string brand = itemData.Key.ToString();
                string recordBrand = itemData.Value.ToString();
                string recorReport = timerTrack["fecha"] +"\t";
                recorReport += timerTrack["mes"] + "\t";
                recorReport += timerTrack["anio"] + "\t";
                recorReport += brand + "\t";
                recorReport += hourInit + "\t";
                recorReport += timerTrack["hour"] + "\t";
                recorReport += timerTrack["hour"] + "\t";
                recorReport += recordBrand + "";
                recorDataReport.Add(recorReport);
            }

            ServiceExcel reporteExecute = new ServiceExcel(pathReportDestiny, 1);
            int initWriteBoletinadas = reporteExecute.initRowWrite(pathReportDestiny, 1) + 1;
            reporteExecute.insertDataExcel(pathReportDestiny, recorDataReport, 1, initWriteBoletinadas);

        }

    }
}
