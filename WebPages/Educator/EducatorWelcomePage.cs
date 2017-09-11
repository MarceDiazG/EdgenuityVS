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

            CloseIfIsShowedPopUpOpenedSession();
         
            bool labelIsPresent = EHeader.LabelLoggedUser.Displayed;
            bool navigationIsPresent = EHeader.NavigationPanel.Displayed;
            Console.WriteLine("Elements are present?: "+labelIsPresent+"/"+navigationIsPresent);
            return labelIsPresent && navigationIsPresent;
        }
        public static bool CloseIfIsShowedPopUpOpenedSession(){
            try {
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
