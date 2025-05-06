namespace ContactManager
{
    internal class ConsoleContactApp
    {
        bool isExit = false;
        int userSelection = 0;
        ContactServices contactManager = new ContactServices();

        /// <summary>
        /// To get user input to perform the operation.
        /// </summary>
        public void GetUserInput()
        {
            Console.WriteLine("=== Welcome to Contact Manager!! ===");
            do
            {
                Console.Write("\n1. Add new contact \n2. Edit contact \n3. View contact \n4. Search contact \n5. Delete Contact \n6. Exit\nEnter your choice: ");
                if (int.TryParse(Console.ReadLine(), out userSelection))
                {
                    switch (userSelection)
                    {
                        case 1:
                            Console.WriteLine("Adding new contact...");
                            contactManager.AddContact();
                            break;
                        case 2:
                            Console.WriteLine("Editing the contact...");
                            contactManager.EditContact();
                            break;
                        case 3:
                            Console.WriteLine("All contacts...");
                            contactManager.ViewContact();
                            break;
                        case 4:
                            Console.WriteLine("serach");
                            contactManager.SearchContact();
                            break;
                        case 5:
                            Console.WriteLine("delete");
                            contactManager.DeleteContact();
                            break;
                        case 6:
                            Console.WriteLine("Exit");
                            break;
                        default:
                            Console.WriteLine("Enter a valid input");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Enter valid input");
                }
                if (userSelection == 6)
                {
                    isExit = true;
                }
            } while (!isExit);
        }
    }
}
