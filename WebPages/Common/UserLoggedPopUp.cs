using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace WebPages
{
    public class UserLoggedPopUp:BasePage {

        public UserLoggedPopUp()
        {

        }
        #region WebElements
        [FindsBy(How = How.Name, Using = "continue")]
        public IWebElement ButtonContinue { get; private set; }

        [FindsBy(How = How.Name, Using = "return")]
        public IWebElement ButtonCancel { get; private set; }
        #endregion

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