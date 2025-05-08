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
        public static void ShowMainMenu()
        {
            Console.WriteLine("1. DivideByZero \n2. IndexOutOfBound");
            Console.Write("Enter choice: ");
        }
        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Console.WriteLine("Unhandled exception caught : " + e.Message);
        }

    }
}
