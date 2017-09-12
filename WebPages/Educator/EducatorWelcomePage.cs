using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPages
{
    public class EducatorWelcomePage: BasePage    {
        

        public EducatorWelcomePage() {
        }

        #region WebElements
        [FindsBy(How = How.XPath, Using = "//a[@title='Sign Out']")]
        public IWebElement LinkSignOut { get; private set; }

        [FindsBy(How = How.Id, Using = "ctl00_conBody_lnkReviewCount")]
        public IWebElement BtnReviewPending { get; private set; }
        
        #endregion

        public EducatorLoginPage ClickSignOut() {
            LinkSignOut.Click();
            return new EducatorLoginPage();
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

            
         
            bool labelIsPresent = EHeader.LabelLoggedUser.Displayed;
            bool navigationIsPresent = EHeader.NavigationPanel.Displayed;
            Console.WriteLine("Elements are present?: "+labelIsPresent+"/"+navigationIsPresent);
            return labelIsPresent && navigationIsPresent;
        }
 
    }
}
