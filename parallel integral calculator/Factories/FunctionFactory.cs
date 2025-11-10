using parallel_integral_calculator.Interfaces;
using parallel_integral_calculator.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parallel_integral_calculator.Factories
{
    internal class FunctionFactory:IFunctionFactory
    {
        public IFunction CreateFunction()
        {
            Console.WriteLine("Select a function to integrate:");
            Console.WriteLine("1. y = 2x^2 + 7x");
            Console.WriteLine("2. y = 2x^2");
            Console.WriteLine("3. y = 2x - 3");

            while (true)
            {
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        return new Function1();
                    case "2":
                        return new Function2();
                    case "3":
                        return new Function3();
                    default:
                        Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                        break;
                }
            }
        }
    }
}
