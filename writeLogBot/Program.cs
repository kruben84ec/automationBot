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
            var dateTime = DateTime.Now;
            var dateLogWrite = dateTime.ToString("yyyy-MM-dd hh:mm:ss");

            if (args.Length != 0)
            {
                pathFile = args[0];
                messageLog = args[1];
                using (StreamWriter sw = File.AppendText(pathFile))
                {
                    logWrite += dateLogWrite + ";";
                    logWrite += messageLog + ";";
                    sw.WriteLine(logWrite);
                }
            }


        }
    }
}
