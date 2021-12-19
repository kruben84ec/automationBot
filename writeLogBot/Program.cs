using System;
using System.IO;

namespace writeLogBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathFile = "";
            string logWrite = "";
            string messageLog = "";
            //Obtener la hora del sistema
            var dateTime = DateTime.Now;
            var dateLogWrite = dateTime.ToString("yyyy-MM-dd hh:mm:ss");

            if (args.Length != 0)
            {
                //Path donde se va reposar el archivo de Log
                pathFile = args[0];
                messageLog = args[1];

                if(pathFile!="" && messageLog!="") {
                    using (StreamWriter sw = File.AppendText(pathFile)) {
                        logWrite += dateLogWrite + ";";
                        logWrite += messageLog + ";";
                        sw.WriteLine(logWrite);
                    }
                }
                else
                {
                    Console.WriteLine("Los argumentos no sson validos");
                }
            }


        }
    }
}
