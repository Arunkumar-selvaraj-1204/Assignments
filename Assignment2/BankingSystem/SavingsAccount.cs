using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    internal class SavingsAccount : BankAccount
    {
        public override void WithdrawAmount(decimal amount)
        {
            if(balance - amount < 100)
            {
                Console.WriteLine("Insufficient Balance!!!. You should maintain Rs.100 as minimum balance.");
            }
            else
            {
                balance -= amount;
                Console.WriteLine($"Rs.{amount} deposit successfully. Current balance: {balance}");
            }
        }
    }
}
