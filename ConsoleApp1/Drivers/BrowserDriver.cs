using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.IO;
using System.Reflection;

namespace SeleniumUK.Drivers
{

    public class BrowserDriver : CommonMethods.CommonMethods
    {
        protected static IWebDriver driver;
        //public BrowserDriver()
        //{

        //}

        /// <summary>
        /// Supported browser type are Chrome, Mozilla firefox
        /// </summary>
        /// <param name="browserName"></param>
        /// <param name="browserType"></param>
        /// <returns></returns>
        public static IWebDriver Browser(string browserName, string browserType)
        {            
            if (browserType.Equals(SeleniumUK.CommonMethods.Constants.browserTypeNormal) && browserName.Equals(SeleniumUK.CommonMethods.Constants.chrome))
            {
                return ChromeDriver();
            }
            else if (browserType.Equals(SeleniumUK.CommonMethods.Constants.browserTypeHeadless) && browserName.Equals(SeleniumUK.CommonMethods.Constants.chrome))
            {
                return ChromeDriver(true);
            }
            else if (browserType.Equals(SeleniumUK.CommonMethods.Constants.browserTypeNormal) && browserName.Equals(SeleniumUK.CommonMethods.Constants.firefox))
            {
                return FirefoxDriver();
            }
            else if (browserType.Equals(SeleniumUK.CommonMethods.Constants.browserTypeHeadless) && browserName.Equals(SeleniumUK.CommonMethods.Constants.firefox))
            {
                return FirefoxDriver(true);
            }
            else
            {
                throw new NotFoundException();
            }
        }

        public static IWebDriver ChromeDriver(bool headless=false)
        {
            if (headless==true)
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("headless");
                driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                driver.Manage().Window.Maximize();
                return driver;
            }
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            return driver;
        }

        public static IWebDriver FirefoxDriver(bool headless=false)
        {
            if (headless == true)
            {
                FirefoxOptions options = new FirefoxOptions();
                options.AddArgument("headless");
                driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                driver.Manage().Window.Maximize();
                return driver;
            }
            driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            return driver;
        }

        public static void SetBrowserResolution(int x, int y, IWebDriver browserDriver)
        {
            browserDriver.Manage().Window.Size = new System.Drawing.Size(x, y);
        }

        public static void OpenNewTab(IWebDriver browserDriver)
        {
            ((IJavaScriptExecutor)browserDriver).ExecuteScript("window.open();");
        }

        public static void NavigateToUriWithPageLoadWait(string uri, IWebDriver driver)
        {
           var Idriver = (IJavaScriptExecutor)(driver);
            driver.Navigate().GoToUrl(uri);
            string js = "return document.readyState";
            Idriver.ExecuteScript(js);
        }
    }
}
