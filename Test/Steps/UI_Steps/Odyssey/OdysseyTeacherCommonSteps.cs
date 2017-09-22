using System;
using TechTalk.SpecFlow;
using DB_Layer;
using WebPages.Odyssey;
using log4net;
using log4net.Config;
using FluentAssertions;

namespace Test.Steps.UI_Steps.Odyssey
{
    [Binding]
    public class OdysseyTeacheCommonrSteps
    {
        OdysseyLoginPage odysseyLoginPage;
        OdysseyTeacherWelcomePage odysseyTeacherWelcomePage;

        [Given(@"Login into (.*), Odissey Portal as Educator using (.*)")]
        public void GivenLoginIntoOdisseyPortal(string portal, string username)
        {
            odysseyLoginPage = new OdysseyLoginPage();
            odysseyLoginPage.GoToOdysseyPortal(portal);
            odysseyTeacherWelcomePage = odysseyLoginPage.LoginTeacher(username);
        }
        
        [When(@"Select My Students")]
        public void WhenSelectMyStudents()
        {
            bool theBoolean = true;

            //Check that My Students is displayed and can load welcome panel
            theBoolean.Should().Be(
            odysseyTeacherWelcomePage.SelectMyStudentsOnTopPanel());
        }
        
        [When(@"Add a new class")]
        public void WhenAddANewClass()
        {
            odysseyTeacherWelcomePage.AddNewClassToTeacher();
        }
        
        [Then(@"Verify the Class table is populated with the new class")]
        public void ThenVerifyTheClassTableIsPopulatedWithTheNewClass()
        {
            Console.WriteLine("The result is: " +
            odysseyTeacherWelcomePage.ValidateNewClass());

            odysseyTeacherWelcomePage.DeleteClassAdded();
        }
    }
}
