using NorthrampFramework.Utils_Classes.SeleniumUtils;
using OpenQA.Selenium;

namespace NorthrampFramework.PageObjects
{
    public class FEDPASSPO
    {
        public IWebElement UsernameInputField()
        {
            string xpath = "//input[@id='username']";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement PasswordInputField()
        {
            string xpath = "//input[@id='password']";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement SignInBtn()
        {
            string xpath = "//button[text()='Sign In']";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement FYDropDown()
        {
            string xpath = "//span[contains(text(),'FY')]";
            return SeleniumDriver.GetListElementByXpath(xpath)[0];
        }

        public IWebElement SelectFYFromDropDown()
        {
            string xpath = "//span[contains(text(),'FY')]";
            return SeleniumDriver.GetListElementByXpath(xpath)[2];
        }

        public IWebElement LeftNavigationMainMenuOptions(string MenuOption)
        {
            string xpath = "//span[text()='" + MenuOption + "']";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement LeftNavigationSubMenuOptions(string SubMenuOption)
        {
            string xpath = "//ul[@class='nav child_menu']/descendant::a[contains(@href,'" + SubMenuOption + "')]";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        /// <summary>
        /// Works for all Create buttons: Create Investment, Create Component, .......
        /// </summary>
        /// <returns></returns>
        public IWebElement CreateBtn()
        {
            string xpath = "//a[contains(@href,'Create')]";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        /// <summary>
        /// Works for all Create pages where there is a Title input field
        /// </summary>
        /// <returns></returns>
        public IWebElement TitleInputField()
        {
            string xpath = "//label[text()='Title']/parent::div//input";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement ITDBstatusSelectField()
        {        
            string xpath = "//label[text() ='ITDB Status']/parent::div//select";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement InvestmentTypeSelectField()
        {
            string xpath = "//label[text() ='Investment Type']/parent::div//select";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement PartOfAgencySelectField()
        {
            string xpath = "//label[text() ='Part of Agency IT Portfolio Summary']/parent::div//select";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement CloudComputingEvaluationSelectField()
        {
            string xpath = "//label[text() ='Cloud Computing Alternatives Evaluation']/parent::div//select";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        /// <summary>
        /// Works for Save button on all Create and Edit pages
        /// </summary>
        /// <returns></returns>
        public IWebElement SaveBtn()
        {
            string xpath = "//a[text()='Save']";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement ReturnToListBtn()
        {
            string xpath = "//a[text()='Return to list']";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement DeleteInvestmentBtn()
        {
            string xpath = "//a[text()='Delete Investment']";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement EditInvestmentBtn()
        {
            string xpath = "//a[text()='Edit Investment']";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement YesBtn()
        {
            string xpath = "//button[text()='Yes']";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement FilterTitleInputField()
        {
            string xpath = "//th[text()='Title']/ancestor::thead/following-sibling::thead//descendant::input";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement SelectedInvestment(string Title)
        {
            string xpath = "//a[text()='" + Title + "']";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement DescriptionTextArea()
        {
            string xpath = "//label[text()='Description']/parent::div//descendant::textarea";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement RelatedInvestmntSelectField()
        {
            string xpath = "//label[text()='Related Investment']/parent::div//descendant::select";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        /// <summary>
        /// Component Identifier input field
        /// </summary>
        /// <returns></returns>
        public IWebElement CIinputField()
        {
            string xpath = "//label[text()='CI']/parent::div//input";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement OrganizationSelectField()
        {
            string xpath = "//label[text()='Organization']/parent::div//descendant::select";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

    }
}
