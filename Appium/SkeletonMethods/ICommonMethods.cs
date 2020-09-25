using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace Appium.SkeletonMethods
{
    interface ICommonMethods
    {
        AndroidElement GetElementByXpath(string xPath, AppiumDriver<AndroidElement> appiumDriver);
        AndroidElement GetElementByAccessibilityId(string accId, AppiumDriver<AndroidElement> appiumDriver);
        AndroidElement GetElementById(string id, AppiumDriver<AndroidElement> appiumDriver);

        AndroidElement GetElementByClassName(string ClassName, AppiumDriver<AndroidElement> appiumDriver);
        void ClickOnElementByXpath(string elementProperty, AppiumDriver<AndroidElement> appiumDriver);
        void ClickOnElementByAccessibilityId(string elementProperty, AppiumDriver<AndroidElement> appiumDriver);
        void ClickOnElementByClassName(string elementProperty, AppiumDriver<AndroidElement> appiumDriver);
        void ClickOnElementById(string elementProperty, AppiumDriver<AndroidElement> appiumDriver);


    }
}
