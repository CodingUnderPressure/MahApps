using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahapps.Models
{
    public class Expense
    {
        public int Id { get; set; }

        public int BudgetId { get; set; }

        public string Title { get; set; }

        public double Amount { get; set; }
    }
}
