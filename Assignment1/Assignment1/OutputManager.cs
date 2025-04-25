namespace Assignment1
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
        public static void PrintContactNames(List<Contact> contactList)
        {
            for (int index = 0; index < contactList.Count; index++)
            {
                Console.WriteLine($"{index + 1}. {contactList[index].Name}");
            }
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
