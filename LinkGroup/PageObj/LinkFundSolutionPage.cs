using LinkGroup.Util;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkGroup.PageObj
{
    public class LinkFundSolutionPage
    {
        Actions action = new Actions(Hooks.Driver);
        IWebElement fundsMenu => Hooks.Driver.FindElementById("navItem-funds");
        IWebElement Investors => Hooks.Driver.FindElementByXPath("//*[@id='navItem-funds']/div/div/div[2]/div[1]/ul/li/a");



        public void ViewFunds()
        {
            WaitforElement.Wait();
            action.MoveToElement(fundsMenu).Build().Perform();
        }


        public bool InvestorsDisplayed(string searchInvestors)
        {

            try
            {
                WaitforElement.Wait();
                action.MoveToElement(Investors).Perform();

                IList<IWebElement> elements = Hooks.Driver.FindElements(By.XPath("//*[@id='navItem-funds']/div/div/div[2]/div[1]/ul/li/a"));
                int i = 0;
                foreach (IWebElement element in elements)
                {

                    if (element.Text.Contains(searchInvestors))
                    {
                        bool displayedObject = element.Displayed;
                        return true;
                    }
                    i++;
                }

            }
            catch (Exception e)
            {

                return false;
            }
            return false;
        }

    }
}
