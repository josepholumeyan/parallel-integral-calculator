using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parallel_integral_calculator.Interfaces
{
    internal interface Iworker
    {
        double Result { get; }
        void Start();
        void Cancel();
    }
}
