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
        public static ChromeDriver Driver;

        [BeforeScenario]
        public static void BeforeScenario()
        {
            try
            {
                Driver = new ChromeDriver();
                WaitforElement.Wait();

            }
            catch (Exception)
            {

                throw;
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Dispose();
        }
    }
}

