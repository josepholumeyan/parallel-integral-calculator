
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parallel_integral_calculator.Interfaces
{
    internal interface ICalculator
    {
        double Calculate(IFunction function, IRange range, IStep steps, Action<int> reportProgress = null);
    }
}
