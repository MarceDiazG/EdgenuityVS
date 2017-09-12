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

namespace WebPages.Compass
{
    public class CompassLearningLoginPage:BasePage
    {
        /// <summary>
        /// Default constructor for CompassLearningLoginPage
        /// </summary>
        public CompassLearningLoginPage() { }

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
        public void GoToCompassLearningPortal(string portal)
        {
            GoToSite(DataAccess.getEnvironmentURL(portal));
        }
        /// <summary>
        /// Click on Login Button
        /// </summary>
        /// <returns></returns>
        public CompassLearningLoginPage ClickLogin()
        {
            BtnLogin.Click();
            return this;
        }

        /// <summary>
        /// Method used to complete username input in Compass Learning Login Page
        /// </summary>
        /// <param name="Username"></param>
        public void EnterUserName(string Username)
        {
            //Wait until the element is clickable/visible or use the findelement inside the method
            IWebElement txt = driver.FindElement(By.Id("UserNameEntry"));
            txt.SendKeys(Username);
        }
        /// <summary>
        /// Method used to complete password input in CompassLearning Login Page
        /// </summary>
        /// <param name="password"></param>
        public void EnterPassword(string password)
        {
            TxtPassword.SendKeys(password);
        }
        /// <summary>
        /// Method used to complete school input in CompassLearning Login Page
        /// </summary>
        /// <param name="school"></param>
        public void EnterSchool(string school)
        {
            TxtSchool.SendKeys(school);
        }

        /// <summary>
        /// Method used to proceed to login a user in CompassLearning Page. 
        /// This process return a WelcomePage
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>StudentCompassWelcomePage</returns>
        public StudentCompassWelcomePage Login(string username)
        {
            EnterUserName(username);
            EnterPassword("x");
            EnterSchool("qa");
            ClickLogin();
            UserLoggedPopUp.CloseIfIsShowedPopUpOpenedSession();
            return new StudentCompassWelcomePage();
        }
    }
}
