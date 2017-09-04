using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecFlowPages;
using System;

namespace SpecFlowPages.Pages
{
    public class ContactPage {

        public static void completeFormInvalidData(){
            var action = new Actions(Driver.Instance);
            var titleContact = Driver.Instance.FindElement(By.XPath("//div[@class='container-fluid']//h1[contains(text(), 'Contact Us')]"));
            var firstName = Driver.Instance.FindElement(By.Name("firstname"));
            var lastName = Driver.Instance.FindElement(By.Name("lastname"));
            var email = Driver.Instance.FindElement(By.Name("email"));
            var phone = Driver.Instance.FindElement(By.Name("phone"));
            var jobTitle = Driver.Instance.FindElement(By.Name("title"));
            var school = Driver.Instance.FindElement(By.Name("companyname"));
            var district = Driver.Instance.FindElement(By.Name("custentity89"));
            var state = Driver.Instance.FindElement(By.Name("state"));
            var zipCode = Driver.Instance.FindElement(By.Name("zipcode"));
            var numStudents = Driver.Instance.FindElement(By.Name("singleLineText3"));
            var submitButton = Driver.Instance.FindElement(By.XPath("//form//input[@value='Submit']"));

            //var potato = Driver.Instance.FindElement(By.XPath(".//*[@id='formElement13']/div[2]/div/p"));
            //var elem = potato.FindElement(By.XPath("//input"));

            firstName.SendKeys("Administrator");
            lastName.SendKeys("LastName");
            email.SendKeys("email@gmail.com");
            phone.SendKeys("158654789");
            jobTitle.SendKeys("Daddy");
            school.SendKeys("G. W. School");
            district.SendKeys("Phoenix Dist.");
            zipCode.SendKeys("85005");
            numStudents.SendKeys("2");

            submitButton.Submit();
        }
        public static bool errorStateMsgIsDisplayed() {
            var action = new Actions(Driver.Instance);
            var errorMsg = Driver.Instance.FindElement(By.XPath("//span[contains(text(), 'Please select your State')]"));
            return true; //errorMsg.isDisplayed().value();
        }
        public static bool isLoad(){
            Driver.Instance.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(30));
            return Driver.Instance.FindElement(By.XPath("//h1[contains(text(), 'Contact Us')]")).Displayed;
        }
    }
}
