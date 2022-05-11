using System;
using System.IO;
using System.Collections.Generic;

namespace merge_file
{
    class ServiceDirectory
    {


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

        public Dictionary<String, object> getDirectoryLog(string pathDestiny, string brand)
        {
            string pathDestinyLog = "";
            string pathLog = "";
            string pathLogMaster = "";
            Dictionary<String, object> results = new Dictionary<String,object>();

            var dateTimeNow = this.getDate();

            string yearFolder = (string)dateTimeNow["year"];
            string nameFolder = (string)dateTimeNow["nameMouth"];
            string dateFolder = (string)dateTimeNow["dateNow"];

            pathDestinyLog += pathDestiny;
            pathDestinyLog += @"\" + brand;
            pathLog = pathDestinyLog + @"\Log.xlsm";

            pathDestinyLog += @"\LOGS\LOGS" + yearFolder;
            pathDestinyLog += @"\" + nameFolder;
            pathDestinyLog += @"\" + dateFolder;

            pathLogMaster = pathDestinyLog + @"\Log.xlsm";

        



            try
            {
                File.Delete(pathLogMaster);
                File.Copy(pathLog, pathLogMaster);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            results.Add("pathLogMaster", pathLogMaster);
            results.Add("pathDestinyLog", pathDestinyLog);

            return results;



        }

        public void mergeExecute(string pathConfig, string pathLocal)
        {
            ServiceExcel fileConfig = new ServiceExcel(pathConfig, 1);
            var brandConfigs = fileConfig.brandsConfig(3);

            Dictionary<String, object> pathLogDirectory = new Dictionary<String, object>();
            foreach (string brand in brandConfigs)
            {

                pathLogDirectory = getDirectoryLog(pathLocal, brand);
            }
        }
    }
}
