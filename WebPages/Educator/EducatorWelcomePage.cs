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
        [FindsBy(How = How.ClassName, Using = "userLoggedIn")]
        public IWebElement LabelLoggedUser { get; private set; }

        [FindsBy(How = How.Id, Using = "nav")]
        public IWebElement NavigationPanel { get; private set; }
        #endregion

        public bool IsLoad() {
            bool labelIsPresent = LabelLoggedUser.Displayed;
            bool navigationIsPresent = NavigationPanel.Displayed;
            Console.WriteLine("Elements are present?: "+labelIsPresent+"/"+navigationIsPresent);
            return labelIsPresent && navigationIsPresent;
        }
    }
}
