using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using System.Net;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using DB_Layer;
using log4net;
using log4net.Config;

namespace EdgeWebDriver
{
    public class Driver
    {
        private static ThreadLocal<IWebDriver> driverStore = new ThreadLocal<IWebDriver>();
        private static readonly ILog log = LogManager.GetLogger(typeof(Driver));

        public static IWebDriver Get()
        {
            return driverStore.Value;
        }

        public static string BaseAddress
        {
            get { return ConstantsUtils.Url; }
        }

        public static void Initialize(Browsers type)
        {
            BasicConfigurator.Configure();
            log.Info("Initializing driver....");
            switch (type)
            {
                case Browsers.Firefox:
                    driverStore.Value = new FirefoxDriver();
                    break;
                case Browsers.Chrome:
                    driverStore.Value = new ChromeDriver();
                    break;
                case Browsers.IExplorer:
                    driverStore.Value = new InternetExplorerDriver();
                    break;
                case Browsers.PhantomJS:
                    driverStore.Value = new PhantomJSDriver();
                    break;
                case Browsers.Remote:
                    driverStore.Value = new InternetExplorerDriver();
                    break;
            };
            TurnOnWait();
            Get().Manage().Window.Maximize();
        }

        public static void Navigate()
        {
            Get().Navigate().GoToUrl(DataAccess.GetEnvironmentURL("QA_Educator"));
        }

        public static void Close()
        {
            Get().Close();
        }

        private static void TurnOnWait()
        {
            Get().Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }
        public static void TurnOnWait(int seconds)
        {
            Get().Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(seconds));
        }
    }

}
