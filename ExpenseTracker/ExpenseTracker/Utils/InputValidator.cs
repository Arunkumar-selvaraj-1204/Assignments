using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Utils
{
    internal class InputValidator
    {
        public static bool IsValidSource(string source)
        {
            if(string.IsNullOrWhiteSpace(source)) return false; return true;
        }
        public static bool IsValidDate(string date)
        {
            return DateOnly.TryParse(date, out var _validDate);
        }
        public static bool IsValidAmount(string amount)
        {
            if (string.IsNullOrWhiteSpace(amount) || !double.TryParse(amount, out double parsedAmount) || parsedAmount <= 0 ) return false; return true;
        }
    }
}
