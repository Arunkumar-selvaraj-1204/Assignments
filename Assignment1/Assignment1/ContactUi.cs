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
                    Console.WriteLine("1. Add new contact \n2. Edit contact \n3. View contact \n4. Delete contact \n5. Exit");
                if (int.TryParse(Console.ReadLine(), out userSelection)){
                    switch (userSelection)
                    {
                        case 1:
                            Console.WriteLine("Add contact");
                            contactManager.AddContact();
                            break;
                        case 2:
                            Console.WriteLine("edit");
                            break;
                        case 3:
                            Console.WriteLine("view");
                            contactManager.ViewContact();
                            break;
                        case 4:
                            Console.WriteLine("delete");
                            break;
                        case 5:
                            Console.WriteLine("exit");
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
                if (userSelection == 5)
                {
                    isExit = true;
                }
                } while(!isExit);
        }
    }
}
