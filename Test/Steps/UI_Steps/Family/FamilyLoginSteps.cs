using System;
using TechTalk.SpecFlow;
using WebPages;
using FluentAssertions;
using WebPages.Family;

namespace Test.Steps.UI_Steps.Family
{
    [Binding]
    public class FamilyLoginSteps
    {
        FamilyLoginPage familyLoginPage;

        [Given(@"Go to QA_Family FamilyPortal")]
        public void GivenGoToQA_FamilyFamilyPortal()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Login using (.*) and (.*) credentials")]
        public void WhenLoginUsingChetanTeachAndChetanCredentials(string username, string password)
        {
            //if 
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"user clicks on signout buttton")]
        public void WhenUserClicksOnSignoutButtton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"validate that the user was successfully logged into Family")]
        public void ThenValidateThatTheUserWasSuccessfullyLoggedIntoFamily()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"validate that user is successfully signed out")]
        public void ThenValidateThatUserIsSuccessfullySignedOut()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
