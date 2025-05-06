using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    internal class Utilities
    {

        /// <summary>
        /// To find the contact using name or email
        /// </summary>
        /// <param name="userInput">contact name or email</param>
        /// <param name="contacts">contact list</param>
        /// <returns>return the contact if exist otherwis returns null</returns>
        public static Contact GetContact(string userInput, List<Contact> contacts)
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
                else if (contact.PhoneNumber == userInput)
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
