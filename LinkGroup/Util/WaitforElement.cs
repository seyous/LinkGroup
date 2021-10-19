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
    public static class WaitforElement
    {
        public static void Wait()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        public static void ImplicitWaitforElement()
        {
            Hooks.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);

        }

    }
}

