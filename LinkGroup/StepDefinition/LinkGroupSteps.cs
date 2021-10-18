using LinkGroup.PageObj;
using LinkGroup.Util;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace LinkGroup.StepDefinition
{
    [Binding]
    public class LinkGroupSteps
    {
        private readonly LinkGroupPage _linkGroupPage;
        private readonly LinkFundSolutionPage _linkFundSolutionPage;

        public LinkGroupSteps(LinkGroupPage linkGroupPage, LinkFundSolutionPage linkFundSolutionPage)
        {
            _linkGroupPage = linkGroupPage;
            _linkFundSolutionPage = linkFundSolutionPage;
        }


        [When(@"I open the home page")]
        public void WhenIOpenTheHomePage()
        {
            Hooks.driver.Navigate().GoToUrl("https://www.linkgroup.eu/");
            WaitforElement.ImplicitWaitforElement();
            Hooks.driver.Manage().Window.Maximize();
        }

        [Then(@"page is displayed")]
        public void ThenPageIsDisplayed()
        {
            String CurrentURL = Hooks.driver.Url;
            WaitforElement.wait();
            Assert.AreEqual(CurrentURL, "https://www.linkgroup.eu/");

        }

        [Given(@"I have opened the page")]
        public void GivenIHaveOpenedThePage()
        {
            Hooks.driver.Navigate().GoToUrl("https://www.linkgroup.eu/");
            WaitforElement.ImplicitWaitforElement();
            Hooks.driver.Manage().Window.Maximize();

        }

        [Given(@"I have agreed to the cookie policy")]
        public void GivenIHaveAgreedToTheCookiePolicy()
        {
            _linkGroupPage.Acceptcookie();
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string text)
        {
            _linkGroupPage.Clicksearchbutton();
            WaitforElement.ImplicitWaitforElement();
            _linkGroupPage.Entertext(text);

        }

        [Then(@"the search results are displayed")]
        public void ThenTheSearchResultsAreDisplayed()
        {
            Executescript.JavascriptexecutorCoordinate();
            WaitforElement.wait();
            Assert.AreEqual("You searched for:Leeds", _linkGroupPage.Searchtext());
        }

        [Given(@"I have opened the Found Solution page")]
        public void GivenIHaveOpenedTheFoundSolutionPage()
        {
            WaitforElement.ImplicitWaitforElement();
            Hooks.driver.Navigate().GoToUrl("https://www.linkfundsolutions.co.uk/");
            Hooks.driver.Manage().Window.Maximize();

        }

        [When(@"I view Funds")]
        public void WhenIViewFunds()
        {
            WaitforElement.ImplicitWaitforElement();
            _linkFundSolutionPage.Viewfunds();
        }



        [Then(@"I can select the investment managers for ""(.*)"" investors")]
        public void ThenICanSelectTheInvestmentManagersForInvestors(string p0)
        {
            WaitforElement.wait();
            Assert.IsTrue(_linkFundSolutionPage.Investorsdisplayed(p0));
        }


    }
}
