using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment1
{
    internal class Validator
    {
        public static bool ValidateName(string name)
        {
            if(name.Trim() == "")
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

        public static bool IsDuplicateContact(List<Contact> contactList, string name = "", string phoneNumber = "", string email = "")
        {
            if(name != "")
            {
               return contactList.Any(contact => contact.Name.Equals(name.Trim()));
            }if(phoneNumber != "")
            {
               return contactList.Any(contact => contact.PhoneNumber.Equals(phoneNumber.Trim()));
            }if(email != "")
            {
               return contactList.Any(contact => contact.Email.Equals(email.Trim()));
            }
            return false;
        }
    }
}
