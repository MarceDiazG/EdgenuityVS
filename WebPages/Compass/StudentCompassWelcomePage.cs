using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPages.Compass
{
    public class StudentCompassWelcomePage: BasePage
    {
        public StudentCompassWelcomePage() { }

        #region WebElements
        [FindsBy(How = How.XPath, Using = "//a[@href='javascript:appMenu.delayLogOut()']")]
        public IWebElement LinkSignOut { get; private set; }

        [FindsBy(How = How.Id, Using = "form1")]
        public IWebElement MainForm { get; private set; }
        #endregion

        public bool IsLoad()
        {
            return LinkSignOut.Displayed;
        }
    }
}