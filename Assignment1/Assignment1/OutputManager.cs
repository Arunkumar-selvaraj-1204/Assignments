namespace ContactManager
{
    internal class OutputManager
    {
        /// <summary>
        /// To print the correct message in the console.
        /// </summary>
        /// <param name="message">message to check condition.</param>
        public static void PrintMessage(string message)
        {
            switch (message)
            {
                case "EmptyList":
                    Utilities.PrintColorMessage("Your Contact list is empty", ConsoleColor.Red);
                    PrintPressKeyToContinueMessage();
                    break;
                case "NotFound":
                    Utilities.PrintColorMessage("Contact Not Found!", ConsoleColor.Red);
                    PrintPressKeyToContinueMessage();
                    break;
                case "EditChoise":
                    Console.WriteLine("\nEnter the choise to edit: ");
                    break;
            }
        }

        /// <summary>
        /// To print contact details.
        /// </summary>
        /// <param name="contact">particular contact</param>
        public static void PrintContactDetails(Contact contact)
        {
            Console.WriteLine($"1.Name: {contact.Name}");
            Console.WriteLine($"2.PhoneNumber: {contact.PhoneNumber}");
            Console.WriteLine($"3.Email:  {contact.Email}");
            Console.WriteLine($"4.Notes: {contact.Notes}");
        }

        /// <summary>
        /// To print all the contact name in the list.
        /// </summary>
        /// <param name="contactList">contact list</param>
        public static void PrintContactDetails(List<Contact> contactList)
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine($"{"No.",-5} {"Name",-20} {"Phone Number",-15} {"Email",-25} {"Notes",-20}");
            Console.WriteLine("---------------------------------------------------------------------------------------------");

            for (int i = 0; i < contactList.Count; i++)
            {
                var contact = contactList[i];
                Console.WriteLine($"{i + 1,-5} {contact.Name,-20} {contact.PhoneNumber,-15} {contact.Email,-25} {contact.Notes,-20}");
            }

            Console.WriteLine("---------------------------------------------------------------------------------------------");
        }


        /// <summary>
        /// To print the current task.
        /// </summary>
        /// <param name="taskName">Current task</param>
        public static void PrintCurrentTask(string taskName)
        {
            Console.WriteLine($"-------- {taskName} contact --------");
        }

        public static void PrintPressKeyToContinueMessage()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        public static void PrintSuccessMessaage(string message)
        {
            switch (message)
            {
                case "add":
                    Utilities.PrintColorMessage("New contact added successfully!", ConsoleColor.Green);
                    PrintPressKeyToContinueMessage();
                    break;
                case "edit":
                    Utilities.PrintColorMessage("Contact edited successfully!", ConsoleColor.Green);
                    PrintPressKeyToContinueMessage();
                    break;
                case "view":
                    PrintPressKeyToContinueMessage();
                    break;
                case "search":
                    PrintPressKeyToContinueMessage();
                    break;
                case "delete":
                    Utilities.PrintColorMessage("Contact deleted successfully!", ConsoleColor.Green);
                    PrintPressKeyToContinueMessage();
                    break;
            }
        }
    }
}
