using parallel_integral_calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace parallel_integral_calculator.Calculators
{
    internal class TrapezoidCalculator : ICalculator
    {
        public double Calculate(IFunction function, IRange range, IStep steps, CancellationToken token, Action<int> reportProgress = null)
        {
            double stepSize = steps.calculateStepSize(range);
            double sum = 0.0;
            double x = range.Start;
            int totalSteps = steps.Count;
            int progressCheckpoint = totalSteps / 10;
            for (int i = 0; i < steps.Count; i++)
            {
                double y1 = function.Evaluate(x);
                double y2 = function.Evaluate(x + stepSize);
                sum += (y1 + y2);
                x += stepSize;
                if (reportProgress != null && (i + 1) % progressCheckpoint == 0)
                {
                    reportProgress((i + 1) * 100 / totalSteps);
                }
                if (token != null && token.IsCancellationRequested)
                {
                    Console.WriteLine("Calculation for range " + range.Start + "-" + range.End + " was cancelled.");
                    token.ThrowIfCancellationRequested();
                    break;
                }
            }
            return sum * stepSize;
        }
    }
}
