using TechTalk.SpecFlow;
using NorthrampFramework;

namespace NorthrampTest
{
    [Binding]

    public sealed class FEDPASS
    {

        [Given(@"I print first name")]
        public void GivenIPrintFirstName()
        {
            NorthrampPages.FEDPASSPage.PrintFName();
        }

        [Given(@"I print last name")]
        public void GivenIPrintLastName()
        {
            NorthrampPages.FEDPASSPage.PrintLName();
        }

    }
}
