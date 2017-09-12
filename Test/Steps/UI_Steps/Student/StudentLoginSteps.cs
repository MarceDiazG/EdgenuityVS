using System;
using TechTalk.SpecFlow;
using WebPages;
using FluentAssertions;

namespace Test.Steps.UI_Steps.Student
{
    [Binding]
    public class StudentLoginSteps
    {
        StudentLoginPage loginPage;
        StudentWelcomePage welcomePage;

        [Given(@"Navigate to (.*) Portal")]
        public void GivenNavigateToQA_StudentPortal(string portal)
        {
           
            loginPage = new StudentLoginPage();
            loginPage.GoToStudentPortal(portal);
        }
        
        [When(@"Login to Student Portal with (.*) and (.*) credentials")]
        public void WhenLoginToStudentPortalWithSunilstudAndSunilCredentials(string username, string password)
        {
            welcomePage = loginPage.Login(username, password);
        }
        
        [When(@"user clicks on signout link on welcome page")]
        public void WhenUserClicksOnSignoutLinkOnWelcomePage()
        {
            loginPage = welcomePage.ClickSignOut();
        }
        
        [Then(@"validate that the user was successfully logged to Portal")]
        public void ThenValidateThatTheUserWasSuccessfullyLoggedToPortal()
        {
            bool theBoolean = true;
            theBoolean.Should().Be(welcomePage.IsLoad());
        }
        
        [Then(@"validate that user is signed out\.")]
        public void ThenValidateThatUserIsSignedOut_()
        {
            loginPage.IsElementDisplayed(loginPage.BtnLogin).Should().Be(true);
        }
        
        [Then(@"Validate that Science section is displayed\.")]
        public void ThenValidateThatScienceSectionIsDisplayed_()
        {
            welcomePage.IsLinkScienceDisplayed().Should().Be(true);
        }
    }
}
