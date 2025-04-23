namespace Assignment1
{
    internal class OutputManager
    {
        public static void PrintMessage(string message)
        {
            switch (message)
            {
                case "EmptyList":
                    Utilities.PrintColorMessage("Your Contact list is empty", ConsoleColor.Red);
                    break;
                case "NotFound":
                    Utilities.PrintColorMessage("Contact Not Found!", ConsoleColor.Red);
                    break;
                case "EditChoise":
                    Utilities.PrintColorMessage("\nEnter the choise to edit: ", ConsoleColor.Red);
                    break;
            }
        }

        public static void PrintContactDetails(Contact contact)
        {
            Console.WriteLine($"1.Name: {contact.Name}");
            Console.WriteLine($"2.PhoneNumber: {contact.PhoneNumber}");
            Console.WriteLine($"3.Email:  {contact.Email}");
            Console.WriteLine($"4.Notes: {contact.Notes}");
        }

        public static void PrintContactNames(List<Contact> contactList)
        {
            for (int index = 0; index < contactList.Count; index++)
            {
                Console.WriteLine($"{index + 1}. {contactList[index].Name}");
            }
        }
    }
}
