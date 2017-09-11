using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdgeWebDriver;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using EdgeWebDriver.Environment;
using DB_Layer;

namespace WebPages {
    public class EducatorLoginPage : BasePage {
        
        /// <summary>
        /// Default constructor for EducatorLoginPage
        /// </summary>
        public EducatorLoginPage() {
        }

        #region WebElements
        [FindsBy(How = How.Id, Using = "LoginUsername")]
        public IWebElement TxtUserName { get; private set; }

        [FindsBy(How = How.Id, Using = "LoginPassword")]
        public IWebElement TxtPassword { get; private set; }

        [FindsBy(How = How.Id, Using = "LoginSubmit")]
        public IWebElement BtnLogin { get; private set; }
        #endregion

        public void GoToEducatorPortal(string portal){
            GoToSite(DataAccess.getEnvironmentURL(portal));
        }

        /// <summary>
        /// Click on Login Button
        /// </summary>
        /// <returns></returns>
        public EducatorLoginPage ClickLogin()
        {
            BtnLogin.Click();
            return this;
        }


        public void EnterUserName(string Username)
        {
            IWebElement txt = driver.FindElement(By.Id("LoginUsername"));
            txt.SendKeys(Username);
        }

        public void EnterPassword(string password)
        {
            TxtPassword.SendKeys(password);
        }


        public EducatorWelcomePage Login(string username, string password)
        {
            Console.WriteLine("USername: "+username+"; Password: "+password);
            EnterUserName(username);
            EnterPassword(password);
            ClickLogin();
            return new EducatorWelcomePage();
        }


    }
}