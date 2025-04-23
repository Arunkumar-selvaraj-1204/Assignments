using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class ContactUi
    {
        bool isExit = false;
        int userSelection = 0;
        ContactManager contactManager = new ContactManager();
        
        public void GetUserInput()
        {
                Console.WriteLine("Contact Manager");
            do
                {
                    Console.WriteLine("1. Add new contact \n2. Edit contact \n3. View contact \n4. Search contact \n5. Delete Contact \n6. Exit");
                if (int.TryParse(Console.ReadLine(), out userSelection)){
                    switch (userSelection)
                    {
                        case 1:
                            Console.WriteLine("Add contact");
                            contactManager.AddContact();
                            break;
                        case 2:
                            Console.WriteLine("edit");
                            contactManager.EditContact();
                            break;
                        case 3:
                            Console.WriteLine("view");
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
                } while(!isExit);
        }
    }
}
