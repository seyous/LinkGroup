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
            Hooks.Driver.Navigate().GoToUrl("https://www.linkgroup.eu/");
            WaitforElement.ImplicitWaitforElement();
            Hooks.Driver.Manage().Window.Maximize();
        }

        [Then(@"page is displayed")]
        public void ThenPageIsDisplayed()
        {
            String CurrentURL = Hooks.Driver.Url;
            WaitforElement.Wait();
            Assert.AreEqual(CurrentURL, "https://www.linkgroup.eu/");

        }

        [Given(@"I have opened the page")]
        public void GivenIHaveOpenedThePage()
        {
            Hooks.Driver.Navigate().GoToUrl("https://www.linkgroup.eu/");
            WaitforElement.ImplicitWaitforElement();
            Hooks.Driver.Manage().Window.Maximize();

        }

        [Given(@"I have agreed to the cookie policy")]
        public void GivenIHaveAgreedToTheCookiePolicy()
        {
            _linkGroupPage.AcceptCookie();
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string text)
        {
            _linkGroupPage.ClickSearchButton();
            WaitforElement.ImplicitWaitforElement();
            _linkGroupPage.EnterText(text);

        }

        [Then(@"the search results are displayed")]
        public void ThenTheSearchResultsAreDisplayed()
        {
            Executescript.JavascriptExecutorCoordinate();
            WaitforElement.Wait();
            Assert.AreEqual("You searched for:Leeds", _linkGroupPage.SearchText());
        }

        [Given(@"I have opened the Found Solution page")]
        public void GivenIHaveOpenedTheFoundSolutionPage()
        {
            WaitforElement.ImplicitWaitforElement();
            Hooks.Driver.Navigate().GoToUrl("https://www.linkfundsolutions.co.uk/");
            Hooks.Driver.Manage().Window.Maximize();

        }

        [When(@"I view Funds")]
        public void WhenIViewFunds()
        {
            WaitforElement.ImplicitWaitforElement();
            _linkFundSolutionPage.ViewFunds();
        }



        [Then(@"I can select the investment managers for ""(.*)"" investors")]
        public void ThenICanSelectTheInvestmentManagersForInvestors(string p0)
        {
            WaitforElement.Wait();
            Assert.IsTrue(_linkFundSolutionPage.InvestorsDisplayed(p0));
        }


    }
}
