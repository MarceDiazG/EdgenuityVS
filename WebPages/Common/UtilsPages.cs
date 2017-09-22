using OpenQA.Selenium;
using Pages.Waits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPages.Common
{
    public static class UtilsPages
    {

        public static void elementHighlight(IWebElement element, IWebDriver driver)
        {
            for (int i = 0; i < 2; i++)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].style.border='3px groove green'", element);
            }
        }
    }
}
