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
                var fileToDelete = pathDestinyLog;
                var fullDirPath = Path.GetFullPath(userUploadsDir);
                var fullFilePath = Path.GetFullPath(fileToDelete);
                 
                Console.WriteLine(fullDirPath);
                Console.WriteLine(fullFilePath);


                /*
                if (!fullFilePath.StartsWith(fullDirPath, StringComparison.Ordinal))
                {
                    File.Delete(fullFilePath);
                    File.Copy(pathLog, fullDirPath);
                }
                else
                {
                    Console.WriteLine(fullFilePath.StartsWith(fullDirPath, StringComparison.Ordinal).ToString());
                }
                */
                var pathReportExist = pathDestinyLog + @"\"+reporteCanceladas;
                var fullDirPathReport = Path.GetFullPath(pathReportExist);
                var fullFileCopyReport = Path.GetFullPath(pathReportExist);

                var isFoundFile = File.Exists(fullDirPathReport);

                if (!isFoundFile && !fullFilePath.StartsWith(fullDirPath, StringComparison.Ordinal))
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
