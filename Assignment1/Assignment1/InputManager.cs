namespace Assignment1
{
    internal class InputManager
    {
        /// <summary>
        /// To get valid contact name from the user
        /// </summary>
        /// <param name="_contactList">contact list</param>
        /// <param name="checkDuplicate">whether need to check duplicate or not</param>
        /// <returns>returns the valid user name</returns>
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

        /// <summary>
        /// To get valid phone number from the user.
        /// </summary>
        /// <param name="_contactList">Contact list</param>
        /// <param name="checkDuplicate">whether need to check duplicate or not<</param>
        /// <returns>returns the valid user phone number</returns>
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

        /// <summary>
        /// To get valid email from the user.
        /// </summary>
        /// <param name="_contactList">Contact list</param>
        /// <param name="checkDuplicate">whether need to check duplicate or not<</param>
        /// <returns>returns the valid email</returns>
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

        /// <summary>
        /// To get additional notes from the user.
        /// </summary>
        /// <returns>returns additional notes.</returns>
        public static string GetNotes()
        {
            Console.Write("Enter notes: ");
            string notes = Console.ReadLine();
            return notes;
        }

        /// <summary>
        /// To get contact name or phone number or email from user.
        /// </summary>
        /// <returns>returns contact name or phone number or email</returns>
        public static string GetNameOrPhoneNumberOrEmail()
        {
            Console.Write("Enter name/phoneNumber/email to find contact: ");
            string userInput = Console.ReadLine();
            while(!Validator.ValidateName(userInput) && !Validator.ValidateEmail(userInput) && !Validator.ValidatePhoneNumber(userInput))
            {
                Console.Write("Invalid input! \nEnter name/phoneNumber/email: ");
                userInput = Console.ReadLine();
            }
            return userInput;
        }

        public static string ReadPhoneNumber()
        {
            Console.Write("Enter Phone number: ");
            string phoneNumber = Console.ReadLine();
            if (!Validator.ValidatePhoneNumber(phoneNumber))
            {
                Console.WriteLine("Enter a valid phoneNumber.");
                return null;
            }
            return phoneNumber;
        }

        public static bool GetConfirmation()
        {
            Console.WriteLine("Enter Y/y for confirmation");
            string userInput = Console.ReadLine();
            if(userInput == "y" || userInput == "Y" || userInput == "yes" || userInput == "Yes" || userInput == "YES")
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
