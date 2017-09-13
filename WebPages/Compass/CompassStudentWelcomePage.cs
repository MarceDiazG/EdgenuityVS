using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPages.Compass
{
    public class CompassStudentWelcomePage: BasePage
    {
        public CompassStudentWelcomePage() { }

        #region WebElements
        /*Hi<span>
				<span>Marcelo</span>
			</span>*/
        [FindsBy(How = How.Id, Using = "welcome")]
        public IWebElement WelcomeDiv { get; private set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='logout']")]
        public IWebElement LinkSignOut { get; private set; }

        [FindsBy(How = How.Id, Using = "form1")]
        public IWebElement MainForm { get; private set; }
        #endregion

        public bool SwitchToNewOpenedWindow() {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.SwitchTo().Frame("CLOMain");
            Console.WriteLine("Switch successfully to iFrame!");
            IWebElement logout=driver.FindElement(By.XPath("//a[@class='logout']"));
            Console.WriteLine("Located Logout button!");
            return logout.Displayed;
        }
        public bool IsLoad()
        {
            IWebElement logout = driver.FindElement(By.XPath("//a[@class='logout']"));
            return logout.Displayed;
        }
        public void LogoutSession() {
            IWebElement logout = driver.FindElement(By.XPath("//a[@class='logout']"));
            logout.Click();
        }
        public CompassLearningLoginPage BackToLoginCompassLoginPage() {
            driver.SwitchTo().DefaultContent();
            return new CompassLearningLoginPage();

        }
    }
}