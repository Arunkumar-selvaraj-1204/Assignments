namespace Assignment1
{
    internal class ContactManager
    {
        private List<Contact> _contactList = new List<Contact>();

        /// <summary>
        /// To add contact to the list.
        /// </summary>
        public void AddContact()
        {
            string userName = InputManager.GetUserName(_contactList, true);
            string phoneNumber = InputManager.GetPhoneNumber(_contactList, true);
            string email = InputManager.GetEmail(_contactList, true);
            string notes = InputManager.GetNotes();
            Contact newContact = new Contact(userName, phoneNumber, email, notes);
            AddContactToList(newContact);

        }

        /// <summary>
        /// To edit the existing contact.
        /// </summary>
        public void EditContact()
        {
            if (Validator.IsContactListEmpty(_contactList))
            {
                OutputManager.PrintMessage("EmptyList");
                return;
            }
            string userName = InputManager.GetUserName(_contactList, false);
            Contact selectedContact = FindContact(userName);
            if (selectedContact != null)
            {
                OutputManager.PrintMessage("EditChoise");
                OutputManager.PrintContactDetails(selectedContact);
                if (int.TryParse(Console.ReadLine(), out int editOption))
                {
                    int contactIndex = _contactList.IndexOf(selectedContact);
                    selectedContact = EditContactDetail(editOption, selectedContact);
                    _contactList[contactIndex] = selectedContact;
                    _contactList.Sort((c1, c2) => string.Compare(c1.Name, c2.Name, StringComparison.OrdinalIgnoreCase));
                }

            }
            else
            {
                OutputManager.PrintMessage("NotFound");
            }
        }

        /// <summary>
        /// To view all the contact names.
        /// </summary>
        public void ViewContact()
        {
            if (Validator.IsContactListEmpty(_contactList))
            {
                OutputManager.PrintMessage("EmptyList");
                return;
            }
            OutputManager.PrintContactNames(_contactList);
        }

        /// <summary>
        /// To search a particular contact using name or phone number.
        /// </summary>
        public void SearchContact()
        {
            if (Validator.IsContactListEmpty(_contactList))
            {
                OutputManager.PrintMessage("EmptyList");
                return;
            }
            string userInput = InputManager.GetNameOrPhoneNumber();
            Contact searchedContact = FindContact(userInput);

            if (searchedContact != null)
            {
                OutputManager.PrintContactDetails(searchedContact);
            }
            else
            {
                OutputManager.PrintMessage("NotFound");
            }
        }

        /// <summary>
        /// To delete a particular contact.
        /// </summary>
        public void DeleteContact()
        {
            if (Validator.IsContactListEmpty(_contactList))
            {
                OutputManager.PrintMessage("EmptyList");
                return;
            }
            string userInput = InputManager.GetNameOrPhoneNumberOrEmail();
            Contact searchedContact = FindContact(userInput);
            if (searchedContact != null)
            {
                int contactIndex = _contactList.IndexOf(searchedContact);
                _contactList.RemoveAt(contactIndex);
            }
            else
            {
                OutputManager.PrintMessage("NotFound");
            }

        }

        // Helper functions

        /// <summary>
        /// To add the contact in the list in sorted order.
        /// </summary>
        /// <param name="contact">Represents the particular contact</param>
        void AddContactToList(Contact contact)
        {
            _contactList.Add(contact);
            _contactList.Sort((c1, c2) => string.Compare(c1.Name, c2.Name, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// To find a contact using name or email or phone number.
        /// </summary>
        /// <param name="userInput">user input which is name or email or phone number</param>
        /// <returns>Returns the contact if exist otherwise null </returns>
        Contact FindContact(string userInput)
        {
            if (long.TryParse(userInput, out long PhoneNumber))
            {
                userInput = InputManager.GetPhoneNumber(_contactList, false);
                return Utilities.GetContactByPhoneNumber(userInput, _contactList);
            }
            else
            {
                while (!Validator.ValidateName(userInput))
                {
                    Console.WriteLine("Enter valid userName/email and it should not be duplicate");
                    Console.Write("Enter UserName/email: ");
                    userInput = Console.ReadLine();
                }
                return Utilities.GetContactByNameOrEmail(userInput, _contactList);
            }
        }

        /// <summary>
        /// To edit the contact based on the option.
        /// </summary>
        /// <param name="option">contact detail to edit</param>
        /// <param name="contact">particular contact</param>
        /// <returns>edited contact</returns>
        Contact EditContactDetail(int option, Contact contact)
        {
            switch (option)
            {
                case 1:
                    string userName = InputManager.GetUserName(_contactList, true);
                    contact.Name = userName;
                    break;
                case 2:
                    string phoneNumber = InputManager.GetPhoneNumber(_contactList, true);
                    contact.PhoneNumber = phoneNumber;
                    break;
                case 3:
                    string email = InputManager.GetEmail(_contactList, true);
                    contact.Email = email;
                    break;
                case 4:
                    string notes = InputManager.GetNotes();
                    contact.Notes = notes;
                    break;
            }
            return contact;
        }
    }
}
