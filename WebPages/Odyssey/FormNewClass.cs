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
    internal class FormNewClass : BasePage {

        /// <summary>
        /// Default constructor for FormNewClass
        /// </summary>
        public FormNewClass() {
            PageFactory.InitElements(driver, this);
        }

        #region WebElements
        [FindsBy(How = How.Id, Using = "aspnetForm")]
        public IWebElement FormNewTeacher { get; private set; }

        [FindsBy(How = How.Id, Using = "ctl00_cph1_Wizard1_ClassName")]
        public IWebElement InputNewClassName { get; private set; }

        [FindsBy(How = How.Id, Using = "ctl00_cph1_Wizard1_GradeLevelList")]
        public IWebElement SelectGradeLevel { get; private set; }

        [FindsBy(How = How.Id, Using = "ctl00_cph1_Wizard1_SubjectList")]
        public IWebElement SelectSubject { get; private set; }

        [FindsBy(How = How.Id, Using = "ctl00_cph1_Wizard1_FinishNavigationTemplateContainerID_FinishButton")]
        public IWebElement SaveButton { get; private set; }

        [FindsBy(How = How.Id, Using = "cancelDialogBtn")]
        public IWebElement CancelButton { get; private set; }
        
        #endregion

        /// <summary>
        /// Method used to complete the form 'add New Class', and click on 'Save' or 'Cancel'
        /// button according to parameter 'save'
        /// </summary>
        /// <param name="className"></param>
        /// <param name="gradeLevel"></param>
        /// <param name="subject"></param>
        /// <param name="save"></param>
        public void CompleteFormNewClass(string className, string gradeLevel, string subject, bool save) {
            
            LogHandler.Info("====>>> Going to complete New Class form.... !!!!");

            TypeText(InputNewClassName,className);
            SelectByText(SelectGradeLevel, gradeLevel, "Select Grade Level");
            SelectByText(SelectSubject, subject, "Select Subject");

            if (save)
            {
                Click(SaveButton);
            }
            else
            {
                Click(CancelButton);
            }
        }
    }
}
