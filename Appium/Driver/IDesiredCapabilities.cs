using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appium
{
    interface IDesiredCapabilities
    {
        public static string deviceName;
        public static string platformName;
        public static string packageActivity;
        public static string udid;
        public static string platformVersion;
        public static string app;
        public static string appPackage;
        public static string noReset;

        string DeviceName();
        string PlatformName();
        string PackageActivity();
        string Udid();
        string PlatformVersion();
        string App();
        string AppPackage();
        string NoReset();

        AndroidDriver<AndroidElement> driver(string deviceName, string platformName, string packageActivity, string udid, string platformVersion, string appPackage, string app=null, string noReset=null, Uri url=null);
        AndroidDriver<AndroidElement> driver();

        Uri GetAppiumServerUrl();
    }
}
