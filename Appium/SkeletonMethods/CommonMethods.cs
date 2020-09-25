using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Appium.SkeletonMethods
{
    class CommonMethods : ICommonMethods
    {
        
        public AndroidElement GetElementByXpath(string xPath, AppiumDriver<AndroidElement> appiumDriver) 
        {
            return appiumDriver.FindElement(By.XPath(xPath));
        }

        public AndroidElement GetElementByAccessibilityId(string accId, AppiumDriver<AndroidElement> appiumDriver) 
        {
            return appiumDriver.FindElementByAccessibilityId(accId);

        }

        public AndroidElement GetElementById(string id, AppiumDriver<AndroidElement> appiumDriver)
        {
            return appiumDriver.FindElementById(id);

        }

        public AndroidElement GetElementByClassName(string className, AppiumDriver<AndroidElement> appiumDriver) 
        {
            return appiumDriver.FindElementByClassName(className);
        }

        public void ClickOnElementByXpath(string xPath, AppiumDriver<AndroidElement> driver) 
        {
            GetElementByXpath(xPath,driver).Click();
        }

        public void ClickOnElementByAccessibilityId(string accId, AppiumDriver<AndroidElement> driver)
        {
            GetElementByAccessibilityId(accId, driver).Click();
        }

        public void ClickOnElementByClassName(string className, AppiumDriver<AndroidElement> driver)
        {
            GetElementByClassName(className, driver).Click();
        }
        public void ClickOnElementById(string id, AppiumDriver<AndroidElement> driver)
        {
            GetElementById(id, driver).Click();
        }

        public string ReadDataFromJSON(string attribute,string dataSource ) 
        {
            string datasource = dataSource ;
            string value = string.Empty;
            string directory = System.AppContext.BaseDirectory;
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            datasource = directory.Substring(0, directory.LastIndexOf("bin")) + "DataFiles\\" + datasource;
            JObject o1 = JObject.Parse(File.ReadAllText(datasource));
            value = (string)o1[attribute];
            return value;
        }

        public string ReadDataFromXml(string node, string dataSource)
        {
            string datasource = dataSource + ".xml";
            string value = string.Empty;
            string directory = System.AppContext.BaseDirectory;
            XmlDocument doc = new XmlDocument();
            doc.Load(directory.Substring(0, directory.LastIndexOf("bin")) + "DataFiles\\" + datasource);
            XmlNodeList nodes = doc.SelectNodes("DataSource");
            foreach (XmlNode x in nodes)
            {
                value = x.SelectSingleNode(node).InnerText;
            }
            return value;
        }
    }
}
