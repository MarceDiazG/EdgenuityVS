using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SpecFlowPages
{
    public class NavigateToSpecFlowExcel
    {
        public static void ClickSpecflowPlus() {
            var action = new Actions(Driver.Instance);
            var goToSupportButton = Driver.Instance.FindElement(By.XPath("//div[@id='homepage-header-contain']//div[@id='homepage-hero-content']/div/a[contains(text(), 'Support')]"));
            System.Console.WriteLine("**************************");
            System.Console.WriteLine(goToSupportButton.ToString());
            goToSupportButton.Click();

        }

        public static void ClickSpecflowPlusExcel()  {
            //var specFlowPlusExcelButton = Driver.Instance.FindElement(By.XPath(".//*[@id='menu-item-698']/a"));
            //specFlowPlusExcelButton.Click();
        }

        public static string GetButtonGetStartedText()
        {
            return Driver.Instance.FindElement(By.XPath(".//*[@id='get-started-now']/a")).Text;
        }
    }
}
