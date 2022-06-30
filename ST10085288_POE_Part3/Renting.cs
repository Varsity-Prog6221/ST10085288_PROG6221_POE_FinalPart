using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10085288_POE_Part3
{
    internal class Renting : Expenses
    {
        //properties for renting
        public double RentalAmount { get; set; }

        public override double Calculate(double income)//inhertits this method from Expenses and provides it with a body
        {
            return income - RentalAmount;
        }

       
    }
}
