using System;
using OpenQA.Selenium;
using SeleniumUK.Drivers;
using SeleniumUK.CommonMethods;
using System.Threading;

namespace SeleniumUK
{
    public class FirstAutomation : BrowserDriver
    {
        static void Main(string[] args)
        {
            umesh um = new umesh();
            //um.display();
            driver = Browser(Constants.chrome, Constants.browserTypeNormal);
            NavigateToUriWithPageLoadWait("http://" + @"www.google.com", driver);
            IWebElement randomElement = driver.FindElement(By.XPath(@"//*[@title='Google apps']"));
            HighlightControl(driver, randomElement);
            //MoveToElement(driver, randomElement);
            randomElement.Click();
            Thread.Sleep(6000);
            //IWebElement randomElement2 = driver.FindElement(By.XPath(@"//span[text()='Account']"));
            IWebElement randomElement2 = driver.FindElements(By.TagName(@"frame"))[0];

            //IWebElement randomElement2 = driver.FindElement(By.XPath(@"//div[@class='qWuU9c']//ul/li[1]/a/span[2]"));
            //HighlightControl(driver, rand1);
            //IWebElement randomElement3 = driver.FindElement(By.XPath(@"//span[text()='Drive']"));
            //HighlightControl(driver, randomElement);
            Thread.Sleep(1000);
            driver.Close();
        }
    }
}
