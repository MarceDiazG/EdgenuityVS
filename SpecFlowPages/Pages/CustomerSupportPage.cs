using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecFlowPages;
using System;

namespace SpecFlowPages.Pages
{
    public class CustomerSupportPage {

        public static void ClickSpecflowPlus()
        {
            var action = new Actions(Driver.Instance);
            var goToSupportButton = Driver.Instance.FindElement(By.XPath("(//a[@class='btn btn-orange p-x-3 m-x-2'])[1]"));
            var goToContactButton = Driver.Instance.FindElement(By.XPath("//li[@id='contact']//a"));
            Console.WriteLine("goToSupportButton: "+ goToSupportButton.Displayed);
            //div[@id='homepage-header-contain']//div[@id='homepage-hero-content']/div/a[contains(text(), 'Support')]"));
            //goToSupportButton.Click();
            goToContactButton.Click();
        }

        public static void ClickSpecflowPlusExcel() {
            var specFlowPlusExcelButton = Driver.Instance.FindElement(By.XPath(".//*[@id='menu-item-698']/a"));
            specFlowPlusExcelButton.Click();
        }

        public static bool isLoad(){
            Driver.Instance.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(30));
            return Driver.Instance.FindElement(By.XPath("//h1[contains(text(), 'Technical + Customer Support')]")).Displayed;
        }
    }
}
