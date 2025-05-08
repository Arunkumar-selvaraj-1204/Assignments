namespace BankingSystem
{
    internal abstract class BankAccount
    {
        public string accountNumber { get; set; }
        public decimal balance { get; set; }

        /// <summary>
        /// Deposits the specified amount into the account and updates the balance.
        /// </summary>
        /// <param name="amount">The amount to be deposited into the account.</param>
        public void DepositAmount(decimal amount)
        {
            balance += amount;
            Console.WriteLine($"Rs.{amount} deposit successfully. Current balance: {balance}");
        }
        public abstract void WithdrawAmount(decimal amount);
    }
}
