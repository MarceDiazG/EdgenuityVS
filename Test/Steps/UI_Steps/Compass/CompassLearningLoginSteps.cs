using System;
using TechTalk.SpecFlow;
using WebPages;
using FluentAssertions;
using DB_Layer;
using WebPages.Compass;

namespace Test.Steps.UI_Steps.Compass
{
    [Binding]
    public class LoginIntoCompassLearningPortalSteps
    {
        CompassLearningLoginPage compassLearningLoginPage;
        StudentCompassWelcomePage studentCompassWelcomePage;

        [Given(@"Login into (.*) portal")]
        public void GivenGoingToCompassLoginPage(string portal)
        {
            compassLearningLoginPage = new CompassLearningLoginPage();
            compassLearningLoginPage.GoToCompassLearningPortal(portal);
        }
        
        [When(@"Complete login form using (.*) as username")]
        public void WhenIPressOnLoginButton(string user)
        {
            studentCompassWelcomePage = compassLearningLoginPage.Login(user);
        }
        
        [Then(@"check that the user is logged")]
        public void ThenCheckThatTheUserIsLogged()
        {
            Console.WriteLine("******> Then ");
            bool theBoolean = true;
            theBoolean.Should().Be(studentCompassWelcomePage.IsLoad());
        }
    }
}
