namespace BankingSystem
{
    internal class CheckingAccount : BankAccount
    {
        /// <summary>
        /// Withdraws the specified amount from the account if the balance is sufficient.
        /// </summary>
        /// <param name="amount">The amount to withdraw from the account.</param>

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
