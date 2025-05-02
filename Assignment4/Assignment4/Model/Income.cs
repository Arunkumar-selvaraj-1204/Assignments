using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Model
{
    internal class Income
    {
        private string _source;
        private DateOnly _date;
        private double _amount;

        public Income(string source, DateOnly date, double amount)
        {
            _source = source;
            _date = date;
            _amount = amount;
        }

    }
}
