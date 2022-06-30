using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10085288_POE_Part3
{
    internal abstract class Expenses
    {//abstract class that hold 1 abstract methods with no body to be used in the classes that inherit from this class
        public abstract double Calculate(double income);
    }
}
