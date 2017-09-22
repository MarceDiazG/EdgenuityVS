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

namespace WebPages {
    public class StudentLoginPage : BasePage {
        
        /// <summary>
        /// Default constructor for EducatorLoginPage
        /// </summary>
        public StudentLoginPage() {
        }

        #region WebElements
        [FindsBy(How = How.Id, Using = "LoginUsername")]
        public IWebElement TxtUserName { get; private set; }

        [FindsBy(How = How.Id, Using = "LoginPassword")]
        public IWebElement TxtPassword { get; private set; }

        [FindsBy(How = How.Id, Using = "LoginSubmit")]
        public IWebElement BtnLogin { get; private set; }
        #endregion

        public void GoToStudentPortal(string portal){
            GoToSite(DataAccess.GetEnvironmentURL(portal));
        }

        /// <summary>
        /// Click on Login Button
        /// </summary>
        /// <returns></returns>
        public StudentLoginPage ClickLogin()
        {
            BtnLogin.Click();
            return this;
        }

        /// <summary>
        /// Method used to complete username input in Educator Login Page
        /// </summary>
        /// <param name="Username"></param>
        public void EnterUserName(string Username)
        {
            //Wait until the element is clickable/visible or use the findelement inside the method
            IWebElement txt = driver.FindElement(By.Id("LoginUsername"));
            txt.SendKeys(Username);
        }
        /// <summary>
        /// Method used to complete password input in Educator Login Page
        /// </summary>
        /// <param name="password"></param>
        public void EnterPassword(string password)
        {
            TxtPassword.SendKeys(password);
        }

        /// <summary>
        /// Method used to proceed to login a user in Educator Page. 
        /// This process return a WelcomePage
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public StudentWelcomePage Login(string username, string password)
        {
            EnterUserName(username);
            EnterPassword(password);
            ClickLogin();
            CloseIfIsShowedPopUpOpenedSession();
            return new StudentWelcomePage();
        }

        public bool IsLoad(IWebElement element) {
            return element.Displayed;
        }

        public static bool CloseIfIsShowedPopUpOpenedSession()
        {
            try
            {
                IWebElement buttonContinueIsLoggedUser = driver.FindElement(By.Name("continue"));
                buttonContinueIsLoggedUser.Click();
                Console.WriteLine("Closed popup 'Is Logged the user' successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine("The popup 'Is Logged the user' was NOT showed!");
            }
            return true;
        }
    }
}