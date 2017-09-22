using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Pages.Waits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pages.Waits;
using EdgeWebDriver.Log;

namespace WebPages.Odyssey
{
    public class OdysseyStudentWelcomePage : BasePage
    {
        private const int V = 15;

        /// <summary>
        /// Default constructor for OdysseyStudentWelcomePage
        /// </summary>
        public OdysseyStudentWelcomePage() { }

        #region WebElements

        [FindsBy(How = How.Id, Using = "welcome")]
        public IWebElement WelcomeDiv { get; private set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='logout']")]
        public IWebElement LinkSignOut { get; private set; }

        [FindsBy(How = How.Id, Using = "form1")]
        public IWebElement MainForm { get; private set; }
        #endregion

        /// <summary>
        /// Method to switch to the new opened window, after the login
        /// </summary>
        /// <returns>bool</returns>
        public bool SwitchToNewOpenedWindow() {

            driver.SwitchTo().Window(driver.WindowHandles.Last());

            driver.SwitchTo().Frame("CLOMain");
            Console.WriteLine("------->Switch successfully to iFrame!");

            IWebElement logout = driver.FindElement(By.XPath("//a[@class='logout']"));
            Console.WriteLine("------->Located Logout button!");
            return logout.Displayed;

        }
        
        /// <summary>
        /// Method used to click on logout button
        /// </summary>
        public void LogoutSession() {
            IWebElement logout = driver.FindElement(By.XPath("//a[@class='logout']"));
            logout.Click();
        }

        /// <summary>
        /// This method maps the behaviour of the page, after click on logout
        /// providing a new instance of Odyssey Login Page
        /// </summary>
        /// <returns>OdysseyLoginPage</returns>
        public OdysseyLoginPage BackToLoginOdysseyLoginPage() {
            driver.SwitchTo().DefaultContent();
            return new OdysseyLoginPage();

        }

        /// <summary>
        /// Method used to check if Odyssey Welcome Page was loaded 
        /// </summary>
        /// <returns>bool</returns>
        public bool IsLoad()
        {
            IWebElement logout = driver.FindElement(By.XPath("//a[@class='logout']"));
            return logout.Displayed;
        }
        public void elementHighlight(IWebElement element)
        {
            for (int i = 0; i < 2; i++)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].style.border='3px groove green'", element);
            }
        }
       
    }
}