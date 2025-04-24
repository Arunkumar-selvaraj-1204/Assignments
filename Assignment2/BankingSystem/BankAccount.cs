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
        }
        public abstract void WithdrawAmount(decimal amount);
    }
}
