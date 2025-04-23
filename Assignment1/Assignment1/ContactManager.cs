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
            _contactList.Add(newContact);
            Console.WriteLine("Close");
            
        }

        public void ViewContact()
        {
            foreach(Contact contact in _contactList)
            {
                Console.WriteLine(contact.Name);
            }
        }
    }
}
