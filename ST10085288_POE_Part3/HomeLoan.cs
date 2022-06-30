using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10085288_POE_Part3
{
    internal class HomeLoan : Expenses
    {
        //properties for home loan
        public double PurchaseAmount { get; set; }
        public double InterestRate { get; set; }
        public double DepositAmount { get; set; }
        public double NumMonRepay { get; set; }
        public override double Calculate(double income)//inhertits this method from Expenses and provides it with a body
        {
            return income - CalculateRepayment();
        }

        public double CalculateRepayment()
        {//calculates the  monthly home payment and returns it to the main program
            //calculation method is taken from provided link
            //https://www.siyavula.com/read/maths/grade-10/finance-and-growth/09-finance-and-growth-03
            double totalYears = NumMonRepay / 12;
            double totalAfterDeposit = PurchaseAmount - DepositAmount;
            return Math.Round((totalAfterDeposit * (1 + InterestRate * totalYears)) / NumMonRepay, 2);
        }

    }
}
