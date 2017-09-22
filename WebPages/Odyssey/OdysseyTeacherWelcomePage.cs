using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Pages.Waits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdgeWebDriver.Log;
using System.Threading;

namespace WebPages.Odyssey
{
    public class OdysseyTeacherWelcomePage: BasePage
    {
        string newClassToAdd;

        /// <summary>
        /// Default constructor for OdysseyTeacherWelcomePage
        /// </summary>
        public OdysseyTeacherWelcomePage() {
            PageFactory.InitElements(driver, this);
        }

        #region WebElements

        string TeacherWelcomePageBaseWindow;
        FormNewClass formNewClass;

        [FindsBy(How = How.Id, Using = "welcome")]
        public IWebElement WelcomeDiv { get; private set; }

        [FindsBy(How = How.Name, Using = "CLOMain")]
        public IWebElement FrameCLOMain { get; private set; }

        [FindsBy(How = How.LinkText, Using = "Log Out")]
        public IWebElement LinkSignOut { get; private set; }

        [FindsBy(How = How.LinkText, Using = "My Students")]
        public IWebElement LinkMyStudents { get; private set; }

        [FindsBy(How = How.Id, Using = "MainSchoolTree1t1")]
        public IWebElement leftPanelMyClassesLink { get; private set; }

        [FindsBy(How = How.Id, Using = "ctl00_cph1_cmdNew")]
        public IWebElement NewElementLink { get; private set; }

        [FindsBy(How = How.Id, Using = "ctl00_cph1_cmdAddClass")]
        public IWebElement AddClassLink { get; private set; }

        [FindsBy(How = How.Id, Using = "welcomeBox")]
        public IWebElement WelcomeBox { get; private set; }

        [FindsBy(How = How.Id, Using = "modalIframeId")]
        public IWebElement FrameNewTeacher { get; private set; }

        [FindsBy(How = How.Id, Using = "subSectionGridTbl")]
        public IWebElement TableClassesAssignedToTeacher { get; private set; }

        [FindsBy(How = How.Id, Using = "idActionsMenu")]
        public IWebElement ActionsMenu { get; private set; }
        
        [FindsBy(How = How.Id, Using = "ctl00_cph1_cmdDelete")]
        public IWebElement DeleteClassButton { get; private set; }

        #endregion

        /// <summary>
        /// Method to switch to the new opened window, after the login
        /// </summary>
        /// <returns>bool</returns>
        public bool SwitchToNewOpenedWindow()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            TeacherWelcomePageBaseWindow = driver.CurrentWindowHandle;

            driver.SwitchTo().Frame(FrameCLOMain);
            Console.WriteLine("------->Switch successfully to iFrame!");

            return IsLoad();

        }

        /// <summary>
        /// Method used to click on logout button
        /// </summary>
        public void LogoutSession()
        {
            WaitHandler.WaitForElementToBeVisible(driver, LinkSignOut, "Logout button", "OdysseyTeacherWelcomePage");
            Click(LinkSignOut);
        }

        /// <summary>
        /// This method maps the behaviour of the page, after click on logout
        /// providing a new instance of Odyssey Login Page
        /// </summary>
        /// <returns>OdysseyLoginPage</returns>
        public OdysseyLoginPage BackToLoginOdysseyLoginPage()
        {
            driver.SwitchTo().DefaultContent();
            return new OdysseyLoginPage();

        }

        /// <summary>
        /// Method used to check if Odyssey Welcome Page was loaded 
        /// </summary>
        /// <returns>bool</returns>
        public bool IsLoad()
        {
            WaitHandler.WaitForElementToBeVisible(driver, LinkSignOut, "Logout button", "OdysseyTeacherWelcomePage");
            return LinkSignOut.Displayed;
        }

