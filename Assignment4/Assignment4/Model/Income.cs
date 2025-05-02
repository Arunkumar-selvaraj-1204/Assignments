using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Model
{
    public class Income
    {

        public string Source { get; set; }
        public DateOnly Date { get; set; }
        public double Amount { get; set; }
        public Income(string source, DateOnly date, double amount)
        {
            Source = source;
            Date = date;
            Amount = amount;
        }

    }
}
