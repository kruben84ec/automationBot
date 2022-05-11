using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace combinate_file
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Stopwatch timeMeasure = new Stopwatch();
                timeMeasure.Start();
                String pathReport = @args[0];
                Console.WriteLine("Trabajando en el directorio: "+pathReport);
                String pathReportMacro = pathReport+ @"\MacroCX91.xlsm";
                String path = @"E:\Canceladasx91\config\marcas.xlsx";
                //Obtener los códigos de las marcas
                int positioSheet = 1;
                ServiceExcel wb = new ServiceExcel(path, positioSheet);
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

                wbMacro.insertDataExcel(pathReportMacro, dataExcelBoletindas,2);
                wbMacro.insertDataExcel(pathReportMacro, dataExcelYobsidiam, 1);

                ServiceExcel wbMacroConsolidado = new ServiceExcel(pathReportMacro, 2);
                Console.WriteLine("Ejecutando la macro");
                wbMacroConsolidado.executeMacro(pathReportMacro, "Macro5");



                timeMeasure.Stop();
                
                Console.WriteLine($"Tiempo: {Math.Round((timeMeasure.Elapsed.TotalMilliseconds / 1000),2)} s");

                if (Stopwatch.IsHighResolution)
                    Console.WriteLine("Alta precisión");
                else
                    Console.WriteLine("Baja precisión");

            }
            else
            {
                Console.WriteLine("Los argumentos no son validos");
            }

        }
    }
}
