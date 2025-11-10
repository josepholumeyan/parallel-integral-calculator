
using parallel_integral_calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parallel_integral_calculator.Functions
{
    internal class Function1 : IFunction
    {
        public double Evaluate(double x)
        {
            return (2*(x*x))+(7*x);
        }
    }
}
