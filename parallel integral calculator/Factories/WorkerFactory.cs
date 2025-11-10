
using parallel_integral_calculator.Interfaces;
using parallel_integral_calculator.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parallel_integral_calculator.Factories
{
    internal class WorkerFactory:IWorkerFactory
    {       
        public IntegralWorker CreateWorker(ICalculator calculator, IFunction function, IStep steps,IRange range)
            {
                var worker = new IntegralWorker(calculator, function,steps,range);
                return worker;
            }
        
    }
}
