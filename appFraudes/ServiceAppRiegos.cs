using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appFraudes
{
    public class ServiceAppRiegos
    {
        public IWebDriver loginWeb(String webAppFraudes, String usuario, String clave)
        {
            IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl(webAppFraudes);
            driver.FindElement(By.Id("txtUsuario")).SendKeys(usuario);
            driver.FindElement(By.Id("txtClave")).SendKeys(clave);
            driver.FindElement(By.Id("btnIngresar")).Click();
            return driver;
        }

        public IWebDriver loadBrand(IWebDriver driver, String webLoadData, Dictionary<String, object> paramsLoadData)
        {
            driver.Navigate().GoToUrl(webLoadData);
            return driver;
        }
    }
}
