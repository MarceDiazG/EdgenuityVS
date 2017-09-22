using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdgeWebDriver;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using DB_Layer;
using OpenQA.Selenium.Support.UI;
using Pages.Waits;
using WebPages.Common;

namespace WebPages.Odyssey
{
    public class OdysseyLoginPage : BasePage
    {
        /// <summary>
        /// Default constructor for OdysseyLoginPage
        /// </summary>
        public OdysseyLoginPage() {
            PageFactory.InitElements(driver, this);
        }

        #region WebElements
        [FindsBy(How = How.Id, Using = "UserNameEntry")]
        public IWebElement TxtUserName { get; private set; }

        [FindsBy(How = How.Id, Using = "UserPasswordEntry")]
        public IWebElement TxtPassword { get; private set; }

        [FindsBy(How = How.Id, Using = "SchoolNameEntry")]
        public IWebElement TxtSchool { get; private set; }

        [FindsBy(How = How.Id, Using = "cmdLoginButton")]
        public IWebElement BtnLogin { get; private set; }
        #endregion

        /// <summary>
        /// Method used to navigate to some portal
        /// </summary>
        /// <param name="portal"></param>
        public void GoToOdysseyPortal(string portal)
        {
            GoToSite(DataAccess.GetEnvironmentURL(portal));
        }
        /// <summary>
        /// Click on Login Button
        /// </summary>
        /// <returns>OdysseyLoginPage</returns>
        public OdysseyLoginPage ClickLogin()
        {
            Click(BtnLogin);
            return this;
        }

        /// <summary>
        /// Method used to complete username input in Odyssey Login Page
        /// </summary>
        /// <param name="Username"></param>
        public void EnterUserName(string Username)
        {
            WaitHandler.WaitForElementToBeVisible(driver, TxtUserName, "TxtUserName", "OdysseyLoginPage");
            TypeText(TxtUserName,Username);
        }
        /// <summary>
        /// Method used to complete password input in Odyssey Login Page
        /// </summary>
        /// <param name="password"></param>
        public void EnterPassword(string password)
        {
            TypeText(TxtPassword, password);
        }
        /// <summary>
        /// Method used to complete school input in Odyssey Login Page
        /// </summary>
        /// <param name="school"></param>
        public void EnterSchool(string school)
        {
            TypeText(TxtSchool,school);
        }

        /// <summary>
        /// Method used to proceed to login a user in Odyssey Page. 
        /// This process return a WelcomePage
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>OdysseyStudentWelcomePage</returns>
        public OdysseyStudentWelcomePage Login(string username)
        {
            EnterUserName(username);
            EnterPassword("x");
            EnterSchool("qa");

            ClickLogin();
            UserLoggedPopUp.CloseIfIsShowedPopUpOpenedSession();
            return new OdysseyStudentWelcomePage();
        }
        public OdysseyTeacherWelcomePage LoginTeacher(string username)
        {
            EnterUserName(username);
            EnterPassword("x");
            EnterSchool("qa");

            ClickLogin();
            UserLoggedPopUp.CloseIfIsShowedPopUpOpenedSession();
            return new OdysseyTeacherWelcomePage();
        }
        /// <summary>
        /// Method used to validate if Odyssey Login Page was loaded
        /// </summary>
        /// <returns>bool</returns>
        public bool IsLoad()
        {
            WaitHandler.WaitForElementToBeVisible(driver, BtnLogin, "Login Button", "OdysseyLoginPage");
            return BtnLogin.Displayed;
        }
        
    }
}
