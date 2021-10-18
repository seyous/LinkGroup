using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LinkGroup.Util
{
  public static  class WaitforElement
    {
        public static IWebElement webElement;

        public static object ExpectedConditions { get; private set; }

        public static void wait()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        public static void ImplicitWaitforElement()
        {
            Hooks.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);

        }

    }
}

