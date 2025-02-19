using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTrackTestUnit.Helper
{
    public class BaseTest
    {
        protected AppiumDriver App => AppiumSetup.App;

        protected AppiumElement FindUIElement(string id)
        {
            string elementId = "com.companyname.greentrack:id/" + id;
            var pageSource = App.PageSource;
            return App.FindElement(MobileBy.Id(elementId));
        }
    }
}
