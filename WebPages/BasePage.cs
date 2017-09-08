using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Firefox;
using EdgeWebDriver;

namespace WebPages
{
    public class BasePage    {
        protected static IWebDriver driver = Driver.Get();

        protected BasePage(){

        }
        public void GoToSite(string WebUrl){
            Driver.Get().Navigate().GoToUrl(WebUrl);

            //IWebDriver webDriver = Driver.Instance();
            //driver.Navigate().GoToUrl(WebUrl);
        }
    }
}
