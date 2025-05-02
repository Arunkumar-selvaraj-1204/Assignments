using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Model
{
    internal class Expense
    {
        private string _category;
        private DateOnly _date;
        private double _amount;

        public Expense(string category, DateOnly date, double amount)
        {
            _category = category;
            _date = date;
            _amount = amount;
        }
    }
}
