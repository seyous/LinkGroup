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
        Actions action = new Actions(Hooks.driver);
        IWebElement fundsMenu => Hooks.driver.FindElementById("navItem-funds");
        IWebElement Investors => Hooks.driver.FindElementByXPath("//*[@id='navItem-funds']/div/div/div[2]/div[1]/ul/li/a");



        public void Viewfunds()
        {
            WaitforElement.wait();
            action.MoveToElement(fundsMenu).Build().Perform();
        }


        public bool Investorsdisplayed(string searchInvestors)
        {

            try
            {
                WaitforElement.wait();
                action.MoveToElement(Investors).Perform();

                IList<IWebElement> elements = Hooks.driver.FindElements(By.XPath("//*[@id='navItem-funds']/div/div/div[2]/div[1]/ul/li/a"));
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
