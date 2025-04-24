using System.Text.RegularExpressions;

namespace Assignment1
{
    internal class Validator
    {
        /// <summary>
        /// To validate conatct name
        /// </summary>
        /// <param name="name">contact name</param>
        /// <returns>return true if contact name is valid otherwise false</returns>
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

        /// <summary>
        /// To validate phone number
        /// </summary>
        /// <param name="phoneNumber">phone number</param>
        /// <returns>return true if phone number is valid otherwise false</returns>
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            string pattern = @"^(\(\d{3}\)\s?|\d{3}-?)?\d{3}-?\d{4}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        /// <summary>
        /// To validate email.
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>return true if email is valid otherwise false</returns>
        public static bool ValidateEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        /// <summary>
        /// To check whether the contact  details or duplicate.
        /// </summary>
        /// <param name="contactList">contact list</param>
        /// <param name="name">contacct name</param>
        /// <param name="phoneNumber">[phone number</param>
        /// <param name="email">email</param>
        /// <returns>returns true if the contact details is duplicate otherwise false</returns>
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

        /// <summary>
        /// To check whether the contact list is empty.
        /// </summary>
        /// <param name="contactList">contact list</param>
        /// <returns>returns true if the list is empty otherwise false</returns>
        public static bool IsContactListEmpty(List <Contact> contactList)
        {
            return contactList.Count == 0;
        }
    }
}
