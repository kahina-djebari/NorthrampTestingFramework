using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace NorthrampFramework
{
    public class PageModel
    {

        public WebDriverWait wait;
        internal Actions action;
        internal static long timer1;
        internal static long timer2;
        internal string LoadTime { get { return ((timer2 - timer1)).ToString() + "ms"; } }
        internal PopupWindowFinder finder;
        internal string popupWindowHandle;
        internal static string SingleSignOnProvider;
        internal static string _Environment;

        internal void StartTimer()

        {
            timer1 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

        }

        internal void StopTimer()
        {
            timer2 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

        }

        internal void PrintResponseTime(String pageName)
        {
            if (String.IsNullOrEmpty(_Environment) || String.IsNullOrEmpty(SingleSignOnProvider))
            {
                Console.WriteLine(pageName + " Home Page Took: " + LoadTime + " to Load");

            }
            else
            {
                Console.WriteLine(pageName + " (" + _Environment + ")  Home Page Took: " + LoadTime + " to load Using " + SingleSignOnProvider);
                Console.WriteLine("</br>");
            }


        }

        internal void PrintSuccesfullLogin(string user)
        {
            Console.WriteLine("User: " + user + " succesfully logged in using " + SingleSignOnProvider);
        }

    }
}