        /// <summary>
        /// Method used to select 'My Students' option in top tab panel
        /// </summary>
        /// <returns>bool: true if action was completed; false if not</returns>
        public bool SelectMyStudentsOnTopPanel()
        {
            bool isLoadedOK = SwitchToNewOpenedWindow();

            if (isLoadedOK)
            {
                LogHandler.Info("Welcome Page successfully loaded !!!");
                WaitHandler.WaitForElementToBeVisible(driver, LinkMyStudents, "My Students Link", "OdysseyTeacherWelcomePage");
                Click(LinkMyStudents);

                WaitHandler.WaitForElementToBeVisible(driver, WelcomeBox, "WelcomeBox", "OdysseyTeacherWelcomePage");
                return WelcomeBox.Displayed;
            }
            else
            {
                LogHandler.Error("Welcome Page is not loaded correctly! ");
                return false;
            }
        }

        /// <summary>
        /// Method used to add a new class for logged teacher
        /// </summary>
        public void AddNewClassToTeacher()
        {
            //Select on Left Panel 'My Classes' link
            WaitHandler.WaitForElementToBeVisible(driver, leftPanelMyClassesLink, "My Classes link on left panel", "OdysseyTeacherWelcomePage");
            Click(leftPanelMyClassesLink);

            //Save current window  (B)
            TeacherWelcomePageBaseWindow = driver.CurrentWindowHandle;

            //Click on 'New' link to open options list
            WaitHandler.WaitForElementToBeVisible(driver, NewElementLink, "New Element link", "OdysseyTeacherWelcomePage");
            Click(NewElementLink);

            //Select 'Add new Class' option
            WaitHandler.WaitForElementToBeVisible(driver, AddClassLink, "Add New Class link", "OdysseyTeacherWelcomePage");
            Click(AddClassLink);

            //Change to iFrame showed to complete New Class data
            driver.SwitchTo().Frame(FrameNewTeacher);

            formNewClass = new FormNewClass();
            newClassToAdd = "Our New Class";
            formNewClass.CompleteFormNewClass(newClassToAdd, "First", "Economics", false);

            //Back to previous window (B)
            driver.SwitchTo().ParentFrame();
            driver.SwitchTo().Frame(FrameCLOMain);
        }

        /// <summary>
        /// Method used to validate that new class was added successfully
        /// </summary>
        /// <returns>bool</returns>
        public bool ValidateNewClass()
        {
            //Validate inside of the table if previous class name is present
            WaitHandler.WaitForElementToBeVisible(driver, TableClassesAssignedToTeacher, "Table assigned courses", "OdysseyTeacherWelcomePage");

            IList<IWebElement> tableRow = TableClassesAssignedToTeacher.FindElements(By.TagName("tr"));
            IList<IWebElement> rowTD;
            bool isClassPresent = false;

            foreach (IWebElement row in tableRow)
            {
                rowTD = row.FindElements(By.TagName("td"));
                LogHandler.Debug("rowTD[1].Text: "+ rowTD[1].Text);
                if (rowTD[1].Text.Equals(newClassToAdd))
                {
                    isClassPresent = true;
                }
            }

            return isClassPresent;
        }

        public void DeleteClassAdded()
        {
            //itemCheckFlag
            WaitHandler.WaitForElementToBeVisible(driver, TableClassesAssignedToTeacher, "Table assigned courses", "OdysseyTeacherWelcomePage");

            IList<IWebElement> tableRow = TableClassesAssignedToTeacher.FindElements(By.TagName("tr"));
            IList<IWebElement> rowTD;

            foreach (IWebElement row in tableRow)
            {
                rowTD = row.FindElements(By.TagName("td"));
                LogHandler.Debug("rowTD[1].Text: " + rowTD[1].Text);
                if (rowTD[1].Text.Equals(newClassToAdd))
                {
                    Click(rowTD[0]);
                }
            }
            Thread.Sleep(5000);
            Click(ActionsMenu);
            Click(DeleteClassButton);
            driver.SwitchTo().Alert().Accept();
        }

    }
}
