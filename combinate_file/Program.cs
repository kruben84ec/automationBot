using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Globalization;

namespace combinate_file
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Stopwatch timeMeasure = new Stopwatch();
                //Capturar el tiempo de inicio
                String hourMinute = DateTime.Now.ToString("HH:mm");
                timeMeasure.Start();
                String pathReport = @args[0];
                String pathReportMacro = pathReport+ @"\MacroCX91.xlsm";
                String path = @"E:\Canceladasx91\config\marcas.xlsx";
                String pathReportExecute = pathReport + @"\reporte_";

                //Obtener los códigos de las marcas de los archivos txt
                ServiceExcel wb = new ServiceExcel(path, 1);
                List<string> codeBrandList = wb.getCodeBrand();
                //Obtener la información de los reportes generadas por los iconos de transferencia
                ServicesTxt txtBoletinadas = new ServicesTxt();
                List<string> dataExcelBoletindas = new List<string>();
                List<string> dataExcelYobsidiam = new List<string>();
                txtBoletinadas.getDataToExcel(codeBrandList, pathReport);
                dataExcelBoletindas = txtBoletinadas.accountBoletinadas;
                dataExcelYobsidiam = txtBoletinadas.accountYobsidiam;

                //Guadar la información en el archivo de excel
                ServiceExcel wbMacro = new ServiceExcel(pathReportMacro, 2);
                Console.WriteLine("Filas en \t");
                Console.WriteLine("Boletinadas: "+dataExcelBoletindas.Count.ToString()+"\t");
                Console.WriteLine("Yobsidiam: "+dataExcelYobsidiam.Count.ToString());

                //Las cuentas boletinadas tinen una cabcera por tanto debe empezar en 2
                int initWriteBoletinadas = (wbMacro.initRowWrite(pathReportMacro,2)+1);
                Console.WriteLine("Boletinadas: " + initWriteBoletinadas.ToString());
                wbMacro.insertDataExcel(pathReportMacro, dataExcelBoletindas,2, initWriteBoletinadas);
                int initWriteYobsidiam = wbMacro.initRowWrite(pathReportMacro, 1);
                Console.WriteLine("Yobsidiam: " + initWriteYobsidiam.ToString());

                wbMacro.insertDataExcel(pathReportMacro, dataExcelYobsidiam, 1, initWriteYobsidiam);
                
                //Ejecutar la macro
                ServiceExcel wbMacroConsolidado = new ServiceExcel(pathReportMacro, 2);
                Console.WriteLine("Ejecutando la macro");
                wbMacroConsolidado.executeMacro(pathReportMacro, "Macro5");
                


                //Generar el reporte de ejecución
                report.ReportController reporteEjecucion = new report.ReportController();
                reporteEjecucion.genereteReport(pathReportMacro, hourMinute, pathReportExecute);
                


                //Fin del tiempode proceso
                timeMeasure.Stop();
                Console.WriteLine($"Tiempo: {Math.Round((timeMeasure.Elapsed.TotalMilliseconds / 1000),2)} s");


            }
            else
            {
                Console.WriteLine("Los argumentos no son validos");
            }

        }
    }
}
