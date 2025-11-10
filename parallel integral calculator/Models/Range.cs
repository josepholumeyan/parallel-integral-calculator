using parallel_integral_calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parallel_integral_calculator.Models
{
    internal class Range:IRange
    {
        public double Start { get; private set; }
        public double End { get; private set; }
        public Range(double start, double end)
        {
            Start = start;
            End = end;
        }
        public double width()
        {
            return End - Start;
        }
    }
}
