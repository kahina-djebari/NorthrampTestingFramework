using NorthrampFramework.Utils_Classes.SeleniumUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthrampFramework
{
    public class FEDPASSPage : PageModel
    {

        public void PrintFName()
        {
            SeleniumDriver.PrintToTheConsole("Kahina");
        }

        public void PrintLName()
        {
            SeleniumDriver.PrintToTheConsole("Djebari");
        }
    }
}
