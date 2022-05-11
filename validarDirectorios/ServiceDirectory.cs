using System;
using System.IO;
using System.Collections.Generic;

namespace validarDirectorios
{
    class ServiceDirectory
    {
        //"E:\AsistenteLogScoreFraude\config\ejecucion.xlsx" "E:\LogScoreMonitoreo"

        public void createDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Creando el directorio: {0}", path);
                DirectoryInfo direcoryCreate = Directory.CreateDirectory(path);
            }
        }

        public Dictionary<string,object> getDate()
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

        public void createDirectoryLog(string pathDestiny, string brand)
        {
            string pathDestinyLog = "";
            string pathLog = "";

            var dateTimeNow = this.getDate();

            string yearFolder = (string)dateTimeNow["year"];
            string nameFolder = (string)dateTimeNow["nameMouth"];
            string dateFolder = (string)dateTimeNow["dateNow"];

            pathDestinyLog += pathDestiny;
            pathDestinyLog += @"\" + brand;
            pathLog = pathDestinyLog+@"\Log.xlsm";
            pathDestinyLog += @"\LOGS\LOGS" + yearFolder;
            pathDestinyLog += @"\" + nameFolder;
            pathDestinyLog += @"\" + dateFolder;

            this.createDirectory(@pathDestinyLog);

            try
            {
                    File.Delete(pathDestinyLog +@"\Log.xlsm");
                    File.Copy(pathLog, pathDestinyLog +@"\Log.xlsm");
                    Console.WriteLine("Verificando el archivo de Log de la marca: "+ brand);
                    File.Delete(@"E:\envio_reporte\envio_reporte.xlsm");
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public void updateStausBrandMacro()
        {
            String pathConfigMacro = @"E:\AsistenteLogScoreFraude\config\configuracion.xlsx";
            //La hoja marcas es la 1
            ServiceExcel fileConfig = new ServiceExcel(pathConfigMacro, 1);
            fileConfig.updateStatus("deactivate");
  

        }

        public void createDirectoryBrand(string pathConfig, string pathDestiny)
        {
            ServiceExcel fileConfig = new ServiceExcel(pathConfig, 1);
            var brandConfigs = fileConfig.brandsConfig(3);
            this.updateStausBrandMacro();
            
            foreach(string brand in brandConfigs)
            {
                   this.createDirectoryLog(pathDestiny, brand);
            }
        }

        
    }
}
