using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorHandling
{
    internal class Utils
    {
        public static void PressKeyToContinue()
        {
            Console.WriteLine("Enter any key to continue...");
            Console.ReadKey();
        }
    }
}
