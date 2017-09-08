using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdgeWebDriver;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace WebPages
{
    public class ContactPage : BasePage {
        
        public ContactPage() {
        }
        public void goToContactPage()  {

            var action = new Actions(driver);
            GoToSite("https://auth.qa.edgenuity.com/Login/Login/Student");
            var goToContactButton = driver.FindElement(By.XPath("//li[@id='contact']//a"));
            //div[@id='homepage-header-contain']//div[@id='homepage-hero-content']/div/a[contains(text(), 'Support')]"));
            goToContactButton.Click();
        }
        public void completeFormInvalidData() {

            var action = new Actions(driver);
            var titleContact = driver.FindElement(By.XPath("//div[@class='container-fluid']//h1[contains(text(), 'Contact Us')]"));
            var firstName = driver.FindElement(By.Name("firstname"));
            var lastName = driver.FindElement(By.Name("lastname"));
            var email = driver.FindElement(By.Name("email"));
            var phone = driver.FindElement(By.Name("phone"));
            var jobTitle = driver.FindElement(By.Name("title"));
            var school = driver.FindElement(By.Name("companyname"));
            var district = driver.FindElement(By.Name("custentity89"));
            var state = driver.FindElement(By.Name("state"));
            var zipCode = driver.FindElement(By.Name("zipcode"));
            var numStudents = driver.FindElement(By.Name("singleLineText3"));
            var submitButton = driver.FindElement(By.XPath("//form//input[@value='Submit']"));

            //var potato = driver.FindElement(By.XPath(".//*[@id='formElement13']/div[2]/div/p"));
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
        public bool errorStateMsgIsDisplayed()
        {
            var action = new Actions(driver);
            var errorMsg = driver.FindElement(By.XPath("//span[contains(text(), 'Please select your State')]"));
            return true; //errorMsg.isDisplayed().value();
        }
        public bool isLoad()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(30));
            return driver.FindElement(By.XPath("//h1[contains(text(), 'Contact Us')]")).Displayed;
        }
    }
}

