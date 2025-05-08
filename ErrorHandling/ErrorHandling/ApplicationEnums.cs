using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorHandling
{
    internal static class ApplicationEnums
    {
        public enum DivisionInput
        {
            dividend = 1,
            divisor = 2,
        }
        public enum MainMenuChoice
        {
            DivideByZero = 1,
            ArrayIndexOutOfRange = 2,
            InvalidUserInputException = 3,
            UnhandledException = 4,
            StackTrace = 5,

        }
    }
}
