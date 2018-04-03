using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthrampFramework.PageObjects;
using NorthrampFramework.Utils_Classes.SeleniumUtils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NorthrampFramework
{
    public class FEDPASSpage
    {
        FEDPASSPO FEDPASSpo = new FEDPASSPO();
        Random rdm = new Random();   

        public void NavigateToFEDPASS()
        {
            SeleniumDriver.GoTo("http://demos.fedpass.com/FEDPASS");
            SeleniumDriver.WaitForDOMready();
        }

        public void Login(string username,string password)
        {
            SeleniumDriver.SetValue(FEDPASSpo.UsernameInputField() , username);
            SeleniumDriver.SetValue(FEDPASSpo.PasswordInputField(), password);
            SeleniumDriver.ClickElement(FEDPASSpo.SignInBtn());
            SeleniumDriver.WaitForDOMready();
            SeleniumDriver.CheckPageTitle("Home");
            Thread.Sleep(2000);
        }

        public void LeftNavigationMenu(string option , string subOption)
        {
            SeleniumDriver.ClickElement(FEDPASSpo.LeftNavigationMainMenuOptions(option));
            SeleniumDriver.ClickElement(FEDPASSpo.LeftNavigationSubMenuOptions(subOption));
            SeleniumDriver.WaitForDOMready();
            Thread.Sleep(3000);
        } 
        
        public void CreateInvestment(string Title)
        {
            SeleniumDriver.CheckPageTitle("Investments"); 
            SeleniumDriver.ClickElement(FEDPASSpo.CreateBtn());
            SeleniumDriver.WaitForDOMready();                     
            SeleniumDriver.SetValue(FEDPASSpo.TitleInputField(), Title);         
            SeleniumDriver.RandomSelectDropDownByIndex(FEDPASSpo.ITDBstatusSelectField());           
            SeleniumDriver.RandomSelectDropDownByIndex(FEDPASSpo.InvestmentTypeSelectField());
            SeleniumDriver.RandomSelectDropDownByIndex(FEDPASSpo.PartOfAgencySelectField());
            SeleniumDriver.RandomSelectDropDownByIndex(FEDPASSpo.CloudComputingEvaluationSelectField());
            SeleniumDriver.ClickElement(FEDPASSpo.SaveBtn());
            Thread.Sleep(2000);
            SeleniumDriver.CheckPageTitle(Title);
        }  

        public void EditInvestment(string Title)
        {
            SeleniumDriver.SetValue(FEDPASSpo.FilterTitleInputField(), Title);
            FEDPASSpo.FilterTitleInputField().SendKeys(Keys.Enter);
            SeleniumDriver.ClickElement(FEDPASSpo.SelectedItem(Title));
            SeleniumDriver.ClickElement(FEDPASSpo.EditInvestmentBtn());
            SeleniumDriver.SetValue(FEDPASSpo.DescriptionTextArea(), "This is an automation test execution");
            SeleniumDriver.ClickElement(FEDPASSpo.SaveBtn());
            Thread.Sleep(2000);
            SeleniumDriver.CheckPageTitle(Title);
        }
        
        public void DeleteInvestment(string Title)
        {
            SeleniumDriver.SetValue(FEDPASSpo.FilterTitleInputField(), Title);
            FEDPASSpo.FilterTitleInputField().SendKeys(Keys.Enter);
            SeleniumDriver.ClickElement(FEDPASSpo.SelectedItem(Title));
            Thread.Sleep(1000);
            SeleniumDriver.ClickElement(FEDPASSpo.DeleteInvestmentBtn());
            SeleniumDriver.ClickElement(FEDPASSpo.YesBtn());
            Thread.Sleep(1000);
            SeleniumDriver.CheckPageTitle("Investments");
        }   
        
        public void CreateComponent(string Title)
        {      
            int rdmCI = rdm.Next(1, 99999);

            SeleniumDriver.CheckPageTitle("Components");
            SeleniumDriver.ClickElement(FEDPASSpo.CreateBtn());
            Thread.Sleep(1000);
            SeleniumDriver.SetValue(FEDPASSpo.TitleInputField(), Title);
            SeleniumDriver.SetValue(FEDPASSpo.CIinputField(), rdmCI.ToString());
            SeleniumDriver.RandomSelectDropDownByIndex(FEDPASSpo.OrganizationSelectField());                                  
            SeleniumDriver.RandomSelectDropDownByIndex(FEDPASSpo.RelatedInvestmentSelectField());
            SeleniumDriver.ClickElement(FEDPASSpo.SaveBtn());
            Thread.Sleep(2000);
            SeleniumDriver.CheckPageTitle(Title);
        }

        public void EditComponent(string Title)
        {
            SeleniumDriver.SetValue(FEDPASSpo.FilterTitleInputField(), Title);
            FEDPASSpo.FilterTitleInputField().SendKeys(Keys.Enter);
            SeleniumDriver.ClickElement(FEDPASSpo.SelectedItem(Title));
            SeleniumDriver.ClickElement(FEDPASSpo.EditComponentBtn());
            SeleniumDriver.SetValue(FEDPASSpo.SummaryTextArea(), "This is an automation test execution");
            SeleniumDriver.ClickElement(FEDPASSpo.SaveBtn());
            Thread.Sleep(2000);
            SeleniumDriver.CheckPageTitle(Title);
        }

        public void DeleteComponent(string Title)
        {
            SeleniumDriver.SetValue(FEDPASSpo.FilterTitleInputField(), Title);
            FEDPASSpo.FilterTitleInputField().SendKeys(Keys.Enter);
            SeleniumDriver.ClickElement(FEDPASSpo.SelectedItem(Title));
            Thread.Sleep(1000);
            SeleniumDriver.ClickElement(FEDPASSpo.DeleteComponentBtn());
            SeleniumDriver.ClickElement(FEDPASSpo.YesBtn());
            Thread.Sleep(1000);
            SeleniumDriver.CheckPageTitle("Components");
        }

        public void CreateBudgetItem(String Title)
        {
            SeleniumDriver.CheckPageTitle("Budget Items");
            SeleniumDriver.ClickElement(FEDPASSpo.CreateBtn());
            Thread.Sleep(1000);
            SeleniumDriver.SetValue(FEDPASSpo.TitleInputField(), Title);          
            SeleniumDriver.SelectDropDownByIndex(FEDPASSpo.RelatedInvestmentSelectField(), 2);
            SeleniumDriver.RandomSelectDropDownByIndex(FEDPASSpo.RelatedComponentSelectField());
            SeleniumDriver.RandomSelectDropDownByIndex(FEDPASSpo.FundingTypeSelectField());
            SeleniumDriver.RandomSelectDropDownByIndex(FEDPASSpo.ITDBstatusSelectField());
            SeleniumDriver.SetValue(FEDPASSpo.ExpectedOutcomesTextArea(), "Test");
            SeleniumDriver.RandomSelectDropDownByIndex(FEDPASSpo.SDLCMethodologySelectField());
            SeleniumDriver.RandomSelectDropDownByIndex(FEDPASSpo.CloudServiceSelectField());
            SeleniumDriver.ClickElement(FEDPASSpo.SaveBtn());
            Thread.Sleep(2000);
            SeleniumDriver.CheckPageTitle(Title);
        }

        public void EditBudgetItem(String Title)
        {
            SeleniumDriver.SetValue(FEDPASSpo.FilterTitleInputField(), Title);
            FEDPASSpo.FilterTitleInputField().SendKeys(Keys.Enter);
            SeleniumDriver.ClickElement(FEDPASSpo.SelectedItem(Title));
            SeleniumDriver.ClickElement(FEDPASSpo.EditBudgetItemBtn());
            SeleniumDriver.SetValue(FEDPASSpo.BIDescriptionTextArea(), "This is an automation test execution");
            SeleniumDriver.ClickElement(FEDPASSpo.SaveBtn());
            Thread.Sleep(2000);
            SeleniumDriver.CheckPageTitle(Title);
        }

        public void DeleteBudgetItem(string Title)
        {
            SeleniumDriver.SetValue(FEDPASSpo.FilterTitleInputField(), Title);
            FEDPASSpo.FilterTitleInputField().SendKeys(Keys.Enter);
            SeleniumDriver.ClickElement(FEDPASSpo.SelectedItem(Title));
            Thread.Sleep(1000);
            SeleniumDriver.ClickElement(FEDPASSpo.DeleteBudgetItemBtn());
            SeleniumDriver.ClickElement(FEDPASSpo.YesBtn());
            Thread.Sleep(2000);
            SeleniumDriver.CheckPageTitle("Budget Items");
        }

        public void CreateAssignment()
        {
            SeleniumDriver.ClickElement(FEDPASSpo.CreateAssignmentBtn());
            Thread.Sleep(1000);
            SeleniumDriver.SetValue(FEDPASSpo.AmountInputField(), "5000");
         
        }
    }
}
