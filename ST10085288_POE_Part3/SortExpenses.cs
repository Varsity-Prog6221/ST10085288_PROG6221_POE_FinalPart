using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10085288_POE_Part3
{
    internal class SortExpenses : IComparable
    {// class the get the category name and its amount from the user to sort it according to its value
        public string CategoryName { get; set; }
        public double ExpenseAmount { get; set; }


        public SortExpenses(string name, double amount)
        {
            CategoryName = name;
            ExpenseAmount = amount;
        }

        public SortExpenses()
        {
        }
        public int CompareTo(object? obj)
        {
            if (obj is SortExpenses temp)
            {
                return this.ExpenseAmount.CompareTo(temp.ExpenseAmount);
            }
            throw new ArgumentException();
        }
    }
}
