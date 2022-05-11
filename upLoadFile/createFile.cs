using System;
using System.IO;
using System.Collections.Generic;

namespace upLoadFile
{
    class createFile
    {

        public void createDirectory(string path)


        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Creando el directorio: {0}", path);
                DirectoryInfo directoryCreate = Directory.CreateDirectory(path);
            }
            else
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

        public void createDirectoryPath(string pathDestiny)
        {
            string pathDestinyLog = "";
            var dateTimeNow = this.getDate();

            string yearFolder = (string)dateTimeNow["year"];
            string nameFolder = (string)dateTimeNow["nameMouth"];
            string dateFolder = (string)dateTimeNow["dateNow"];

            pathDestinyLog += pathDestiny + yearFolder;
            pathDestinyLog += @"\" + nameFolder;
            pathDestinyLog += @"\" + dateFolder;

            this.createDirectory(@pathDestinyLog);

        }
    }
}
