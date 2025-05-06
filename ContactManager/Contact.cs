namespace ContactManager
{
    internal class Contact
    {
        private string _name;
        private string _phoneNumber;
        private string _email;
        private string _notes;

        /// <summary>
        /// To initialize fields.
        /// </summary>
        /// <param name="name">Name of the contact</param>
        /// <param name="phoneNumber">Phone number of the contact</param>
        /// <param name="email">Email of the contact</param>
        /// <param name="notes">Notes of the contact</param>
        public Contact(string name, string phoneNumber, string email, string notes)
        {
            _name = name;
            _phoneNumber = phoneNumber;
            _email = email;
            _notes = notes;
        }

        /// <summary>
        /// To get and set the name of the contact
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// To get and set the phone number of the contact
        /// </summary>
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        /// <summary>
        /// To get and set the email of the contact
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>
        /// To get and set the notes of the contact
        /// </summary>
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }
    }
}
