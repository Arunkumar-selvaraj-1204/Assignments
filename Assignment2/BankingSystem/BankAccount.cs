using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    internal abstract class BankAccount
    {
        public string accountNumber { get; set; }
        public decimal balance { get; set; }

        public void DepositAmount(decimal amount)
        {
            balance += amount;
            Console.WriteLine($"Rs.{amount} deposit successfully. Current balance: {balance}");
        }
        public abstract void WithdrawAmount(decimal amount);
    }
}
