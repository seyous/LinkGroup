using LinkGroup.Util;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkGroup.PageObj
{
    public class LinkGroupPage
    {
        private object until;

        IWebElement acceptcoookieButton => Hooks.driver.FindElementByCssSelector("#btnAccept");
        IWebElement searchButton => Hooks.driver.FindElementByCssSelector("#TN-search");

        IWebElement searchBox => Hooks.driver.FindElementByXPath("//form/input['@name=searchTerm']");

        IWebElement searchBoxButton => Hooks.driver.FindElementByXPath("//form/button[contains(text(), Search)]");

        IWebElement searchResult => Hooks.driver.FindElementByXPath("//*[@id='SearchResults']/h3");



        public void Acceptcookie()
        {
            WaitforElement.ImplicitWaitforElement();
            acceptcoookieButton.Click();
        }

        public void Clicksearchbutton()
        {
            Actions actions = new Actions(Hooks.driver);
            actions.MoveToElement(searchButton).Click();
            WaitforElement.ImplicitWaitforElement();
            searchButton.Click();
        }

        public void Entertext(string text)
        {
            WebDriverWait wait = new WebDriverWait(Hooks.driver, TimeSpan.FromSeconds(10)) ;
            wait.Until(ExpectedConditions.ElementToBeClickable(searchButton));
            searchBox.SendKeys(text);
            WaitforElement.ImplicitWaitforElement();
            searchBox.Click();
            searchBoxButton.Click();
         }

        public string Searchtext()
        {
            string result = searchResult.Text.Replace("\r\n\"",  "").Trim(new char[] {'\"'});
            return result;
        }


        
    }
}

