﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using System.Net;

namespace EdgeWebDriver
{
    public class Driver
    {
        private static ThreadLocal<IWebDriver> driverStore = new ThreadLocal<IWebDriver>();

        public static IWebDriver Get()
        {
            return driverStore.Value;
        }

        public static string BaseAddress
        {
            get { return ConstantsUtils.Url; }
        }

        public static void Initialize(Browsers type)        {
            /*WebProxy proxyObject = new WebProxy("10.120.2.251", 3128);
            WebRequest req = WebRequest.Create("https://auth.qa.edgenuity.com/Login/Login/Educator");
            req.Proxy = proxyObject;*/
            switch (type) {
                case Browsers.Firefox:
                driverStore.Value = new FirefoxDriver();
                break;
            };    
            TurnOnWait();
            Get().Manage().Window.Maximize();
        }

        public static void Navigate()
        {
            Get().Navigate().GoToUrl("https://auth.qa.edgenuity.com/Login/Login/Educator"); // BaseAddress);
        }

        public static void Close()
        {
            Get().Close();
        }

        private static void TurnOnWait()
        {
            Get().Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }
    }
}
