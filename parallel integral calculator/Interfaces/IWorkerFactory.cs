using parallel_integral_calculator.Workers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parallel_integral_calculator.Interfaces
{
    internal interface IWorkerFactory
    {
        Iworker CreateWorker(
            ICalculator calculator, IFunction function, IStep steps, IRange range, String input
            );

    }
}
