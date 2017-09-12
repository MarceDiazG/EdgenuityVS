using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPages
{
    public class EdgenuityHeader : BasePage {

        public EdgenuityHeader() {
            
    }
        #region WebElements
        [FindsBy(How = How.CssSelector, Using = "#ctl00_conBody_pnlMain > h1")]
        public IWebElement LabelLoggedUser { get; private set; }

        [FindsBy(How = How.Id, Using = "nav")]
        public IWebElement NavigationPanel { get; private set; }
        #endregion

    }
}
