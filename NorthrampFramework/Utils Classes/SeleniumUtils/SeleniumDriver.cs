using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NorthrampFramework.Utils_Classes.SeleniumUtils
{
    public class SeleniumDriver
    {        

        //constants for browser
        private static readonly string IE = "IE";
        private static readonly string CHROME = "Chrome";
        private static readonly string XPATH = "xpath";
        private static readonly string ID = "id";
        private static readonly string NAME = "name";
        private static readonly string LINK = "link";

        private static readonly int MAX = 3;

        //unique instance of driver
        private static IWebDriver Instance;

        //to handle javascript actions
        private static IJavaScriptExecutor js;

        //wait object 
        private static WebDriverWait wait;

        //variables for path to Drivers
        private static string _pathToChrome = @"C:\NorthrampTestingFramework\NorthrampFramework\NorthrampFramework\Drivers\Chrome";
        private static string _pathToIE = @"C:\NorthrampTestingFramework\NorthrampFramework\NorthrampFramework\Drivers\IE";

        private SeleniumDriver()
        {
            // use static methods, no instance
        }

        /// <summary>
        /// Inits local browser driver with browser needed
        /// </summary>
        /// <param name="browser"></param>
        public static void InitBrowser(string browser)
        {
            if (IE.ToLower().Contains(browser.ToLower()))
            {
                SetUpIE();
            }
            else if (CHROME.ToLower().Contains(browser.ToLower()))
            {
                SetUpChrome();
            }
        }

        /// <summary>
        /// Init Chrome driver with configuration
        /// </summary>
        private static void SetUpChrome()
        {     
            ChromeOptions options = new ChromeOptions();
            //set options
            options.AddArguments("--disable-popup-blocking"); //To disable automatic popup blocking 
            options.AddArguments("--disable-extensions");
            options.AddArguments("--ignore-certificate-errors");
            
            try
            {
                Instance = new ChromeDriver(_pathToChrome, options);             
            }
            catch (Exception e)
            {
                Assert.Fail("---> " + e.Message);
            }

            if (Instance == null)
                Assert.Fail("--> None of the webDrivers are supported for this browser");


            js = (IJavaScriptExecutor)Instance; //init js object
            wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(60)); //init wait object
            Instance.Manage().Window.Maximize();
            Console.WriteLine("-------->  Opening Chrome Driver");
        }

        /// <summary>
        /// Init IE driver with configuration
        /// </summary>
        private static void SetUpIE()
        {
            InternetExplorerOptions IEoptions = new InternetExplorerOptions();
            //set options
            IEoptions.IgnoreZoomLevel = true;
            IEoptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            IEoptions.AddAdditionalCapability("acceptSslCerts", true);

            try
            {
                Instance = new InternetExplorerDriver(_pathToIE, IEoptions);
            }
            catch (Exception e)
            {
                Assert.Fail("---> " + e.Message);
            }

            if (Instance == null)
                Assert.Fail("--> None of the webDrivers are supported for this browser");

            js = (IJavaScriptExecutor)Instance; //init js object
            wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(60)); //init wait object
            Instance.Manage().Window.Maximize();
            Console.WriteLine("-------->  Opening IE Driver");
        }

        public static void CheckPageTitle(string Title)
        {
            Assert.AreEqual(Title, Instance.Title);
        }

        public static string GetAlertText()
        {
            WebDriverWait wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(5));
            var alert = wait.Until(ExpectedConditions.AlertIsPresent());

            return alert.Text;
        }

        /// <summary>
        /// Goes to an URL adn wait for DOM to be loaded.
        /// </summary>
        /// <param name="url"></param>
        public static void GoTo(string url)
        {
            SeleniumDriver.Instance.Navigate().GoToUrl(url);
            WaitForDOMready();
        }

        /// <summary>
        /// Goes Back one page and wait DOM to be loaded.
        /// </summary>
        public static void NavigateBack()
        {
            WaitForDOMready();
            SeleniumDriver.Instance.Navigate().Back();
            WaitForDOMready();
        }


        /// <summary>
        /// Quits current driver instance from memory
        /// </summary>
        public static void QuitDriverInstance()
        {
            Instance.Quit();
            Instance = null;

        }


        /// <summary>
        /// Close current Tab in browser
        /// </summary>
        public static void Close()
        {
            Instance.Close();
        }

        internal static string GetcurrentWindowHandler(ReadOnlyCollection<string> windowsHandler)
        {
            foreach (var window in windowsHandler)
            {
                Console.WriteLine(window);
                if (window != Instance.CurrentWindowHandle)
                {
                    return window;
                }
            }
            return null;
        }

        /// <summary>
        /// Return current driver browser name 
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentBrowserName()
        {
            ICapabilities cap = ((RemoteWebDriver)Instance).Capabilities;
            return cap.BrowserName.ToLower();
        }

        /// <summary>
        /// Returns list of current windows
        /// </summary>
        /// <returns></returns>
        public static List<string> GetCurrentBrowserWindows()
        {
            return SeleniumDriver.Instance.WindowHandles.ToList();
        }

        // - - - - - - - - - -  Basic Actions Basic actions - - - - - - - - - - - - - //
        // ===================================================================//



        ///<summary>
        ///Perform a click on the element with JavaScript.
        ///</summary>
        ///<param name="element">element to click</param>
        ///
        public static void ClickElement(IWebElement element)
        {
            Thread.Sleep(1);

            try
            {
                js.ExecuteScript("arguments[0].click();", element);
                // element.Click();//javaScript click is works better 
            }
            catch (StaleElementReferenceException)
            {
                // Ignore
            }
            catch (Exception)
            {
                js.ExecuteScript("arguments[0].click();", element);
            }
        }

        ///<summary>
        ///Set a value in an element. usually text fields, input tag if value is not
        ///correct it will re-try
        ///</summary>
        ///<param name="element"></param>
        ///<param name="value"></param>
        public static void SetValue(IWebElement element, string value)
        {
            ClickElement(element);

            element.SendKeys(value);

            if (!GetValue(element).ToLower().Equals(value.ToLower()))
            {
                Thread.Sleep(1);
                element.SendKeys(Keys.Home);
                element.SendKeys(Keys.Shift + Keys.End);
                element.SendKeys(Keys.Delete);

                Thread.Sleep(1);
                js.ExecuteScript("arguments[0].value = '" + value + "';", element);
                js.ExecuteScript("arguments[0].focus(); arguments[0].blur(); return true", element);
            }
        }


        ///<summary>
        ///Clear the value, works for input and textArea
        ///</summary>
        ///<param name="element"></param>
        public static void ClearValue(IWebElement element)
        {
            Thread.Sleep(1); // :( required
            try
            {
                element.Clear();
            }
            catch (Exception e)
            {
                // Ignore
            }
        }

        ///<summary>
        ///Return the value of the attribute VALUE in the element common for input
	    /// fields
        ///</summary>
        ///<param name="element"></param>
        ///<returns>return the text of the value property</returns>
        public static string GetValue(IWebElement element)
        {
            return element.GetAttribute("value");
        }

        ///<summary>
        ///Return the value of a specified attribute name in the element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="attributeName"></param>
        public static string GetAttributeValue(IWebElement element, string attributeName)
        {
            return element.GetAttribute(attributeName);
        }

        ///<summary>
        ///return the text of that element
        /// </summary>
        /// <param name="element"></param>
        public static string GetText(IWebElement element)
        {
            string text = element.Text;

            if (text.Equals(""))
                text = (string)js.ExecuteScript("return arguments[0].value", element);

            if (text.Equals(""))
                text = (string)js.ExecuteScript("return arguments[0].textContent", element);

            return text;
        }

        ///<summary>
        /// Return if the checkbox is checked
        /// </summary>
        /// <param name="element"></param>
        public static bool IsChecked(IWebElement element)
        {

            return (Boolean)js.ExecuteScript("return arguments[0].checked", element);
        }

        ///<summary>
        ///Select an item in a drop down element by the value
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SelectDropDownByValue(IWebElement element, string value)
        {
            new SelectElement(element).SelectByValue(value);
        }


        ///<summary>
        ///Select an item in a drop down element by the index
        /// </summary>
        /// <param name="value"></param>
        /// <param name="element"></param>
        public static void SelectDropDownByIndex(IWebElement element, int index)
        {
            Thread.Sleep(2000);
            new SelectElement(element).SelectByIndex(index);
        }

        ///<summary>
        ///Select an item in a drop down element by visible text 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        public static void SelectDropDownByText(IWebElement element, string text)
        {
            new SelectElement(element).SelectByText(text);
        }


        //public static void RandomSelectDropDownByIndex(IWebElement element)
        //{                 
        //    Random rdm = new Random(); 
        //    new SelectElement(element).SelectByIndex(rdm.Next(0,5));
        //}

        /// <summary>
        /// Select a random item in a drop down list by index 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        public static void RandomSelectDropDownByIndex(IWebElement element)
        {
            Random rdm = new Random();
            SelectElement Select = new SelectElement(element);         
            IList<IWebElement> list = Select.Options;
            int NumberOfOptions = list.Count;
            Select.SelectByIndex(rdm.Next(1, NumberOfOptions));
        }


        ///<summary>
        ///Scroll the current windows to a certain element
        /// </summary>
        /// <param name="element"></param>
        public static void ScrollToElement(IWebElement element)
        {
            Thread.Sleep(3);
            try
            {
                js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
                WaitVisibilityOf(element);
            }
            catch (Exception e)
            {
                // logger.error("---> Could not scroll to the element");
            }
        }


        // - - - - - - - - - - Waits Helpers - - - - - - - - - - - - - //
        // ===================================================================//



        ///<summary>
        ///wait for the HTML DOM to be ready, all elements loaded
        ///note: Does not guarantee the full page has loaded, sometimes DOM can
        /// return complete, but some elements are still loading dynamically
        /// </summary>
        public static void WaitForDOMready()
        {
            try
            {
                wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch (Exception)
            {
                Assert.Fail("Timeout waiting for Page Load Request to complete.");
            }
        }

        /// <summary>
        /// Wait up to 60 sec for the visibility of the element, alternative to wait for page load
        /// </summary>
        /// <param name="element"></param>
        public static void WaitVisibilityOf(IWebElement element)
        {
            WaitVisibilityOf(element, 60);
        }

        /// <summary>
        /// Waits for an element to be clickckable therefore visible
        /// </summary>
        /// <param name="element"></param>
        /// <param name="time"></param>
        public static void WaitVisibilityOf(IWebElement element, int time)
        {
            WebDriverWait waiting = new WebDriverWait(Instance, TimeSpan.FromSeconds(time));
            try
            {
                waiting.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (StaleElementReferenceException e)
            {
                // Ignore
            }
            catch (Exception ex)
            {
                // Ignore
            }
        }

        public static void WaitVisibilityOfAllElements(By locator)
        {
            WaitVisibilityOfAllElements(locator, 60);
        }

        /// <summary>
        /// Waits for visibility of all element in a list using its locator "By"
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="time"></param>
        public static void WaitVisibilityOfAllElements(By locator, int time)
        {
            WebDriverWait waiting = new WebDriverWait(Instance, TimeSpan.FromSeconds(time));

            try
            {
                waiting.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
            }
            catch (StaleElementReferenceException e)
            {
                // Ignore
            }
            catch (Exception ex)
            {
                // Ignore
            }
        }

        /// <summary>
        /// Waits until an elements if not visible
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="time"></param>
        public static void WaitInvisibilityOf(By locator, int time)
        {
            WebDriverWait waiting = new WebDriverWait(Instance, TimeSpan.FromSeconds(time));
            waiting.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }


        // - - - - - - - - - - Windows / Frames - - - - - - - - - - - - //
        // ===================================================================//


        /// <summary>
        /// Switch to a frame
        /// </summary>
        /// <param name="frameName"></param>
        public static void SwitchToFrame(string frameName)
        {
            Thread.Sleep(2);
            try
            {
                Instance.SwitchTo().Frame(frameName);
            }
            catch (Exception e2)
            {
                Instance.SwitchTo().Frame(Instance.FindElement(By.Id(frameName)));
            }
        }

        // - - - - - - - - - - Page Object Helper - - - - - - - - - - //
        // ===================================================================//

        /// <summary>
        /// Gets element located by xpath
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns>Element located by xpath</returns>
        public static IWebElement GetElementByXpath(string xpath)
        {
            return GetElementByXpath(xpath, 10, true);
        }


        /// <summary>
        /// Gets element located by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Element located by Name</returns>
        public static IWebElement GetElementByName(string name)
        {
            return GetElementByName(name, 10, true);
        }

        /// <summary>
        /// Gets element located by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>Element located by ID</returns>
        public static IWebElement GetElementByID(string ID)
        {
            return GetElementByID(ID, 10, true);
        }

        /// <summary>
        /// Gets list of elements located by xpath
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns>List of Element located by Xpath</returns>
        public static List<IWebElement> GetListElementByXpath(string xpath)
        {
            return GetListElementByXpath(xpath, 10, true);
        }

        /// <summary>
        /// Gets list of elements located by name
        /// </summary>
        /// <param name="nae"></param>
        /// <returns>List of Element located by Name</returns>
        public static List<IWebElement> GetListElementByName(string name)
        {
            return GetListElementByName(name, 10, true);
        }

        /// <summary>
        /// Gets list of elements located by linkText
        /// </summary>
        /// <param name="linkText"></param>
        /// <returns>List of Element located by linkText</returns>
        public static IWebElement GetElementByLinkText(string linkText)
        {
            return GetElementByLinkText(linkText, 10, true);
        }

        public static IWebElement GetElementByXpath(string xpath, long time, bool printError)
        {
            return GetElement(xpath, time, printError, XPATH);
        }

        public static IWebElement GetElementByName(string name, long time, bool printError)
        {
            return GetElement(name, time, printError, NAME);
        }

        public static IWebElement GetElementByID(string id, long time, bool printError)
        {
            return GetElement(id, time, printError, ID);
        }


        public static IWebElement GetElementByLinkText(string link, long time, bool printError)
        {
            return GetElement(link, time, printError, LINK);
        }


        public static List<IWebElement> GetListElementByXpath(string xpath, long time, bool printError)
        {
            return GetListOfElements(xpath, time, printError, XPATH);
        }


        public static List<IWebElement> GetListElementByName(string name, long time, bool printError)
        {
            return GetListOfElements(name, time, printError, NAME);
        }

        private static List<IWebElement> GetListOfElements(string element, long time, bool printError, string by)
        {
            WebDriverWait wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(time));
            List<IWebElement> elements = null;
            // TODO: Need to create a medium wait about --> 10 secs

            for (int i = 0; i < MAX && (elements == null || elements.Count < 1); ++i)
            {
                try
                {
                    if (by.ToLower().Equals(NAME))
                        elements = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Name(element))).ToList();
                    else if (by.ToLower().Equals(XPATH))
                        elements = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(element))).ToList();
                }
                catch (Exception)
                {
                    // Nothing expected
                }
            }

            if (elements != null && elements.Count > 0)
                return elements;

            else
            {
                if (printError)
                {
                    Assert.Fail("---> Unable to find List of elements with " + by + ": " + element);
                }
                return null;
            }
        }

        private static IWebElement GetElement(string element, long time, bool printError, string by)
        {
            WebDriverWait wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(time));
            List<IWebElement> elements = null;
            // TODO: Need to create a medium wait about --> 10 secs

            for (int i = 0; i < MAX && (elements == null || elements.Count < 1); ++i)
            {
                try
                {
                    if (by.ToLower().Equals(ID))
                        elements = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id(element))).ToList();
                    else if (by.ToLower().Equals(NAME))
                        elements = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Name(element))).ToList();
                    if (by.ToLower().Equals(XPATH))
                        elements = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(element))).ToList();
                    else if (by.ToLower().Equals(LINK))
                        try
                        {
                            elements = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.LinkText(element))).ToList();
                        }
                        catch (Exception e)
                        {
                            elements = wait
                                    .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.PartialLinkText(element))).ToList();
                        }
                }
                catch (Exception)
                {

                }
            }

            if (elements != null && elements.Count > 0)
                return elements.ElementAt(0);

            else
            {
                if (printError)
                {
                    Assert.Fail("---> Unable to find element with " + by + ": " + element);
                }
                return null;
            }
        }

    }

}
