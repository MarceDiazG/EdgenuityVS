using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecFlowPages;
using SpecFlowPages.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowTests
{
    [Binding]
    public class NavigateSpecfFlowExcelSteps : Start
    {        
        [Given(@"an user that visit our landing page")]
        public void GivenTheSpecflowPage()  {
            LandinPage.goToContactPage();
            //NavigateToSpecFlowExcel.ClickSpecflowPlus();
        }
        
        [When(@"the user clicks on support button")]
        public void WhenIPressSpecflow() {
            Assert.IsTrue(
                ContactPage.isLoad(), "This is not Contact Page!");
        }
        
        [When(@"Specflow\+-Excel")]
        public void WhenSpecflow_Excel() {
            ContactPage.completeFormInvalidData();
        }
        
        [Then(@"the support page is displayed successfully")]
        public void ThenIGetStartedNowWithSpecFlowExcelButton() {
            Assert.IsTrue(ContactPage.errorStateMsgIsDisplayed());
        }
    }
}
