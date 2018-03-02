using NorthrampFramework.Utils_Classes.SeleniumUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace NorthrampTest.Steps
{
    [Binding]

    public sealed class CommonSteps
    {  
        [Given(@"I open Chrome")]
        public void GivenIOpenChrome()
        {
            SeleniumDriver.InitBrowser("Chrome");
        }
        
        [Given(@"I open IE")]
        public void GivenIOpenIE()
        {
            SeleniumDriver.InitBrowser("IE");
        }

        //To kill all the Selenium browsers after a test
        [AfterScenario]
        public void CleanUp()
        {
            SeleniumDriver.QuitDriverInstance();
        }

    }
}
