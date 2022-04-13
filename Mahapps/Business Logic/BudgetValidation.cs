using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahapps.Business_Logic
{
    public static class BudgetValidation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="budget"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>Returns an empty string if no error. If errors, string of those errors</returns>
        public static string ValidateBudget(string budget, DateTime? startDate, DateTime? endDate)
        {
            string errors = "";

            // Budget Amount Validation
            if(budget == "")
            {
                errors += "No Budget Given \n";
            }
            else
            {
                double val;

                bool isNum = double.TryParse(budget, out val);

                if (isNum == false)
                {
                    errors += "Budget Amount Invalid \n";
                }
            }


            // Dates Validation
            if( startDate == null || endDate == null)
            {
                errors += "Invalid Date(s) \n";
            }
            else if(startDate > endDate)
            {
                errors += "Start Date is After End Date \n";
            }
            else if(startDate == endDate)
            {
                errors += "Start Date and End Date are the Same \n";
            }

            return errors;
        }

        public static string ValidateExpense(string title, string amount)
        {
            string errors = "";
            
            // Make sure title isn't blank
            if(title == "" || title == null)
            {
                errors += "Invalid Title \n";
            }

            // Make sure amount is valid
            if(amount != "" || amount == null)
            {
                double val;

                bool isNum = double.TryParse(amount, out val);

                if (isNum == false)
                {
                    errors += "Expense Amount Invalid \n";
                }
            }
            else
            {
                errors += "Invalid Amount \n";
            }

            return errors;
            

        }
    }
}
