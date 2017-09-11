using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace EdgeWebDriver

{
    public class EdgeTestClass
    {
        /// <summary>
        /// Method to create an instance of the browser, previous to run any scenario
        /// </summary>
        [BeforeScenario]
        public void SetUp()
        {
            Driver.Initialize(Browsers.Firefox);
        }
        /// <summary>
        /// Method used to close any driver session, after the scenario execution
        /// </summary>
        [AfterScenario]
        public void TearDown()
        {
            Driver.Close();
        }

    }
}
