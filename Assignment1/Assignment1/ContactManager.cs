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

        public void EditContact()
        {
            Console.WriteLine("Enter user name:");
            String userName = Console.ReadLine();
            Contact selectedContact = FindContact(userName);
            if (selectedContact != null)
            {
                Console.WriteLine($"1.Name: {selectedContact.Name}");
                Console.WriteLine($"2.PhoneNumber: {selectedContact.PhoneNumber}");
                Console.WriteLine($"3.Email:  {selectedContact.Email}");
                Console.WriteLine($"4.Notes: {selectedContact.Notes}");
                if(int.TryParse(Console.ReadLine(), out int editOption)){
                    int contactIndex = _contactList.IndexOf(selectedContact);
                    selectedContact = EditContactDetail(editOption, selectedContact);
                    _contactList[contactIndex] = selectedContact;
                }
                
            }
            else
            {
                Console.WriteLine("Contact Not Found!");
            }

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
            Console.WriteLine("Enter userName/phoneNumber to search:");
            string userInput = Console.ReadLine();
            Contact searchedContact = FindContact(userInput);
            
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

        public void DeleteContact()
        {
            Console.WriteLine("Enter name/phoneNumber/email to delete");
            string userInput = Console.ReadLine();
            Contact searchedContact = FindContact(userInput);
            if (searchedContact != null)
            {
                int contactIndex = _contactList.IndexOf(searchedContact);
                _contactList.RemoveAt(contactIndex);
            }
            else
            {
                Console.WriteLine("Contact not Found!");
            }

        }

        // Helper functions

        void AddContactToList(Contact contact)
        {
            _contactList.Add(contact);
            _contactList.Sort((c1, c2) => string.Compare(c1.Name, c2.Name, StringComparison.OrdinalIgnoreCase));
        }

        Contact FindContact(string userInput)
        {
            if (long.TryParse(userInput, out long PhoneNumber))
            {
                while (!Validator.ValidatePhoneNumber(userInput))
                {
                    Console.WriteLine("Enter valid userName/PhoneNumber");
                    userInput = Console.ReadLine();
                }
                return GetContactByPhoneNumber(userInput);
            }
            else
            {
                while (!Validator.ValidateName(userInput))
                {
                    Console.WriteLine("Enter valid userName/PhoneNumber");
                    userInput = Console.ReadLine();
                }
                return GetContactByName(userInput);
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
        Contact EditContactDetail(int option, Contact contact)
        {
            switch(option)
            {
                case 1:
                    Console.WriteLine("Enter name");
                    string userName = Console.ReadLine();
                    while (!Validator.ValidateName(userName))
                    {
                        Console.WriteLine("Enter a valid name");
                        userName = Console.ReadLine();
                    }
                    contact.Name = userName;
                    break;
                case 2:
                    Console.WriteLine("Enter Phone Number");
                    string phoneNumber = Console.ReadLine();
                    while (!Validator.ValidateName(phoneNumber))
                    {
                        Console.WriteLine("Enter a valid Phone number");
                        phoneNumber = Console.ReadLine();
                    }
                    contact.PhoneNumber = phoneNumber;
                    break;
                case 3:
                    Console.WriteLine("Enter email");
                    string email = Console.ReadLine();
                    while (!Validator.ValidateName(email))
                    {
                        Console.WriteLine("Enter a valid name");
                        email = Console.ReadLine();
                    }
                    contact.Email = email;
                    break;
                case 4:
                    Console.WriteLine("Enter notes");
                    string notes = Console.ReadLine();
                    while (!Validator.ValidateName(notes))
                    {
                        Console.WriteLine("Enter a valid name");
                        notes = Console.ReadLine();
                    }
                    contact.Notes = notes;
                    break;
            }
            return contact;
        }
    }
}
