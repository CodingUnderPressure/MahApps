using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahapps.Models
{
    public class BudgetContext : DbContext
    {
        public DbSet<Budget> budgets { get; set; }

        public DbSet<Expense> expenses { get; set; }

        public string path = @"C:\Temp\budget.db";

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={path}");
    }
}
