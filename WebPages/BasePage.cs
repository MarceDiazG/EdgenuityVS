using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Firefox;
using EdgeWebDriver;
using OpenQA.Selenium.Support.PageObjects;
using Pages.Waits;
using EdgeWebDriver.Log;
using OpenQA.Selenium.Support.UI;

namespace WebPages
{
    public abstract class BasePage    {
        protected static IWebDriver driver;

        protected BasePage(){
            driver = Driver.Get();
            PageFactory.InitElements(driver, this);
        }

        public void GoToSite(string WebUrl){
            Driver.Get().Navigate().GoToUrl(WebUrl);
        }


        /// <summary>
        /// Can be used to perform Assertions 
        /// </summary>
        /// <param name="element">Validates if the element is displayed</param>
        /// <returns>'true' if element is displayed else 'false'</returns>
        public bool IsElementDisplayed(IWebElement element)
        {
            WaitHandler.WaitForElementToBeVisible(driver, element, "", "");
            return (element.Displayed);
        }



        /// <summary>
        /// This function enter text in the specified element.
        /// 1. Clear the field
        /// 2. Send keys (Text) to the web element
        /// </summary>
        /// <param name="element"> Element to enter text into </param>
        /// <param name="text">Text to enter in element </param>
        public void TypeText(IWebElement element, String text)
        {
            WaitHandler.WaitForElementToBeVisible(driver, element, "", "");
            try
            {
                element.Clear();
                element.SendKeys(text);
                LogHandler.Debug("TypeText::The text " + text + " has been entered in InputBox with value: " + text);
            }
            catch (Exception e)
            {
                LogHandler.Error("TypeText::NoSuchElementException - " + e.Message);
                throw new NoSuchElementException("TypeText::Exception - " + e.Message);
            }
        }


        /// <summary>
        /// This function perform Click operation on the specified element. 
        /// </summary>
        /// <param name="element">IWebElement</param>
        public void Click(IWebElement element)
        {
            WaitHandler.WaitForElementClickeable(driver, element, "", "");
            try
            {
                element.Click();
                LogHandler.Debug("Click::The element has been clicked");
            }
            catch (Exception e)
            {
                LogHandler.Error("Click::Exception - " + e.Message);
                throw new NoSuchElementException("Click::Exception - " + e.Message);
            }
            WaitHandler.WaitForAjaxToComplete(driver);
        }



        /// <summary>
        /// Performs a  Double Click operation on the specified element. 
        /// </summary>
        /// <param name="eLocator"> String for element to locate </param>
        /// <param name="eType">Option for selection such as id / Xpath /..etc </param>
        public void DoubleClick(IWebElement element,String elementName)
        {
            WaitHandler.WaitForElementClickeable(driver, element, "", "");
            try
            {
                new Actions(driver).DoubleClick(element).Perform();
                LogHandler.Debug("DoubleClick::The element "+ elementName+" has been double clicked");
            }
            catch (Exception e)
            {
                LogHandler.Error("DoubleClick::Exception for element "+elementName+" - " + e.Message);
                throw new NoSuchElementException("DoubleClick::Exception - " + e.Message);
            }
        }



        /// <summary>
        /// Selects value from element using specified text
        /// </summary>
        /// <param name="element"> Element to locate on web page</param>
        /// <param name="text">Text value for selection</param>
        public void SelectByText(IWebElement element, String text, String elementName)
        {
            WaitHandler.WaitForElementToBeVisible(driver, element, "", "");
            try
            {
                SelectElement select = new SelectElement(element);
                select.SelectByText(text);
                LogHandler.Debug("SelectByText::The element '" + elementName + "' select option has been selected by Text: " + text);
            }
            catch (Exception e)
            {
                LogHandler.Error("SelectByText::The element '" + elementName + "' - " + "NoSuchElementException - " + e.Message);
                throw new NoSuchElementException("SelectByText::Exception - " + e.Message);
            }
        }


        /// <summary>
        /// Selects value from element using specified index.
        /// </summary>
        /// <param name="element"> Element to locate on web page</param>
        /// <param name="index">Index number for selection</param>
        public void SelectByIndex(IWebElement element, int index,String elementName)
        {
            WaitHandler.WaitForElementToBeVisible(driver, element, "", "");
            try
            {
                SelectElement select = new SelectElement(element);
                select.SelectByIndex(index);
                LogHandler.Debug("SelectByIndex::The element '" + elementName + "' select option has been selected by index: " + index);
            }
            catch (Exception e)
            {
                LogHandler.Error("SelectByIndex::The element '" + elementName + "' - " + "NoSuchElementException - " + e.Message);
                throw new NoSuchElementException("SelectByIndex::Exception - " + e.Message);
            }
        }


        /// <summary>
        /// Selects value from element using specified value
        /// </summary>
        /// <param name="locator"> String for element to locate </param>
        /// <param name="type">Option for selection such as id / Xpath /..etc </param>
        /// <param name="elementName">Name of element defined in PageObject</param>
        public void SelectByValue(IWebElement element, String value, String elementName)
        {
            WaitHandler.WaitForElementToBeVisible(driver, element, "", "");
            try
            {
                SelectElement select = new SelectElement(element);
                IWebElement sdsd = select.SelectedOption;
                select.SelectByValue(value);
                LogHandler.Debug("SelectByValue::The element '" + elementName + "' select option has been selected by value: " + value);
            }
            catch (Exception e)
            {
                LogHandler.Error("SelectByValue::The element '" + elementName + "' - " + "NoSuchElementException - " + e.Message);
                throw new NoSuchElementException("SelectByValue::Exception - " + e.Message);
            }
        }

    }
}
