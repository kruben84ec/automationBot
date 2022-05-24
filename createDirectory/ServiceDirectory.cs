using System;
using System.IO;
using System.Collections.Generic;


namespace createDirectory
{
    class ServiceDirectory
    {
        public void createDirectory(string path)


        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Creando el directorio: {0}", path);
                DirectoryInfo directoryCreate = Directory.CreateDirectory(path);
            }else
            {
                Console.WriteLine("Ya existe: {0}", path);
            }
        }

        public Dictionary<string, object> getDate()
        {
            var dateTime = DateTime.Now;
            var dateNow = dateTime.ToString("yyyy-MM-dd");
            var year = dateTime.ToString("yyyy");
            var nameMouth = dateTime.ToString("MMMM").ToUpper();
            var dateCompleteNow = new Dictionary<string, object>();
            dateCompleteNow.Add("dateNow", dateNow);
            dateCompleteNow.Add("year", year);
            dateCompleteNow.Add("nameMouth", nameMouth);
            return dateCompleteNow;
        }

        public void createDirectoryLog(string pathDestiny)
        {
            string pathDestinyLog = "";
            string pathLog = pathDestiny+ @"insumos\MacroCX91.xlsm";
            string pathReport = pathDestiny + @"insumos\reporte_.xlsx";
            var dateTimeNow = this.getDate();

            string yearFolder = (string)dateTimeNow["year"];
            string nameFolder = (string)dateTimeNow["nameMouth"];
            string dateFolder = (string)dateTimeNow["dateNow"];



            //pathLog = pathDestinyLog + @"\Log.xlsm";
            pathDestinyLog += pathDestiny+yearFolder;
            pathDestinyLog += @"\" + nameFolder;
            pathDestinyLog += @"\" + dateFolder;

            this.createDirectory(@pathDestinyLog);

            try
            {
                File.Delete(pathDestinyLog + @"\MacroCX91.xlsm");
                File.Copy(pathLog, pathDestinyLog + @"\MacroCX91.xlsm");
                string pathReportExist = pathDestinyLog + @"\reporte_.xlsx";

               
                
                bool isFoundFile = File.Exists(pathReportExist);
                Console.WriteLine(pathReport + ":"+isFoundFile.ToString());
                if (!isFoundFile)
                {
                    File.Copy(pathReport, pathReportExist);
                    Console.WriteLine("Crear");   
                }
                
                Console.WriteLine("Verificando el archivo ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public void createFolders(string pathDestiny)
        {
            this.createDirectoryLog(pathDestiny);
        }
    }
}
