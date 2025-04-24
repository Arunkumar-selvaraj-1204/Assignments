namespace BankingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AccountManager accountManager = new AccountManager();
            Console.WriteLine("Select Bank account type");
            bool isExit = false;
            while (!isExit)
            {
                int userChoice = IOManager.GetChoice("Savings Account", "Checking Account");
                switch (userChoice)
                {
                    case 1:
                        SavingsAccount SavingsAccount = new SavingsAccount();
                        accountManager.OpenAccount(SavingsAccount);
                        break;
                    case 2:
                        CheckingAccount checkingAccount = new CheckingAccount();
                        accountManager.OpenAccount(checkingAccount);
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
