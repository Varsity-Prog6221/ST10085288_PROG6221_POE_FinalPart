using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10085288_POE_Part3
{
    internal class Vehicle : Expenses
    {
        //properties for vehicle
        public double PurchaseAmount { get; set; }
        public double InterestRate { get; set; }
        public double DepositAmount { get; set; }
        public double InsuranceAmount { get; set; }
       

        public override double Calculate(double income)//inhertits this method from Expenses and provides it with a body
        {
            return income - CalculateRepayment();
        }
        public double CalculateRepayment()
        {   //calculates the  monthly vehicle and returns it to the main program
            //calculation method is taken from provided link
            //https://www.siyavula.com/read/maths/grade-10/finance-and-growth/09-finance-and-growth-03
            double totalAfterDeposit = PurchaseAmount - DepositAmount;
            return Math.Round((totalAfterDeposit * (1 + InterestRate * 5)) / 60, 2) + InsuranceAmount;
        }

    }
}
