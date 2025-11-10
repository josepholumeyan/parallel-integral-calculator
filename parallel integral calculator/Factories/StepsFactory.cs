using parallel_integral_calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parallel_integral_calculator.Factories
{
    internal class StepsFactory: IStepsFactory
    {
        public IStep CreateSteps()
        {
            Console.WriteLine("Enter the number of steps for the integral calculation >10:");
            int stepcount;
            while (true)
            {
                try 
                {
                    stepcount = int.Parse(Console.ReadLine());
                    if (stepcount < 10)
                    {
                        throw new FormatException();
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer greater than 10:");
                }
            }
            Console.WriteLine($"Step count set to {stepcount}");
            return new Models.steps(stepcount);

        }
    }
}
