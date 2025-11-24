
using parallel_integral_calculator.Interfaces;
using parallel_integral_calculator.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parallel_integral_calculator.Factories
{
    internal class WorkerFactory : IWorkerFactory
    {
        public Iworker CreateWorker(ICalculator calculator, IFunction function, IStep steps, IRange range, String input)
        {
            switch (input)
            {
                case "1":
                    {
                        return new BackgroundWorker(calculator, function, steps, range);
                    }
                case "2":
                    {
                        return new TPLWorker(calculator, function, steps, range);
                    }
                default:
                    {
                        Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                        Console.Write("Enter choice: ");
                        return new BackgroundWorker(calculator, function, steps, range);
                    }
            }
        }
    }
}
