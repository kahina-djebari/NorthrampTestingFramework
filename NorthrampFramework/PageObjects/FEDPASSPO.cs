using NorthrampFramework.Utils_Classes.SeleniumUtils;
using OpenQA.Selenium;
using System.Collections.Generic;

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
        /// Works for: Create Investment, Create Component, Create Budget Item
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
            string xpath = "//label[text() ='ITDB Status']/parent::div/child::div/child::select";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement InvestmentTypeSelectField()
        {
            string xpath = "//label[text() ='Investment Type']/parent::div/child::div/child::select";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement PartOfAgencySelectField()
        {
            string xpath = "//label[text() ='Part of Agency IT Portfolio Summary']/parent::div/child::div/child::select";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement CloudComputingEvaluationSelectField()
        {
            string xpath = "//label[text() ='Cloud Computing Alternatives Evaluation']/parent::div/child::div/child::select";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        /// <summary>
        /// Works for Save button on all Create and Edit pages
        /// </summary>
        /// <returns></returns>
        public IWebElement SaveBtn()
        {
            string xpath = "//i/parent::a[text()='Save']";
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
            string xpath = "//th[text()='Title']/ancestor::thead/following-sibling::thead//descendant::th[1]/input";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        /// <summary>
        /// Works for Investments, Components, Budget Items
        /// </summary>
        /// <param name="Title"></param>
        /// <returns></returns>
        public IWebElement SelectedItem(string Title)
        {
            string xpath = "//a[text()='" + Title + "']";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        /// <summary>
        /// On the 'Edit Investment' page
        /// </summary>
        /// <returns></returns>
        public IWebElement DescriptionTextArea()
        {
            string xpath = "//label[text()='Description']/parent::div//descendant::textarea";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement RelatedInvestmentSelectField()
        {
            string xpath = "//label[text()='Related Investment']/parent::div/descendant::div//select";
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
            string xpath = "//label[text()='Organization']/parent::div/descendant::div//select";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement EditComponentBtn()
        {
            string xpath = "//a[text()='Edit Component']";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        /// <summary>
        /// On the 'Edit Component' page
        /// </summary>
        /// <returns></returns>
        public IWebElement SummaryTextArea()
        {
            string xpath = "//label[text()='Summary']/parent::div//descendant::textarea";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement DeleteComponentBtn()
        {
            string xpath = "//a[text()='Delete Component']";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement RelatedComponentSelectField()
        {
            string xpath = "//label[text()='Related Component']/parent::div//descendant::div/select";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement FundingTypeSelectField()
        {
            string xpath = "//label[text()='Funding Type']/parent::div//descendant::div/select";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        /// <summary>
        /// On the Create Budget Item page
        /// </summary>
        /// <returns></returns>
        public IWebElement ExpectedOutcomesTextArea()
        {
            string xpath = "//label[text()='Expected Outcomes']/parent::div/child::div/textarea";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement SDLCMethodologySelectField()
        {
            string xpath = "//label[text()='SDLC Methodology']/parent::div/child::div/select";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement CloudServiceSelectField()
        {
            string xpath = "//label[text()='Cloud Service']/parent::div/child::div/select";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement EditBudgetItemBtn()
        {
            string xpath = "//a[text()='Edit Budget Item']";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        /// <summary>
        /// On the Edit Budget Item page
        /// </summary>
        /// <returns></returns>
        public IWebElement BIDescriptionTextArea()
        {
            string xpath = "//label[text()='Budget Item Description']/parent::div//descendant::textarea";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement DeleteBudgetItemBtn()
        {
            string xpath = "//a[text()='Delete Budget Item']";
            return SeleniumDriver.GetElementByXpath(xpath);
        }

        public IWebElement CreateAssignmentBtn()
        {
            string xpath = "//a[contains(@href,'Create')]";
            return SeleniumDriver.GetListElementByXpath(xpath)[0];
        }

        public IWebElement BulkCreateAssignmentsBtn()
        {
            string xpath = "//a[contains(@href,'Create')]";
            return SeleniumDriver.GetListElementByXpath(xpath)[1];
        }

        public IWebElement AmountInputField()
        {
            string xpath = "//label[text()='Amount']/parent::div//descendant::input";
            return SeleniumDriver.GetElementByXpath(xpath);
        }
        

    }
}
