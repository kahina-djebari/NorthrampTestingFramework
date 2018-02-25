using NorthrampFramework.Utils_Classes.SeleniumUtils;
using OpenQA.Selenium.Support.PageObjects;

namespace NorthrampFramework
{
    public class PageGenerator
    {
        public static T GetPage<T>() where T : PageModel, new()
        {
            T page = new T();
            PageFactory.InitElements(SeleniumDriver.Instance, page);
            return page;

        }
    }
}
