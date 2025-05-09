using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Model
{
    public class Expense
    {
        public string Category { get; set; }
        public DateOnly Date { get; set; }
        public double Amount { get; set; }

        public Expense(string category, DateOnly date, double amount)
        {
            Category = category;
            Date = date;
            Amount = amount;
        }
    }
}
