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
        [BeforeScenario]
        public void SetUp()
        {
            Driver.Initialize(BrowserType.Firefox);
        }

        [AfterScenario]
        public void TearDown()
        {
            Driver.Close();
        }

    }
}
