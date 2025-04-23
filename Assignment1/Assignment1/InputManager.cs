namespace Assignment1
{
    internal class InputManager
    {
        public static string GetUserName(List<Contact> _contactList, bool checkDuplicate)
        {
            Console.Write("Enter contact name: ");
            String userName = Console.ReadLine();
            while (!Validator.ValidateName(userName) || checkDuplicate && Validator.IsDuplicateContact(_contactList, userName))
            {
                string message = checkDuplicate ? "Enter a valid name and it should not be duplicate" : "Enter valid name";
                Console.WriteLine(message);
                Console.Write("Enter contact name: ");
                userName = Console.ReadLine();
            }
            return userName;
        }

        public static string GetPhoneNumber(List<Contact> _contactList, bool checkDuplicate)
        {
            Console.Write("Enter Phone number: ");
            string phoneNumber = Console.ReadLine();
            while (!Validator.ValidatePhoneNumber(phoneNumber) || checkDuplicate && Validator.IsDuplicateContact(_contactList, "", phoneNumber))
            {
                string message = checkDuplicate ? "Enter a valid phoneNumber and it should not be duplicate" : "Enter valid PhoneNumber";
                Console.WriteLine(message);
                Console.Write("Enter Phone number: ");
                phoneNumber = Console.ReadLine();
            }
            return phoneNumber;
        }

        public static string GetEmail(List<Contact> _contactList, bool checkDuplicate)
        {
            Console.Write("Enter email address: ");
            string email = Console.ReadLine();
            while (!Validator.ValidateEmail(email) || Validator.IsDuplicateContact(_contactList, "", "", email))
            {
                string message = checkDuplicate ? "Enter a valid email and it should not be duplicate" : "Enter valid email";
                Console.WriteLine(message);
                Console.Write("Enter email address: ");
                email = Console.ReadLine();
            }
            return email;
        }

        public static string GetNotes()
        {
            Console.Write("Enter notes: ");
            string notes = Console.ReadLine();
            return notes;
        }
        public static string GetNameOrPhoneNumber()
        {
            Console.Write("Enter userName/phoneNumber to search:");
            string userInput = Console.ReadLine();
            return userInput;
        }

        public static string GetNameOrPhoneNumberOrEmail()
        {
            Console.Write("Enter name/phoneNumber/email to delete");
            string userInput = Console.ReadLine();
            return userInput;
        }
    }
}
