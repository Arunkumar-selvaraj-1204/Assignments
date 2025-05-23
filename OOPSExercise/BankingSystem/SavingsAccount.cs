﻿namespace BankingSystem
{
    internal class SavingsAccount : BankAccount
    {
        /// <summary>
        /// Withdraws the specified amount from the account while ensuring a minimum balance of Rs.100 is maintained.
        /// </summary>
        /// <param name="amount">The amount to withdraw from the account.</param>
        public override void WithdrawAmount(decimal amount)
        {
            if(balance - amount < 100)
            {
                Console.WriteLine("Insufficient Balance!!!. You should maintain Rs.100 as minimum balance.");
                Console.WriteLine($"You can withdraw maximum of {balance-100}");
            }
            else
            {
                balance -= amount;
                Console.WriteLine($"Rs.{amount} withdrawn successfully. Current balance: {balance}");
            }
        }
    }
}
