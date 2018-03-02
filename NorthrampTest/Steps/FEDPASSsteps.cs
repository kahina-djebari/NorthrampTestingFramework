using NorthrampFramework;
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
            FPpage.Login("kdjebari","Nina@usa2016");
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

    }
}
