using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Validator
    {
        public static bool ValidateName(string name)
        {
            if(name == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            string pattern = @"^(\(\d{3}\)\s?|\d{3}-?)?\d{3}-?\d{4}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        public static bool ValidateEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
