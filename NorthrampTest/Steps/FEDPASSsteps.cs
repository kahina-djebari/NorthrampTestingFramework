﻿using NorthrampFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace NorthrampTest
{
    [Binding]

    public class FEDPASSsteps
    {
        FEDPASSpage FPpage = new FEDPASSpage();

        [Given(@"I navigate to FEDPASS")]
        public void GivenINavigateToFEDPASS()
        {
            FPpage.NavigateToFEDPASS();
        }

        [Then(@"I login")]
        public void ThenILogin()
        {
            FPpage.Login("kdjebari","kd@2016");
        }

        [Then(@"I navigate to ""(.*)"" and ""(.*)""")]
        public void ThenINavigateToAnd(string option, string subOption)
        {
            FPpage.LeftNavigationMenu(option , subOption);
        }

        [Then(@"I create an Investment with title ""(.*)""")]
        public void ThenICreateAnInvestmentWithTitle(string Title)
        {
            FPpage.CreateInvestment(Title);
        }

        [Then(@"I edit the Investment ""(.*)""")]
        public void ThenIEditTheInvestment(string Title)
        {
            FPpage.EditInvestment(Title);
        }


        [Then(@"I delete the Investment ""(.*)""")]
        public void ThenIDeleteTheInvestment(string Title)
        {
            FPpage.DeleteInvestment(Title);
        }

        [Then(@"I create a Component with title ""(.*)""")]
        public void ThenICreateAComponentWithTitle(string Title)
        {
            FPpage.CreateComponent(Title);
        }

        [Then(@"I edit the component ""(.*)""")]
        public void ThenIEditTheComponent(string Title)
        {
            FPpage.EditComponent(Title);
        }

        [Then(@"I delete the Component ""(.*)""")]
        public void ThenIDeleteTheComponent(string Title)
        {
            FPpage.DeleteComponent(Title);
        }

        [Then(@"I create a Budget Item with title ""(.*)""")]
        public void ThenICreateABudgetItemWithTitle(string Title)
        {
            FPpage.CreateBudgetItem(Title);
        }

        [Then(@"I edit the Budget Item ""(.*)""")]
        public void ThenIEditTheBudgetItem(string Title)
        {
            FPpage.EditBudgetItem(Title);
        }

        [Then(@"I delete the Budget Item ""(.*)""")]
        public void ThenIDeleteTheBudgetItem(string Title)
        {
            FPpage.DeleteBudgetItem(Title);
        }

        [Then(@"I  create a Funding Assignment")]
        public void ThenICreateAFundingAssignment()
        {
            FPpage.CreateAssignment();
        }


    }
}
