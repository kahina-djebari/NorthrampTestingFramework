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
            Thread.Sleep(2000);
            
            SeleniumDriver.SetValue(FEDPASSpo.TitleInputField(), Title);
            Thread.Sleep(2000);
            //SeleniumDriver.ScrollToElement(FEDPASSpo.PartOfAgencySelectField());
            //Thread.Sleep(2000);          
            SeleniumDriver.RandomSelectDropDownByIndex(FEDPASSpo.ITDBstatusSelectField()); //, "Exclude from the ITDB");
            Thread.Sleep(2000);           
            SeleniumDriver.RandomSelectDropDownByIndex(FEDPASSpo.InvestmentTypeSelectField()); //, "01: Major IT Investment");
            Thread.Sleep(2000);
            SeleniumDriver.RandomSelectDropDownByIndex(FEDPASSpo.PartOfAgencySelectField()); //, "Part 1. IT Investments for Mission Delivery");
            Thread.Sleep(2000);
            SeleniumDriver.RandomSelectDropDownByIndex(FEDPASSpo.CloudComputingEvaluationSelectField()); //, "4: Cloud computing has NOT been considered");
            Thread.Sleep(2000);
            SeleniumDriver.ClickElement(FEDPASSpo.SaveBtn());
            Thread.Sleep(2000);
            SeleniumDriver.CheckPageTitle(Title);
            Thread.Sleep(2000);
        }  

        public void EditInvestment(string Title)
        {
            SeleniumDriver.SetValue(FEDPASSpo.FilterTitleInputField(), Title);
            Thread.Sleep(2000);
            FEDPASSpo.FilterTitleInputField().SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            SeleniumDriver.ClickElement(FEDPASSpo.SelectedItem(Title));
            Thread.Sleep(1000);
            SeleniumDriver.ClickElement(FEDPASSpo.EditInvestmentBtn());
            Thread.Sleep(1000);
            SeleniumDriver.SetValue(FEDPASSpo.DescriptionTextArea(), "This is an automation test execution");
            Thread.Sleep(1000);
            SeleniumDriver.ClickElement(FEDPASSpo.SaveBtn());
            Thread.Sleep(2000);
            SeleniumDriver.CheckPageTitle(Title);
            Thread.Sleep(2000);
        }
        
        public void DeleteInvestment(string Title)
        {
            SeleniumDriver.SetValue(FEDPASSpo.FilterTitleInputField(), Title);
            Thread.Sleep(2000);
            FEDPASSpo.FilterTitleInputField().SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            SeleniumDriver.ClickElement(FEDPASSpo.SelectedItem(Title));
            Thread.Sleep(1000);
            SeleniumDriver.ClickElement(FEDPASSpo.DeleteInvestmentBtn());
            Thread.Sleep(2000);
            SeleniumDriver.ClickElement(FEDPASSpo.YesBtn());
            Thread.Sleep(2000);
            SeleniumDriver.CheckPageTitle("Investments");
            Thread.Sleep(2000);
        }   
        
        public void CreateComponent(string Title)
        {      
            int rdmCI = rdm.Next(1, 9999);

            SeleniumDriver.CheckPageTitle("Components");
            SeleniumDriver.ClickElement(FEDPASSpo.CreateBtn());
            Thread.Sleep(2000);
            SeleniumDriver.SetValue(FEDPASSpo.TitleInputField(), Title);
            Thread.Sleep(2000);
            SeleniumDriver.SetValue(FEDPASSpo.CIinputField(), rdmCI.ToString());
            Thread.Sleep(2000);
            SeleniumDriver.RandomSelectDropDownByIndex(FEDPASSpo.OrganizationSelectField());           
            Thread.Sleep(2000);                        
            SeleniumDriver.RandomSelectDropDownByIndex(FEDPASSpo.RelatedInvestmentSelectField());
            Thread.Sleep(2000);
            SeleniumDriver.ClickElement(FEDPASSpo.SaveBtn());
            Thread.Sleep(2000);
            SeleniumDriver.CheckPageTitle(Title);
            Thread.Sleep(2000);
        }

        public void EditComponent(string Title)
        {
            SeleniumDriver.SetValue(FEDPASSpo.FilterTitleInputField(), Title);
            Thread.Sleep(2000);
            FEDPASSpo.FilterTitleInputField().SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            SeleniumDriver.ClickElement(FEDPASSpo.SelectedItem(Title));
            Thread.Sleep(1000);
            SeleniumDriver.ClickElement(FEDPASSpo.EditComponentBtn());
            Thread.Sleep(1000);
            SeleniumDriver.SetValue(FEDPASSpo.SummaryTextArea(), "This is an automation test execution");
            Thread.Sleep(1000);
            SeleniumDriver.ClickElement(FEDPASSpo.SaveBtn());
            Thread.Sleep(2000);
            SeleniumDriver.CheckPageTitle(Title);
            Thread.Sleep(2000);
        }

        public void DeleteComponent(string Title)
        {
            SeleniumDriver.SetValue(FEDPASSpo.FilterTitleInputField(), Title);
            Thread.Sleep(2000);
            FEDPASSpo.FilterTitleInputField().SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            SeleniumDriver.ClickElement(FEDPASSpo.SelectedItem(Title));
            Thread.Sleep(1000);
            SeleniumDriver.ClickElement(FEDPASSpo.DeleteComponentBtn());
            Thread.Sleep(2000);
            SeleniumDriver.ClickElement(FEDPASSpo.YesBtn());
            Thread.Sleep(2000);
            SeleniumDriver.CheckPageTitle("Components");
            Thread.Sleep(2000);
        }
    }
}
