using EdgeWebDriver;
using System;
using TechTalk.SpecFlow;
using Test.Stories;
using WebPages;

namespace Test.Steps
{
    [Binding]
    public class ContactPageSteps : EdgeTestClass
    {  
        [Given(@"an user that visit our landing page")]
        public void GivenAnUserThatVisitOurLandingPage()
        {
            Console.WriteLine("This is the Given !!!!");
            //LoginEducator_XXX
            //LandingPage
            ///PageFactory.getLoginPage()
            ContactPage contactPage = new ContactPage();
            contactPage.goToContactPage();
        }
        
        [When(@"the user clicks on contact button")]
        public void WhenTheUserClicksOnContactButton()
        {
            Console.WriteLine("This is the When !!!!");
        }
        
        [When(@"complete Contact Form")]
        public void WhenCompleteContactForm()
        {
            Console.WriteLine("This is the When 2!!!!");
        }
        
        [Then(@"error message is displayed successfully")]
        public void ThenErrorMessageIsDisplayedSuccessfully()
        {
            Console.WriteLine("This is the Theen !!!!");
        }
    }
}
