using static ErrorHandling.ApplicationEnums;

namespace ErrorHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
            bool isExit = false;
            while (!isExit)
            {
                Console.Clear();
                ShowMainMenu();
                try
                {
                    MainMenuChoice userChoise = (MainMenuChoice)int.Parse(Console.ReadLine());
                    switch (userChoise)
                    {
                        case MainMenuChoice.DivideByZero:
                            DivideByZero divideByZero = new DivideByZero();
                            divideByZero = null;
                            break;
                        case MainMenuChoice.ArrayIndexOutOfRange:
                            IndexOutOfRange indexOutOfRange = new IndexOutOfRange();
                            indexOutOfRange = null;
                            break;
                        default:
                            Console.WriteLine("Default");
                            break;
                    }
                }
                catch( FormatException e)
                {
                    Console.WriteLine("Invalid format! Enter valid choice");
                    Utils.PressKeyToContinue();
                    continue;
                }
            }
        }

        /// <summary>
        /// Displays the main menu with options for the user to select a task.
        /// </summary>
        public static void ShowMainMenu()
        {
            Console.WriteLine("1. DivideByZero(Task 1) \n2. IndexOutOfRange(Task 2, Task 3, Task 4, Task 5)");
            Console.Write("Enter choice: ");
        }

        /// <summary>
        /// Handles unhandled exceptions in the application and logs the stack trace.
        /// </summary>
        /// <param name="sender">The source of the unhandled exception event.</param>
        /// <param name="args">The event arguments containing exception information.</param>
        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Console.WriteLine("Unhandled exception caught : " + e.StackTrace); //Task 5
        }

    }
}
