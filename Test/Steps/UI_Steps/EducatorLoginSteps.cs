using System;
using TechTalk.SpecFlow;
using WebPages;
using FluentAssertions;
using DB_Layer;

namespace Test.Steps.UI_Steps
{
    [Binding]
    public class EducatorLoginSteps
    {
        EducatorLoginPage loginPage;
        EducatorWelcomePage welcomePage;

        [Given(@"Going to (.*) Portal")]
        public void GivenGoingToEducatorPortal(string portal)
        {
            Console.WriteLine("+++++ > portal");
            Console.WriteLine("My data:" + DataAccess.GetEducatorUsername("marcelo"));
            loginPage = new EducatorLoginPage();
                //PageFactoryHelper.GetPage<LoginPage>();
            loginPage.GoToEducatorPortal(portal);
        }
        
        [When(@"Login with (.*) and (.*) credentials")]
        public void WhenLoginWithUsernameAndPassword(string username, string password)
        {
            Console.WriteLine("******> When ");
            welcomePage= loginPage.Login(username, password);
        }
        
        [Then(@"validate that the user was successfully logged")]
        public void ThenValidateThatTheUserWasSuccessfullyLogged()
        {
            bool theBoolean = true;
            theBoolean.Should().Be(welcomePage.IsLoad());
            Console.WriteLine("******> Then ");
            //ScenarioContext.Current.Pending();
        }
    }
}
