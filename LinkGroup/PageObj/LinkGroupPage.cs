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
        IWebElement acceptcoookieButton => Hooks.Driver.FindElementByCssSelector("#btnAccept");
        IWebElement searchButton => Hooks.Driver.FindElementByCssSelector("#TN-search");

        IWebElement searchBox => Hooks.Driver.FindElementByXPath("//form/input['@name=searchTerm']");

        IWebElement searchBoxButton => Hooks.Driver.FindElementByXPath("//form/button[contains(text(), Search)]");

        IWebElement searchResult => Hooks.Driver.FindElementByXPath("//*[@id='SearchResults']/h3");



        public void AcceptCookie()
        {
            WaitforElement.ImplicitWaitforElement();
            acceptcoookieButton.Click();
        }

        public void ClickSearchButton()
        {
            Actions actions = new Actions(Hooks.Driver);
            actions.MoveToElement(searchButton).Click();
            WaitforElement.ImplicitWaitforElement();
            searchButton.Click();
        }

        public void EnterText(string text)
        {
            WebDriverWait wait = new WebDriverWait(Hooks.Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(searchButton));
            searchBox.SendKeys(text);
            WaitforElement.ImplicitWaitforElement();
            searchBox.Click();
            searchBoxButton.Click();
        }

        public string SearchText()
        {
            string result = searchResult.Text.Replace("\r\n\"", "").Trim(new char[] { '\"' });
            return result;
        }
    }
}

