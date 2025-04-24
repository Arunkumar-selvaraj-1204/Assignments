using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Utilities
    {
        /// <summary>
        /// To find the contact using phone number.
        /// </summary>
        /// <param name="phoneNumber">phone number</param>
        /// <param name="contacts">contact list</param>
        /// <returns>return the contact if exist otherwis returns null</returns>
        public static Contact GetContactByPhoneNumber(string phoneNumber, List<Contact> contacts)
        {
            foreach (Contact contact in contacts)
            {
                if (contact.PhoneNumber == phoneNumber)
                {
                    return contact;
                }
            }
            return null;
        }

        /// <summary>
        /// To find the contact using name or email
        /// </summary>
        /// <param name="userInput">contact name or email</param>
        /// <param name="contacts">contact list</param>
        /// <returns>return the contact if exist otherwis returns null</returns>
        public static Contact GetContactByNameOrEmail(string userInput, List<Contact> contacts)
        {
            foreach (Contact contact in contacts)
            {
                if (contact.Name == userInput)
                {
                    return contact;
                }
                else if (contact.Email == userInput)
                {
                    return contact;
                }
            }
            return null;
        }

        /// <summary>
        /// To print the colored message in the console.
        /// </summary>
        /// <param name="message">message to print</param>
        /// <param name="color">color of the message</param>
        public static void PrintColorMessage(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
