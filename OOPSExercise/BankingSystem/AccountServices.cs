namespace BankingSystem
{
    internal class AccountServices
    {
        /// <summary>
        /// Allows the user to perform transactions such as deposits and withdrawals.
        /// </summary>
        /// <param name="account">The bank account object that will be initialized and modified with user inputs.</param>
        public void OpenAccount(BankAccount account)
        {
            
            account.accountNumber = ConsoleIOHandler.GetAccountNumber();
            account.balance = ConsoleIOHandler.GetAmount("Balance");
            decimal amount;
            bool isExit = false;
            while (!isExit)
            {
                int userChoice = ConsoleIOHandler.GetChoice("Deposit", "Withdraw");
                switch (userChoice)
                {
                    case 1:
                        amount = ConsoleIOHandler.GetAmount("Deposit Amount");
                        account.DepositAmount(amount);
                        break;
                    case 2:
                        amount = ConsoleIOHandler.GetAmount("Withdrawal Amount");
                        account.WithdrawAmount(amount);
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
