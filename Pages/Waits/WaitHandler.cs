using System;
using System.Collections.Generic;
using EdgeWebDriver.Log;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace Pages.Waits
{
    /// <summary>
    /// WaitHandler provides a set of explicit waits operation for handling page and web element synchronization.
    /// </summary>
    public class WaitHandler
    {

        /// <summary>
        /// Waits for JQuery Ajax to Complete.
        /// </summary>
        /// <param name="driver">the <see cref="IWebDriver"/></param>
        public static void WaitForAjaxToComplete(IWebDriver driver)
        {
            bool ajaxIsPresent = true;
            String js = "return jQuery.active == 0";
            try
            {
                (driver as IJavaScriptExecutor).ExecuteScript(js);
            }
            catch (Exception)
            {
                // Could fail due to AJAX is not present on the page.
                LogHandler.Error("WaitForAjaxToComplete::AJAX is not present on this section.");
                ajaxIsPresent = false;
            }

            // AJAX could take a while for be loaded, use explicit wait.
            if (ajaxIsPresent)
            {
                try
                {
                    WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                    webDriverWait.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript(js));
                }
                catch (Exception e)
                {
                    LogHandler.Error("WaitForAjaxToComplete::Exception - " + e.Message);
                }
            }
        }

        /// <summary>
        /// Waits for an element to be visible on the page.
        /// It uses ExpectedConditions.VisibilityOfAllElementsLocatedBy(elements)
        /// </summary>
        /// <param name="driver">the <see cref="IWebDriver"/></param>
        /// <param name="element">the web element</param>
        /// <param name="elementName">the element name</param>
        /// <param name="page">the page name</param>
        public static void WaitForElementToBeVisible(IWebDriver driver, IWebElement element, String elementName, String page)
        {
            List<IWebElement> elementList = new List<IWebElement>();
            elementList.Add(element);
            ReadOnlyCollection<IWebElement> elements = new ReadOnlyCollection<IWebElement>(elementList);
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(elements));
                LogHandler.Info("WaitForElementToBeVisible::The element " + elementName + " is visible on the page " + page);
            }
            catch (Exception e)
            {
                LogHandler.Error("WaitForElementToBeVisible::Exception - " + e.Message);
                throw new NoSuchElementException("WaitForElementToBeVisible::The element " + elementName + " is not visible on the page " + page + e.Message);
            }
        }

        /// <summary>
        /// Waits for an element to be visible on the page.
        /// It uses ExpectedConditions.VisibilityOfAllElementsLocatedBy(elements)
        /// </summary>
        /// <param name="driver">the <see cref="IWebDriver"/></param>
        /// <param name="by">the web element locator</param>
        /// <param name="elementName">the element name</param>
        /// <param name="page">the page name</param>
        public static void WaitForElementToBeVisible(IWebDriver driver, By by, String elementName, String page)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
                LogHandler.Info("WaitForElementToBeVisible::The element " + elementName + " located by is visible on the page " + page);
            }
            catch (Exception e)
            {
                LogHandler.Error("WaitForElementToBeVisible::Exception - " + e.Message);
                throw new NoSuchElementException("WaitForElementToBeVisible::The element " + elementName + " is not visible on the page " + page);
            }
        }

        /// <summary>
        ///  Waits for a set of elements to be visible on the page.
        /// It uses ExpectedConditions.VisibilityOfAllElementsLocatedBy(elements)
        /// </summary>
        /// <param name="driver">the <see cref="IWebDriver"/></param>
        /// <param name="elements">the web elements</param>
        /// <param name="page">the page name</param>
        public static void WaitForElementsToBeVisible(IWebDriver driver, IList<IWebElement> elements, String page)
        {
            ReadOnlyCollection<IWebElement> elementsReadOnlyCollection = new ReadOnlyCollection<IWebElement>(elements);
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(elementsReadOnlyCollection));
                LogHandler.Info("WaitForElementsToBeVisible::The elements are visible on the page " + page);
            }
            catch (Exception e)
            {
                LogHandler.Error("WaitForElementsToBeVisible::Exception - " + e.Message);
                throw new NoSuchElementException("WaitForElementToBeVisible::The elements are not visible on the page " + page);
            }
        }

        /// <summary>
        ///  Waits for staleness of an element on the page.
        /// It uses ExpectedConditions.StalenessOf(element)
        /// </summary>
        /// <param name="driver">the <see cref="IWebDriver"/></param>
        /// <param name="element">the web element</param>
        /// <param name="elementName">the element name</param>
        /// <param name="page">the page name</param>
        public static void WaitForElementToStaleness(IWebDriver driver, IWebElement element, String elementName, String page)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.StalenessOf(element));
                LogHandler.Info("WaitForElementToStaleness::The element " + elementName + " is not longer attached in the DOM on the page " + page);
            }
            catch (Exception e)
            {
                LogHandler.Error("WaitForElementToStaleness::Exception - " + e.Message);
                throw new NoSuchElementException("WaitForElementToStaleness::The element " + elementName + " is still attached in the DOM on the page " + page);
            }
        }


        /// <summary>
        /// Waits for text to be present in the web element. 
        /// </summary>
        /// <param name="driver">the <see cref="IWebDriver"/></param>
        /// <param name="element">the web element</param>
        /// <param name="expectedText">the expected text</param>
        /// <param name="elementName">the element name</param>
        /// <param name="page">the page name</param>
        public static void WaitForTextToBePresent(IWebDriver driver, IWebElement element, String expectedText, String elementName, String page)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.TextToBePresentInElement(element, expectedText));
                LogHandler.Info("WaitForTextToBePresent:: The text: '" + expectedText + "' is present in the element " + elementName + " on the page " + page);
            }
            catch (Exception e)
            {
                LogHandler.Error("WaitForTextToBePresent::Exception - " + e.Message);
                throw new NoSuchElementException("WaitForTextToBePresent::The text " + expectedText + " is not present in the element " + elementName + " on the page " + page);
            }
        }

        /// <summary>
        /// Waits for text to be present in the web element attribute value.
        /// </summary>
        /// <param name="driver">the <see cref="IWebDriver"/></param>
        /// <param name="element">the web element</param>
        /// <param name="expectedText">the expected text</param>
        /// <param name="elementName">the element name</param>
        /// <param name="page">the page name</param>
        public static void WaitForTextToBePresentInValue(IWebDriver driver, IWebElement element, String expectedText, String elementName, String page)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.TextToBePresentInElementValue(element, expectedText));
                LogHandler.Info("WaitForTextToBePresentInValue:: The text: " + expectedText + " is not present in the element " + elementName + " on the page " + page);
            }
            catch (Exception e)
            {
                LogHandler.Error("WaitForTextToBePresentInValue::Exception - " + e.Message);
                throw new NoSuchElementException("WaitForTextToBePresentInValue::The text " + expectedText + " is not present in the element " + elementName + " on the page " + page);
            }
        }

        /// <summary>Rahul
        /// Waits for element to be invisiable.
        /// </summary>
        /// <param name="driver">the <see cref="IWebDriver"/></param>
        /// <param name="locaotor">the element located by property</param>
        /// <param name="locaotorName">the element locatated by the Propery Name</param>
        /// <param name="expectedText">the expected text</param>
        /// <param name="elementName">the element name</param>
        /// <param name="page">the page name</param>
        public static void WaitForElememntTobeInvisiable(IWebDriver driver, String locatorName, String locator, String elementName, String page)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                switch (locatorName)
                {
                    case "Name":
                        wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Name(locator)));
                        break;
                    case "Id":
                        wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id(locator)));
                        break;
                    case "LinkText":
                        wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.LinkText(locator)));
                        break;
                    case "XPath":
                        wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(locator)));
                        break;
                }
            }
            catch (Exception e)
            {
                throw new NoSuchElementException("WaitForElememntTobeInvisiable::The element " + elementName + " is not present on the page " + page);
            }
        }

        /// <summary>
        /// Waits for an element to be clickeable on the page.
        /// </summary>
        /// <param name="driver">the <see cref="IWebDriver"/></param>
        /// <param name="element">the web element</param>
        /// <param name="elementName">the element name</param>
        /// <param name="page">the page name</param>
        public static void WaitForElementClickeable(IWebDriver driver, IWebElement element, String elementName, String page)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
                LogHandler.Info("WaitForElementClickeable:: The element " + elementName + " is clickeable on the page " + page);
            }
            catch (Exception e)
            {
                LogHandler.Error("WaitForElementClickeable::Exception - " + e.Message);
                throw new NoSuchElementException("WaitForElementClickeable::The element  " + elementName + " is not clickable on the page " + page);
            }
        }

        /// <summary>
        /// Waits for an element to be selected on the page.
        /// </summary>
        /// <param name="driver">the <see cref="IWebDriver"/></param>
        /// <param name="element">the web element</param>
        /// <param name="elementName">the element name</param>
        /// <param name="page">the page name</param>
        public static void WaitForElementToBeSelected(IWebDriver driver, IWebElement element, String elementName, String page)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementToBeSelected(element));
                LogHandler.Info("WaitForElementToBeSelected:: The element " + elementName + " is selected on the page " + page);
            }
            catch (Exception e)
            {
                LogHandler.Error("WaitForElementToBeSelected::Exception - " + e.Message);
                throw new NoSuchElementException("WaitForElementToBeSelected::The element  " + elementName + " is not selected on the page " + page);
            }
        }

        /// <summary>
        /// Waits for title to be present on the page.
        /// </summary>
        /// <param name="driver">the <see cref="IWebDriver"/></param>
        /// <param name="title">the title</param>
        /// <param name="page">the page name</param>
        public static void WaitForTitle(IWebDriver driver, String title, String page)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.TitleIs(title));
                LogHandler.Info("WaitForTitle:: The title " + title + " is present on the page " + page);
            }
            catch (Exception e)
            {
                LogHandler.Error("WaitForTitle::Exception - " + e.Message);
                throw new NoSuchElementException("WaitForTitle::The title  " + title + " is not present on the page " + page);
            }
        }

        /// <summary>
        /// Waits for an alert to be preset on the page.
        /// </summary>
        /// <param name="driver">the <see cref="IWebDriver"/></param>
        /// <param name="page">the page name</param>
        public static void WaitForAlert(IWebDriver driver, String page)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.AlertIsPresent());
                LogHandler.Info("WaitForAlert:: The alert is present on the page " + page);
            }
            catch (Exception e)
            {
                LogHandler.Error("WaitForAlert::Exception - " + e.Message);
                throw new NoSuchElementException("WaitForAlert::The alert is not present on the page " + page);
            }
        }

        /// <summary>
        /// Waits for an element to be enabled on the page.
        /// It uses ExpectedConditions.WaitForElementUntilCondition
        /// </summary>
        /// <param name="driver">the <see cref="IWebDriver"/></param>
        /// <param name="element">the web element</param>
        /// <param name="elementName">the element name</param>
        /// <param name="page">the page name</param>
        public static void WaitForElementToBeEnabled(IWebDriver driver, IWebElement element, String elementName, String page)
        {
            try
            {
                Func<IWebDriver, Boolean> condition = delegate (IWebDriver d) { return element.Enabled == true; };
                WaitHandler.WaitForElementUntilCondition(driver, condition, page);
                LogHandler.Info("WaitForElementToBeEnabled::The element " + elementName + " is enabled on the page " + page);
            }
            catch (Exception e)
            {
                LogHandler.Error("WaitForElementToBeEnabled::Exception - " + e.Message);
                throw new NoSuchElementException("WaitForElementToBeEnabled::The element " + elementName + " is not enabled on the page " + page);
            }
        }

        /// <summary>
        /// Waits for element until condition.
        /// </summary>
        /// <param name="driver">the <see cref="IWebDriver"/></param>
        /// <param name="condition">the condition</param>
        /// <param name="page">the page name</param>
        public static void WaitForElementUntilCondition(IWebDriver driver, Func<IWebDriver, Boolean> condition, String page)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(condition);
                LogHandler.Info("WaitElementUntilCondition:: The condition is valid for the page " + page);
            }
            catch (Exception e)
            {
                LogHandler.Error("WaitElementUntilCondition::Exception - " + e.Message);
                throw new NoSuchElementException("WaitElementUntilCondition::The condition is not valid for the page -" + e.Message);
            }
        }

        /// <summary>
        /// Waits for an element (dropdownlist) to be populated with values.
        /// </summary>
        /// <param name="driver">the <see cref="IWebDriver"/></param>
        /// <param name="element">the web element</param>
        /// <param name="elementName">the element name</param>
        /// <param name="page">the page name</param>
        public static void WaitForElementToBePopulatedWithValues(IWebDriver driver, IWebElement element, String elementName, String page)
        {
            WaitForElementToBeVisible(driver, element, elementName, page);
            try
            {
                SelectElement select = new SelectElement(element);
                Func<IWebDriver, Boolean> condition = delegate (IWebDriver d) { return select.Options.Count > 1; };
                WaitHandler.WaitForElementUntilCondition(driver, condition, page);
                LogHandler.Info("WaitForElementToBePopulatedWithValues:: The element " + elementName + " is selected on the page " + page);
            }
            catch (Exception e)
            {
                LogHandler.Error("WaitForElementToBePopulatedWithValues::Exception - " + e.Message);
                throw new NoSuchElementException("WaitForElementToBePopulatedWithValues::The element  " + elementName + " is not selected on the page " + page);
            }
        }

        /// <summary>
        /// Waits for Page to Load.
        /// </summary>
        /// <param name="driver">the <see cref="IWebDriver"/></param>
        public static void WaitForPageToLoad(IWebDriver driver)
        {
            String js = "return document.readyState";
            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                webDriverWait.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript(js));
            }
            catch (Exception e)
            {
                LogHandler.Error("WaitForAjaxToComplete::Exception - " + e.Message);
            }
            WaitForAjaxToComplete(driver);
        }
    }

}
