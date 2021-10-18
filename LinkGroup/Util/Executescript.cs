using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkGroup.Util
{
    public static class Executescript
    {
        public static void JavascriptexecutorCoordinate()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Hooks.driver;
            js.ExecuteScript("window.scrollBy(0, 300)");
        }
    }
}
