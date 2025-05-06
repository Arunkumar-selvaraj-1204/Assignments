using System.Reflection.Metadata.Ecma335;

namespace ContactManager
{
    internal class ContactServices
    {
        private List<Contact> _contactList = new List<Contact>();

        /// <summary>
        /// To add contact to the list.
        /// </summary>
        public void AddContact()
        {
            Console.Clear();
            ConsoleOutputHandler.PrintCurrentTask("Add");
            string userName = ConsoleInputHandler.GetUserName(_contactList, true);
            string phoneNumber = ConsoleInputHandler.GetPhoneNumber(_contactList, true);
            string email = ConsoleInputHandler.GetEmail(_contactList, true);
            string notes = ConsoleInputHandler.GetNotes();
            Contact newContact = new Contact(userName, phoneNumber, email, notes);
            AddContactToList(newContact);
            ConsoleOutputHandler.PrintSuccessMessaage("add");

        }

        /// <summary>
        /// To edit the existing contact.
        /// </summary>
        public void EditContact()
        {
            if (Validator.IsContactListEmpty(_contactList))
            {
                ConsoleOutputHandler.PrintMessage("EmptyList");
                return;
            }

            Console.Clear();
            ConsoleOutputHandler.PrintCurrentTask("Edit");
            string userInput = ConsoleInputHandler.GetContactInfo();
            Contact selectedContact = Utilities.GetContact(userInput, _contactList);

            if (selectedContact != null)
            {
                ConsoleOutputHandler.PrintMessage("EditChoise");
                ConsoleOutputHandler.PrintContactDetails(selectedContact);
                if (int.TryParse(Console.ReadLine(), out int editOption))
                {
                    int contactIndex = _contactList.IndexOf(selectedContact);
                    selectedContact = EditContactDetail(editOption, selectedContact);
                    _contactList[contactIndex] = selectedContact;
                    _contactList.Sort((c1, c2) => string.Compare(c1.Name, c2.Name, StringComparison.OrdinalIgnoreCase));
                    ConsoleOutputHandler.PrintSuccessMessaage("edit");
                }

            }
            else
            {
                ConsoleOutputHandler.PrintMessage("NotFound");
            }
        }

        /// <summary>
        /// To view all the contact names.
        /// </summary>
        public void ViewContact()
        {
            if (Validator.IsContactListEmpty(_contactList))
            {
                ConsoleOutputHandler.PrintMessage("EmptyList");
                return;
            }
            Console.Clear();
            ConsoleOutputHandler.PrintCurrentTask("View");
            ConsoleOutputHandler.PrintContactDetails(_contactList);
            ConsoleOutputHandler.PrintSuccessMessaage("view");
        }

        /// <summary>
        /// To search a particular contact using name or phone number.
        /// </summary>
        public void SearchContact()
        {
            if (Validator.IsContactListEmpty(_contactList))
            {
                ConsoleOutputHandler.PrintMessage("EmptyList");
                return;
            }
            Console.Clear();
            ConsoleOutputHandler.PrintCurrentTask("Search");
            string userInput = ConsoleInputHandler.GetContactInfo();
            Contact searchedContact = Utilities.GetContact(userInput, _contactList);

            if (searchedContact != null)
            {
                ConsoleOutputHandler.PrintContactDetails(searchedContact);
                ConsoleOutputHandler.PrintSuccessMessaage("search");
            }
            else
            {
                ConsoleOutputHandler.PrintMessage("NotFound");
            }
        }

        /// <summary>
        /// To delete a particular contact.
        /// </summary>
        public void DeleteContact()
        {
            if (Validator.IsContactListEmpty(_contactList))
            {
                ConsoleOutputHandler.PrintMessage("EmptyList");
                return;
            }
            Console.Clear();
            ConsoleOutputHandler.PrintCurrentTask("Delete");
            string userInput = ConsoleInputHandler.GetContactInfo();
            Contact searchedContact = Utilities.GetContact(userInput, _contactList);
            if (searchedContact != null)
            {
                ConsoleOutputHandler.PrintContactDetails(searchedContact);
                bool isConfirm = ConsoleInputHandler.GetConfirmation();
                if (isConfirm)
                {
                    int contactIndex = _contactList.IndexOf(searchedContact);
                    _contactList.RemoveAt(contactIndex);
                    ConsoleOutputHandler.PrintSuccessMessaage("delete");
                }
                else
                {
                    Utilities.PrintColorMessage("Confirmation denied", ConsoleColor.Red);
                    Console.WriteLine("Contact not get deleted");
                    ConsoleOutputHandler.PrintPressKeyToContinueMessage();
                }
                
            }
            else
            {
                ConsoleOutputHandler.PrintMessage("NotFound");
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
                    string userName = ConsoleInputHandler.GetUserName(_contactList, true);
                    contact.Name = userName;
                    break;
                case 2:
                    string phoneNumber = ConsoleInputHandler.GetPhoneNumber(_contactList, true);
                    contact.PhoneNumber = phoneNumber;
                    break;
                case 3:
                    string email = ConsoleInputHandler.GetEmail(_contactList, true);
                    contact.Email = email;
                    break;
                case 4:
                    string notes = ConsoleInputHandler.GetNotes();
                    contact.Notes = notes;
                    break;
            }
            return contact;
        }
    }
}
