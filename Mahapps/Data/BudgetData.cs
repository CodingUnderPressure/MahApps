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

        public static void AddExpenseToDB(Expense expense)
        {
            using(var db = new BudgetContext())
            {
                db.Add(expense);
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

        public static void UpdateBudgetinDb(int budgetKey, DateTime startDate, DateTime endDate, string budgetAmount)
        {
            using(var db = new BudgetContext())
            {
                Budget budget = db.budgets.Find(budgetKey);
                budget.StartDate = startDate;
                budget.EndDate = endDate;
                budget.BudgetAmount = double.Parse(budgetAmount);
                db.SaveChanges();
            }
        }
    }
}
