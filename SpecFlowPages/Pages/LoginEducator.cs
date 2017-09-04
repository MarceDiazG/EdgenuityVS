using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Interactions;
using SpecFlowPages;

namespace SpecFlowPages.Pages
{
    public class LoginEducator {

        private IWebElement LoginUsername = null;
        private IWebElement LoginPassword = null;
        private IWebElement LoginSubmit = null;
        
        public static void fillUserName(string usernamne)
        {
            var LoginUsername = Driver.Instance.FindElement(By.Id("LoginUsername"));
            //LoginUsername.wait
            LoginUsername.SendKeys(usernamne);
        }
        public static void fillPassword(string password)
        {
            var LoginPassword = Driver.Instance.FindElement(By.Id("LoginPassword"));
            LoginPassword.SendKeys(password);
        }
        public static void fillFieldsAndSubmit(string username, string password)
        {
            var action = new Actions(Driver.Instance);
            fillUserName(username);
            fillPassword(password);
            var LoginSubmit = Driver.Instance.FindElement(By.Id("LoginSubmit"));
            LoginSubmit.Click();
        }

        /*
        [FindsBy(How = How.Id, Using = "LoginUsername")]
        private IWebElement LoginUsername = null;

        [FindsBy(How = How.Id, Using = "LoginPassword")]
        private IWebElement LoginPassword = null;

        [FindsBy(How = How.Id, Using = "LoginSubmit")]
        private IWebElement LoginSubmit = null;  

       /* [FindsBy(How = How.LinkText, Using = "Small Business")]
        private IWebElement SmallBusinessTab = null;

        [FindsBy(How = How.LinkText, Using = "Enterprise")]
        private IWebElement EnterpriseTab = null;

        [FindsBy(How = How.XPath, Using = "//*[@id='Level1']/li[1]")]
        private IWebElement ProductsDropDown = null;

        [FindsBy(How = How.LinkText, Using = "Special Offers")]
        private IWebElement SpecialOffersLink = null;

        [FindsBy(How = How.LinkText, Using = "Help Center")]
        private IWebElement HelpCenterLink = null;

        [FindsBy(How = How.Id, Using = "CPHLogin_ctl00_ctl00_ctl00_detailContainer")]
        private IWebElement MyServicesDropDown = null;   */
    }
}
