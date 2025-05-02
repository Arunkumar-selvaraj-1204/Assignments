using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Model
{
    internal class ApplicationEnum
    {
        public enum MainMenu
        {
            TrackIncome = 1,
            TrackExpense = 2,
            FinancialSummary = 3,
            Exit = 4,

        }

        public enum IncomeChoice
        {
            AddIncome  = 1,
            EditIncome = 2,
            DeleteIncome = 3,
            ShowAllIncome = 4,
            MainMenu = 5,
        }
    }
}
