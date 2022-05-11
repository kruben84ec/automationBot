using System;
using System.IO;

namespace senderEmail
{
    class ServiceLog
    {
        public void putLog(string messageLog)
        {
            string pathFile = "";
            string logWrite = "";
            //Obtener la hora del sistema
            var dateTime = DateTime.Now;
            var dateLogWrite = dateTime.ToString("yyyy-MM-dd hh:mm:ss");

            //Path donde se va reposar el archivo de Log
            pathFile = "logSender.txt";

            if (pathFile != "" && messageLog != "")
            {
                using (StreamWriter sw = File.AppendText(pathFile))
                {
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
