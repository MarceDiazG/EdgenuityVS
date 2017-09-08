using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;

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

        public static void Initialize(BrowserType type)
        {
            switch (type)
            {
                case BrowserType.Firefox:
                driverStore.Value = new FirefoxDriver();
                break;
            };    
            TurnOnWait();
            Get().Manage().Window.Maximize();
        }

        public static void Navigate()
        {
            Get().Navigate().GoToUrl(BaseAddress);
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
