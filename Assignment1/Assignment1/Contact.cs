using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Contact
    {
        private string _name;
        private string _phoneNumber;
        private string _email;
        private string _notes;

        public Contact(string name, string phoneNumber, string email, string notes)
        {
            _name = name;
            _phoneNumber = phoneNumber;
            _email = email;
            _notes = notes;
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }
    }
}
