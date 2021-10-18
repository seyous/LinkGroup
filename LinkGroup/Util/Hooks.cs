using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LinkGroup.Util
{
    [Binding]
   public sealed class Hooks
    {
        public static ChromeDriver driver;

        [BeforeScenario]
        public static void BeforeTest()
        {
            try
            {
                driver = new ChromeDriver();
                WaitforElement.wait();

            }
            catch (Exception)
            {

                throw;
            }        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Dispose();
        }
    }
}

