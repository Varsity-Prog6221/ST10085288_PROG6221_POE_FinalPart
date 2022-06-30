using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10085288_POE_Part3
{
    internal class Saving : Expenses
    {
        //properties for saving
        public double SavingAmount { get; set; }
        public double InterestRate { get; set; }
        public double NumMonRepay { get; set; }


        public override double Calculate(double income)//inhertits this method from Expenses and provides it with a body
        {
            return income - CalculateRepayment();
        }
        public double CalculateRepayment()
        {
            //calculates the  monthly saving amount and returns it to the main program
            //link for calculation :https://www.siyavula.com/read/maths/grade-12/finance/03-finance-03
            double totalYears = NumMonRepay/12;
            double i = InterestRate / 12;
            return Math.Round(  (SavingAmount * i)   /   (Math.Pow(1 + i, NumMonRepay) - 1),2);
        }

    }
}
