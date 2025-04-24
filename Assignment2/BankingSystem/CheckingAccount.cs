using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    internal class CheckingAccount : BankAccount
    {
        public override void WithdrawAmount(decimal amount)
        {
            if (balance - amount < 0)
            {
                Console.WriteLine("Insufficient Balance!!!.");
            }else
            {
                balance -= amount;
                Console.WriteLine($"Rs.{amount} deposit successfully. Current balance: {balance}");
            }
        }
    }
}
