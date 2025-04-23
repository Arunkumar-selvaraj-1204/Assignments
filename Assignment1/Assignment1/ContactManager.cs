using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class ContactManager
    {
        private List<Contact> _contactList= new List<Contact> ();
        public void AddContact()
        {
            Console.WriteLine("Enter contact name:");
            String userName = Console.ReadLine();
            while (!Validator.ValidateName(userName))
            {
                Console.WriteLine("Enter a valid name");
                userName = Console.ReadLine();
            }
            Console.WriteLine("Enter Phone number:");
            string phoneNumber = Console.ReadLine();
            while (!Validator.ValidatePhoneNumber(phoneNumber))
            {
                Console.WriteLine("Enter valid Phone number");
                phoneNumber = Console.ReadLine();
            }
            Console.WriteLine("Enter email address");
            string email = Console.ReadLine();
            while (!Validator.ValidateEmail(email))
            {
                Console.WriteLine("Enter valid email");
                email = Console.ReadLine();
            }
            Console.WriteLine("Enter notes");
            string notes = Console.ReadLine();
            Contact newContact = new Contact(userName, phoneNumber, email, notes);
            AddContactToList(newContact);
            Console.WriteLine("Close");
            
        }

        public void ViewContact()
        {
            for(int index = 0; index < _contactList.Count; index++)
            {
                Console.WriteLine($"{index + 1}. {_contactList[index].Name}");
            }
        }

        public void SearchContact()
        {
            Console.WriteLine("Enter userName/phoneNumber:");
            string userInput = Console.ReadLine();
            Contact searchedContact = null;
            if (long.TryParse(userInput, out long PhoneNumber))
            {
                while (!Validator.ValidatePhoneNumber(userInput))
                {
                    Console.WriteLine("Enter valid user name/PhoneNumber");
                    userInput = Console.ReadLine();
                }
                searchedContact = GetContactByPhoneNumber(userInput);
            }
            else
            {
                while (!Validator.ValidateName(userInput))
                {
                    Console.WriteLine("Enter valid user name/PhoneNumber");
                    userInput = Console.ReadLine();
                }
                searchedContact = GetContactByName(userInput);
            }

            if (searchedContact != null)
            {
                Console.WriteLine($"Name: {searchedContact.Name}");
                Console.WriteLine($"PhoneNumber: {searchedContact.PhoneNumber}");
                Console.WriteLine($"Email:  {searchedContact.Email}");
                Console.WriteLine($"Notes: {searchedContact.Notes}");
            }
            else
            {
                Console.WriteLine("Contact not Found!");
            }
            }

        private Contact GetContactByPhoneNumber(string phoneNumber)
        {
            foreach (Contact contact in _contactList)
            {
                if (contact.PhoneNumber == phoneNumber)
                {
                    return contact;
                }
            }
            return null;
        }


        // Helper functions
        void AddContactToList(Contact contact)
        {
            _contactList.Add(contact);
            _contactList.Sort((c1, c2) => string.Compare(c1.Name, c2.Name, StringComparison.OrdinalIgnoreCase));
        }

        Contact GetContactByName(string userName)
        {
            foreach (Contact contact in _contactList)
            {
                if (contact.Name == userName)
                {
                    return contact;
                }
                else if (contact.Email == userName)
                {
                    return contact;
                }
            }
            return null;
        }
    }
}
