using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace validarDirectorios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceDirectory directory = new ServiceDirectory();
            //"E:\AsistenteLogScoreFraude\config\ejecucion.xlsx" "E:\LogScoreMonitoreo"
            

            if (args.Length > 0)
            {
                string pathConfig = args[0];
                string pathDestiny = args[1];

                directory.createDirectoryBrand(pathConfig, pathDestiny);

            }
            else
            {
                Console.WriteLine("Los argumentos no son validos");
            }
        }
    }
}
