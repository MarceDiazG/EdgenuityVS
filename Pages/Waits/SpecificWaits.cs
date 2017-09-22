using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pages.Waits
{
    public class SpecificWaits {


        public static void specificWaitSeconds(int seconds, IWebDriver driver) {

            var timeout = seconds * 1000; // milliseconds
            Thread.Sleep(timeout);
        }
    }
}
