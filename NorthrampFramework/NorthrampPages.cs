using NorthrampFramework.Utils_Classes.SeleniumUtils;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace NorthrampFramework
{
    public class NorthrampPages
    {

        private static FEDPASSPage _FEDPASSpage;


        public static FEDPASSPage FEDPASSPage
        {
            get
            {
                _FEDPASSpage = PageGenerator.GetPage<FEDPASSPage>();

                _FEDPASSpage.wait = new WebDriverWait(SeleniumDriver.Instance, TimeSpan.FromSeconds(30));
                _FEDPASSpage.action = new Actions(SeleniumDriver.Instance);
                return _FEDPASSpage;
            }
        }
    }
}
