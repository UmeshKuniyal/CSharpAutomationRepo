using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Appium.SkeletonMethods
{
    public class ExtentReport
    {

        public static AventStack.ExtentReports.ExtentReports extent;
        public static ExtentHtmlReporter htmlReporter;
        public static ExtentTest test;
        public static string pathReflection = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        public static string actualPath = pathReflection.Substring(0, pathReflection.LastIndexOf("bin"));
        public static string projectPath = new Uri(actualPath).LocalPath;
        public static string reportPath;
        public ExtentReport(string app)
        {
            extent = new AventStack.ExtentReports.ExtentReports();
            reportPath = projectPath + @"Reports";
            reportPath = reportPath + @"\" + app + @"\";
            htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new AventStack.ExtentReports.ExtentReports();
        }

        public void StartReport()
        {
            
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            htmlReporter.Config.DocumentTitle = "Test Repoprt | App Test";
            htmlReporter.Config.ReportName = "Test Repoprt | App Test";
            extent.AttachReporter(htmlReporter);
        }
        public void CloseReport(RemoteWebDriver driver, string status,bool screenshot=true)
        {
            //StackTrace details for failed Testcases
            var message = NUnit.Framework.TestContext.CurrentContext.Result.Message;
            var stackTrace = "<pre>" + NUnit.Framework.TestContext.CurrentContext.Result.StackTrace + "</pre>";
            if (status == "Failed")
            {
                test.Log(Status.Fail, "Test case failed" + "\n");
                if (screenshot == true)
                {
                    string screenShotPath = Capture(driver, "ScreenShotName");
                    test.Log(Status.Info, "Snapshot below: " + test.AddScreenCaptureFromPath(screenShotPath));
                }
                test.Log(Status.Info, stackTrace );

            }
            else if (status == "Passed")
            {
                test.Log(Status.Pass, "Test case passed");
            }
            else
            {
                test.Log(Status.Info, "Test case Skipped");
            }
        }

        public void FlushReports()
        {
            extent.Flush();
        }

        public string Capture(IWebDriver driver, string screenShotName)
        {
            Random rand = new Random();
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Reports/" + @"ErrorScreenshots_" + rand.Next().ToString() + screenShotName + ".png";
            string localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return localpath;
        }
    }
}
