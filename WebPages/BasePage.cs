﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Firefox;
using EdgeWebDriver;
using OpenQA.Selenium.Support.PageObjects;

namespace WebPages
{
    public class BasePage    {
        protected static IWebDriver driver;

        protected BasePage(){
            driver = Driver.Get();
            PageFactory.InitElements(driver, this);
        }

        public void GoToSite(string WebUrl){
            Driver.Get().Navigate().GoToUrl(WebUrl);

            //IWebDriver webDriver = Driver.Instance();
            //driver.Navigate().GoToUrl(WebUrl);
        }
    }
}
