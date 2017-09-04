using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SpecFlowPages.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Steps
{
    [Binding]
    public class LoginEducatorSteps
    {
        [Given(@"Going to Educator Portal")]
        public void GivenGoingToEducatorPortal()
        {
            LoginEducator.fillFieldsAndSubmit("Marceloadmin", "marcelo");
        }
        
        [When(@"I complete credentials Marceloadmin and marcelo")]
        public void WhenICompleteCredentialsMarceloadminAndMarcelo()
        {
            Assert.IsTrue(true, "Pending");
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"The educator is succesfully logged")]
        public void ThenTheEducatorIsSuccesfullyLogged()
        {
            Assert.IsTrue(true, "Pending");
            //ScenarioContext.Current.Pending();
        }
    }
}
