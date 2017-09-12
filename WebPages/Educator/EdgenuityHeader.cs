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
        [FindsBy(How = How.ClassName, Using = "userLoggedIn")]
        public IWebElement LabelLoggedUser { get; private set; }

        [FindsBy(How = How.Id, Using = "nav")]
        public IWebElement NavigationPanel { get; private set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='../ Authentication / Logout']")]
        public IWebElement LogoutButton { get; private set; }
        #endregion

        //a[@href="../Authentication/Logout"]
        public static void ClickOnLogoutButton()
        {
            //LogoutButton.Click();
        }
    }
}
