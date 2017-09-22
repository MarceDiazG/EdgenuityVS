using System;
using TechTalk.SpecFlow;
using WebPages;
using FluentAssertions;
using DB_Layer;
using WebPages.Odyssey;
using log4net;
using log4net.Config;

namespace Test.Steps.UI_Steps.Odyssey
{
    [Binding]
    public class LoginIntoOdysseyPortalSteps
    {
        OdysseyLoginPage odysseyLoginPage;
        OdysseyStudentWelcomePage odysseyStudentWelcomePage;

        [Given(@"Login into (.*), Odissey Portal")]
        public void GivenGoingToOdysseyLoginPage(string portal)
        {
            odysseyLoginPage = new OdysseyLoginPage();
            odysseyLoginPage.GoToOdysseyPortal(portal);
        }

        [When(@"Complete login form using (.*) as user")]
        public void WhenIPressOnLoginButton(string user)
        {
            odysseyStudentWelcomePage = odysseyLoginPage.Login(user);
        }

        [Then(@"check that the user is logged successfully")]
        public void ThenCheckThatTheUserIsLogged()
        {
            bool theBoolean = true;

            //Check that Logout Button is showed 
            theBoolean.Should().Be(odysseyStudentWelcomePage.SwitchToNewOpenedWindow());

            //Logout current session
            odysseyStudentWelcomePage.LogoutSession();

        }
    }
}
