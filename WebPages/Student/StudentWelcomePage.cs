using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPages
{
    public class StudentWelcomePage : BasePage    {
        

        public StudentWelcomePage() {
        }

        #region WebElements
        [FindsBy(How = How.Id, Using = "tabSignOut")]
        public IWebElement TabSignOut { get; private set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='pnlSignOut']/img[@class='SignoutYes']")]
        public IWebElement YesSignOut { get; private set; }

        [FindsBy(How = How.Id, Using = "tabCourseList")]
        public IWebElement ImgMyCourseList { get; private set; }


        [FindsBy(How = How.Id, Using = "subject-1")]
        public IWebElement LinkScience { get; private set; }

        
        
        #endregion

        public StudentLoginPage ClickSignOut() {
            TabSignOut.Click();
            YesSignOut.Click();
            return new StudentLoginPage();
        }
        private EdgenuityHeader edgenuityHeader = null;
        public EdgenuityHeader EHeader

        {
            get { return edgenuityHeader ?? (edgenuityHeader = new EdgenuityHeader()); }
        }

        private UserLoggedPopUp userLogged = null;
        public UserLoggedPopUp UserLogged

        {
            get { return userLogged ?? (userLogged = new UserLoggedPopUp()); }
        }

        public bool IsLoad() {

            return ImgMyCourseList.Displayed;
       }

        public bool IsLinkScienceDisplayed()
        {
            return LinkScience.Displayed;
        }

    }
}
