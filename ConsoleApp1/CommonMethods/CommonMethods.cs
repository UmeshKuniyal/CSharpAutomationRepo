using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumUK.CommonMethods
{
    public class CommonMethods
    {
        public static void MoveToElement(IWebDriver driver, IWebElement element)
        {
            Actions action = new Actions(driver);
            action.MoveByOffset(element.Location.X, element.Location.Y).Perform();
            element.Click();            
        }
        
        public static void HighlightControl(IWebDriver driver, IWebElement element)
        {
            var jsDriver = (IJavaScriptExecutor)driver;
            string highlightJavascript = @"arguments[0].style.cssText = ""border-width: 3px; border-style: solid; border-color: green"";";
            jsDriver.ExecuteScript(highlightJavascript, new object[] { element });
            Thread.Sleep(500);
            highlightJavascript = @"arguments[0].style.cssText = ""border-width: 0px;"";";
            jsDriver.ExecuteScript(highlightJavascript, new object[] { element });
        }

    }
}
