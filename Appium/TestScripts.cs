using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using Appium.SkeletonMethods;
using Appium.Driver;
using AventStack.ExtentReports;
using NUnit.Framework;


namespace Appium
{
[TestFixture]
[Parallelizable]
    public class AppiumTest
    {
        AppiumDriver<AndroidElement> appiumDriver;
        CommonMethods commonMethods;
        DriverInitialization androidDriver;
        ExtentReport report;

        [OneTimeSetUp]
        public void SetupTests()
        {
            
            report = new ExtentReport("Flipkart");
            report.StartReport();
            androidDriver = new DriverInitialization();
            commonMethods = new CommonMethods();
        }

        [SetUp]
        public void TestSetUp() 
        {
            ExtentReport.test = ExtentReport.extent.CreateTest(NUnit.Framework.TestContext.CurrentContext.Test.MethodName);
            ExtentReport.test.Log(Status.Info, "Test Case Started");
            appiumDriver = androidDriver.driver();
            ExtentReport.test.Log(Status.Info, "Appium driver session id : "+appiumDriver.SessionId.ToString());
            foreach(var i in appiumDriver.SessionDetails) 
            {
                ExtentReport.test.Log(Status.Info, "Appium driver capabilities : " + i.Key.ToString() + " : " + i.Value.ToString());

            }
            if (androidDriver.NoReset() == "false") 
            {
                appiumDriver = androidDriver.driver();
                commonMethods.ClickOnElementByXpath(PageElements.englishLanguage_Xpath, appiumDriver);
                commonMethods.ClickOnElementById(PageElements.selectSubmitButton_Id, appiumDriver);
                commonMethods.ClickOnElementByXpath(PageElements.noneOfTheAboveButton_Xpath, appiumDriver);
                commonMethods.ClickOnElementById(PageElements.closeButton_Id, appiumDriver);
            }
        }

        [TearDown]
        public void TestTearDown() 
        {
            var status = NUnit.Framework.TestContext.CurrentContext.Result.Outcome.Status;
            report.CloseReport(appiumDriver, status.ToString());
            
        }

        [OneTimeTearDown]
        public void FinalTearDown() 
        {
            report.FlushReports();

        }

        [Test]
        public void ValidateSearchIconIsPresentInElectronicCatergory()
        {
            appiumDriver.FindElementByClassName(@"android.widget.ImageButton").Click();
            appiumDriver.FindElement(By.XPath(@"/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/androidx.drawerlayout.widget.DrawerLayout/android.view.ViewGroup/android.widget.FrameLayout[1]/android.view.ViewGroup/android.view.ViewGroup[2]/androidx.recyclerview.widget.RecyclerView/android.widget.LinearLayout[1]/android.widget.FrameLayout/androidx.viewpager.widget.ViewPager/android.widget.FrameLayout[2]/android.widget.ImageView")).Click();
            appiumDriver.FindElement(By.XPath(@"/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/androidx.drawerlayout.widget.DrawerLayout/android.view.ViewGroup/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup[2]/androidx.recyclerview.widget.RecyclerView/android.widget.LinearLayout[1]/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.TextView[3]")).Click();
            Assert.IsNotNull(appiumDriver.FindElementByAccessibilityId("Search"));
        }

        [Test]
        public void ValidateAddCartIsEmptyInitially()
        {
            appiumDriver.FindElement(By.XPath("//android.widget.RelativeLayout[@content-desc='Shopping Cart']/android.widget.LinearLayout/android.widget.ImageView")).Click();
            Assert.IsNotNull(appiumDriver.FindElement(By.ClassName(@"android.widget.ImageView")));
        }

        [Test]
        public void ValidateQuantityCalculation() 
        {
            appiumDriver.FindElementByAccessibilityId("Search").Click();
            appiumDriver.FindElement(By.XPath(@"//android.widget.TextView[@text=' Search for Products, Brands and More']")).SendKeys("Chayawanprash");
            appiumDriver.FindElementById(@"com.flipkart.android:id/txt_title").Click();
            appiumDriver.FindElementByClassName(@"android.view.ViewGroup").Click();
            appiumDriver.FindElement(By.XPath(@"//android.widget.TextView[@text='Enter pincode']"));
            appiumDriver.FindElementByXPath(@"//android.widget.EditText[@text='Enter pincode']").SendKeys("560100");
            appiumDriver.FindElementByXPath(@"//android.widget.TextView[@text='Submit']").Click();
            appiumDriver.FindElementByXPath(@"//android.widget.TextView[@text='ADD TO BASKET']").Click();
        }

    }
}
