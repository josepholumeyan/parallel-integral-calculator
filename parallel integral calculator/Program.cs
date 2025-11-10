using parallel_integral_calculator.Factories;
using parallel_integral_calculator.Interfaces;
using parallel_integral_calculator.Workers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parallel_integral_calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Parallel Integral Calculator ===");

            IFunctionFactory functionFactory = new FunctionFactory();
            IStepsFactory stepsFactory = new StepsFactory();
            IRangeFactory rangeFactory = new RangeFactory();
            ICalculatorFactory calculatorFactory = new CalculatorFactory();
            IWorkerFactory workerFactory = new WorkerFactory();

            IFunction function = functionFactory.CreateFunction();

            IStep steps = stepsFactory.CreateSteps();
            List<IRange> ranges = rangeFactory.CreateRanges();

            ICalculator calculator = calculatorFactory.CreateCalculator(function);

            var workers = new List<IntegralWorker>();
            foreach (var range in ranges)
            {
                var worker = workerFactory.CreateWorker(calculator, function, steps, range);
                workers.Add(worker);
                worker.Start();
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
