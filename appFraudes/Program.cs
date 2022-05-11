using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appFraudes
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServiceAppRiegos access = new ServiceAppRiegos();
            String webAppFraudes = "http://10.100.176.95:500/AppFraudesNew/index.aspx";
            String webLoadData = "http://10.100.176.95:500/AppFraudesNew/Consulta.aspx";
            String pathConfig = @"E:\AsistenteLogScoreFraude\scripts\dist\employees.json";

            ServiceJson readConfig = new ServiceJson();
            CredentialModel credentialModel = new CredentialModel();
            credentialModel = readConfig.readJsonCredentials(pathConfig);

            String usuario = credentialModel.userName;
            String clave = credentialModel.password;
            IWebDriver driver = access.loginWeb(webAppFraudes, usuario, clave);

            driver.Navigate().GoToUrl(webLoadData);
            String disponibleData = driver.FindElement(By.ClassName("titulote")).Text;
            string hourDisponible = disponibleData.Split('-')[1].Replace(" ", String.Empty);

            

            Console.WriteLine(hourDisponible);

            //driver.Quit();
        }


    }
}
