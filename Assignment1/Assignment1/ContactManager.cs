namespace Assignment1
{
    internal class ContactManager
    {
        private List<Contact> _contactList= new List<Contact> ();
        public void AddContact()
        {
            string userName = InputManager.GetUserName(_contactList, true);
            string phoneNumber = InputManager.GetPhoneNumber(_contactList, true);
            string email = InputManager.GetEmail(_contactList, true);
            string notes = InputManager.GetNotes();
            Contact newContact = new Contact(userName, phoneNumber, email, notes);
            AddContactToList(newContact);
            
        }

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
                if (int.TryParse(Console.ReadLine(), out int editOption)){
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
        public void ViewContact()
        {
            if( Validator.IsContactListEmpty(_contactList))
            {
                OutputManager.PrintMessage("EmptyList");
                return;
            }
            OutputManager.PrintContactNames(_contactList);
        }

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

        void AddContactToList(Contact contact)
        {
            _contactList.Add(contact);
            _contactList.Sort((c1, c2) => string.Compare(c1.Name, c2.Name, StringComparison.OrdinalIgnoreCase));
        }

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
        
        Contact EditContactDetail(int option, Contact contact)
        {
            switch(option)
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
