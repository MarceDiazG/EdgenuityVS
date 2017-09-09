﻿using System;
using TechTalk.SpecFlow;
using WebPages;
using FluentAssertions;

namespace Test.Steps.UI_Steps
{
    [Binding]
    public class EducatorLoginSteps
    {
        EducatorLoginPage loginPage;
        EducatorWelcomePage welcomePage;

        [Given(@"Going to Educator Portal")]
        public void GivenGoingToEducatorPortal()
        {
            loginPage = new EducatorLoginPage();
                //PageFactoryHelper.GetPage<LoginPage>();
            loginPage.GoToEducatorPortal();
        }
        
        [When(@"Login with (.*) and (.*)")]
        public void WhenLoginWithUsernameAndPassword(string username, string password)
        {
            Console.WriteLine("******> When ");
            welcomePage= loginPage.Login(username, password);
        }
        
        [Then(@"validate that the user was successfully logged")]
        public void ThenValidateThatTheUserWasSuccessfullyLogged()
        {
            bool theBoolean = true;
            theBoolean.Should().Be(welcomePage.isLoad());
            Console.WriteLine("******> Then ");
            //ScenarioContext.Current.Pending();
        }
    }
}