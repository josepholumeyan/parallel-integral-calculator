using parallel_integral_calculator.Calculators;
using parallel_integral_calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parallel_integral_calculator.Factories
{
    internal class CalculatorFactory: ICalculatorFactory
    {
        public ICalculator CreateCalculator(IFunction function)
        {
            Console.WriteLine("Select calculator method:");
            Console.WriteLine("1. Trapezoid method (default)");
            Console.Write("> ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                default:
                    return new TrapezoidCalculator();
            }
        }
    }
}
