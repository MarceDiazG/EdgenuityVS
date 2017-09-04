using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecFlowPages;
using System;

namespace SpecFlowPages.Pages
{
    public class LandinPage {

        public static void goToContactPage()
        {
            var action = new Actions(Driver.Instance);
            var goToContactButton = Driver.Instance.FindElement(By.XPath("//li[@id='contact']//a"));
            //div[@id='homepage-header-contain']//div[@id='homepage-hero-content']/div/a[contains(text(), 'Support')]"));
            goToContactButton.Click();
        }

        public static void completeFormInvalidData()
        {
            throw new NotImplementedException();
        }

        public static void ClickSpecflowPlusExcel() {
            //var specFlowPlusExcelButton = Driver.Instance.FindElement(By.XPath(".//*[@id='menu-item-698']/a"));
            //specFlowPlusExcelButton.Click();
        }

        public static bool isLoad(){
            Driver.Instance.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(30));
            return Driver.Instance.FindElement(By.XPath("//h1[contains(text(), 'Technical + Customer Support')]")).Displayed;
        }
    }
}
