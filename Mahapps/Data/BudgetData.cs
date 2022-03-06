using Mahapps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahapps.Data
{
    public static class BudgetData
    {
        public static void AddBudgetToDb(Budget budget)
        {
            using(var db = new BudgetContext())
            {
                db.Add(budget);
                db.SaveChanges();
            }
        }

        public static List<Budget> GetBudgets()
        {
            using(var db = new BudgetContext())
            {
                return db.budgets.OrderBy(b => b.Id).ToList();
            }
        }
    }
}
