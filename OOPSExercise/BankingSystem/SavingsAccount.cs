namespace BankingSystem
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
            }
            else
            {
                balance -= amount;
                Console.WriteLine($"Rs.{amount} deposit successfully. Current balance: {balance}");
            }
        }
    }
}
