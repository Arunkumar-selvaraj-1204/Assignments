using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    internal class AccountManager
    {
        public void OpenAccount(BankAccount account)
        {
            
            account.accountNumber = IOManager.GetAccountNumber();
            account.balance = IOManager.GetAmount("Balance");
            decimal amount;
            bool isExit = false;
            while (!isExit)
            {
                int userChoice = IOManager.GetChoice("Deposit", "Withdraw");
                switch (userChoice)
                {
                    case 1:
                        amount = IOManager.GetAmount("Deposit Amount");
                        account.DepositAmount(amount);
                        break;
                    case 2:
                        amount = IOManager.GetAmount("Withdrawal Amount");
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
