using System;

namespace AbstractWebPage
{
    public abstract partial class AbstractWebPage
    {   /*
        /// <summary>
        /// The web driver instance holder
        /// </summary>
        private IWebDriver WebDriver;

        /// <summary>
        /// Convenient methods to interact with Keyboard and Mouse in POs
        /// </summary>
        protected Interactions Actions;

        /// <summary>
        /// Convenient methods to ease usage of "waiting" features
        /// </summary>
        protected SynchronizationOperations Synchronization;

        /// <summary>
        /// Base general constructor for Page Objects.
        /// </summary>
        /// <param name="Driver"></param>
        public AbstractWebPage(IWebDriver Driver)
        {
            this.WebDriver = Driver;
            this.Actions = new Interactions(WebDriver);
            this.Synchronization = new SynchronizationOperations(WebDriver);
            PageFactory.InitElements(WebDriver, this);
        }

        /// <summary>
        /// This method allows to instantiate a new Page Object (PO)
        /// to be returned from a PO's method to the test.
        /// 
        /// It is available to all PO, derived from this base class.
        /// </summary>
        /// <typeparam name="T">The Page Object type to instantiate</typeparam>
        /// <returns>An instance of the specified Page Object</returns>
        protected T NewPage<T>() where T : AbstractWebPage
        {
            return (T)WebPage.WebPageActivator.Activate<T>(WebDriver);
        }
        */
    }
}
