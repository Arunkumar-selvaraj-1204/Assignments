namespace BankingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AccountServices accountService = new AccountServices();
            Console.WriteLine("Select Bank account type");
            bool isExit = false;
            while (!isExit)
            {
                int userChoice = ConsoleIOHandler.GetChoice("Savings Account", "Checking Account");
                switch (userChoice)
                {
                    case 1:
                        SavingsAccount SavingsAccount = new SavingsAccount();
                        accountService.OpenAccount(SavingsAccount);
                        break;
                    case 2:
                        CheckingAccount checkingAccount = new CheckingAccount();
                        accountService.OpenAccount(checkingAccount);
                        break;
                    case 3:
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!!");
                        break;
                }
            }
        }
    }
    
}
