using Appium.SkeletonMethods;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appium.Driver
{
    class DriverInitialization : IDesiredCapabilities
    {
        AndroidDriver<AndroidElement> androidDriver;
        CommonMethods methods = new CommonMethods();

        public DriverInitialization() 
        {
            DeviceName();
            PlatformName();
            PackageActivity();
            Udid();
            AppPackage();
            GetAppiumServerUrl();
            NoReset();
            App();
        }
        public string DeviceName()
        {
            IDesiredCapabilities.deviceName = methods.ReadDataFromJSON("DeviceName", "DesiredCapabilities.json");
            return IDesiredCapabilities.deviceName;
        }

        public string PlatformName()
        {
            IDesiredCapabilities.platformName = methods.ReadDataFromJSON("PlatformName", "DesiredCapabilities.json"); 
            return IDesiredCapabilities.platformName;
        }

        public string PackageActivity() 
        {
            IDesiredCapabilities.packageActivity = methods.ReadDataFromJSON("PackageActivity", "DesiredCapabilities.json"); ;
            return IDesiredCapabilities.packageActivity;
        }

        public string Udid() 
        {
            IDesiredCapabilities.udid = methods.ReadDataFromJSON("Udid", "DesiredCapabilities.json"); 
            return IDesiredCapabilities.udid;
        }

        public string AppPackage() 
        {
            IDesiredCapabilities.appPackage = methods.ReadDataFromJSON("AppPackage", "DesiredCapabilities.json");
            return IDesiredCapabilities.appPackage;
        }

        public string PlatformVersion() 
        {
            IDesiredCapabilities.platformVersion = methods.ReadDataFromJSON("PlatformVersion", "DesiredCapabilities.json");
            return IDesiredCapabilities.platformVersion;
        }

        public string App() 
        {
            IDesiredCapabilities.app = methods.ReadDataFromJSON("App", "DesiredCapabilities.json");
            return IDesiredCapabilities.app;
        }

        public string NoReset() 
        {
            IDesiredCapabilities.noReset = (methods.ReadDataFromJSON("NoReset", "DesiredCapabilities.json"));
            return IDesiredCapabilities.noReset;
        }

        public Uri GetAppiumServerUrl() 
        {
            Uri uri = new Uri(methods.ReadDataFromJSON("AppiumServerUrl", "DesiredCapabilities.json"));
            return uri;
        }
        public AndroidDriver<AndroidElement> driver(string deviceName, string platformName, string packageActivity, string udid, string platformVersion, string appPackage, string app=null,string noReset = null,Uri url=null)
        {
            var cap = new AppiumOptions();
            cap.AddAdditionalCapability(MobileCapabilityType.DeviceName, deviceName);
            cap.AddAdditionalCapability(MobileCapabilityType.PlatformName, platformName);
            cap.AddAdditionalCapability("PackageActivity", packageActivity);
            if (noReset != null )
                cap.AddAdditionalCapability(MobileCapabilityType.NoReset, noReset);
            cap.AddAdditionalCapability("AppPackage", appPackage);
            cap.AddAdditionalCapability(MobileCapabilityType.Udid, udid);
            cap.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, platformVersion);
            if(app!=null )
                cap.AddAdditionalCapability(MobileCapabilityType.App, app);
            if (url == null)
                url = GetAppiumServerUrl();
            androidDriver = new AndroidDriver<AndroidElement>(url, cap);
            androidDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 20);
            return androidDriver;
        }

        public AndroidDriver<AndroidElement> driver()
        {
            var cap = new AppiumOptions();
            string noReset =IDesiredCapabilities.noReset.Trim();
            var app = IDesiredCapabilities.app.Trim();
            var url = GetAppiumServerUrl();
            cap.AddAdditionalCapability(MobileCapabilityType.DeviceName, IDesiredCapabilities.deviceName);
            cap.AddAdditionalCapability(MobileCapabilityType.PlatformName, IDesiredCapabilities.platformName);
            cap.AddAdditionalCapability("PackageActivity", IDesiredCapabilities.packageActivity);
            if (noReset!="")
                cap.AddAdditionalCapability(MobileCapabilityType.NoReset, noReset);
            cap.AddAdditionalCapability("AppPackage", IDesiredCapabilities.appPackage);
            cap.AddAdditionalCapability(MobileCapabilityType.Udid, IDesiredCapabilities.udid);
            cap.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, IDesiredCapabilities.platformVersion);
            if (app != "")
                cap.AddAdditionalCapability(MobileCapabilityType.App, IDesiredCapabilities.app);
            androidDriver = new AndroidDriver<AndroidElement>(url, cap);
            androidDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 20);
            return androidDriver;
        }

    }

}
