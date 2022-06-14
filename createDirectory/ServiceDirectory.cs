using System;
using System.IO;
using System.Collections.Generic;


namespace createDirectory
{
    class ServiceDirectory
    {
        private const string macroCanceladas = "MacroCX91.xlsm";
        private const string reporteCanceladas = "reporte_.xlsx";

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
            string pathLog = pathDestiny+ @"insumos\"+ macroCanceladas;
            string pathReport = pathDestiny + @"insumos\"+ reporteCanceladas;
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

                var userUploadsDir = pathDestinyLog + @"\"+macroCanceladas;
                var fullDirPath = Path.GetFullPath(userUploadsDir);
                Console.WriteLine(fullDirPath.ToString());


                File.Delete(pathDestinyLog + @"\"+macroCanceladas);
                File.Copy(pathLog, pathDestinyLog + @"\"+macroCanceladas);
                string pathReportExist = pathDestinyLog + @"\"+reporteCanceladas;

               
                
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
