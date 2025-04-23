using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Utilities
    {
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

        public static void PrintColorMessage(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
