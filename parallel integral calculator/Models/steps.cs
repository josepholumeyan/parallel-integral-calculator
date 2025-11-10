
using parallel_integral_calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parallel_integral_calculator.Models
{
    internal class steps: IStep
    {
        public int Count { get; private set; }
        public steps(int count)
        {
            Count = count;
        }
        public double calculateStepSize(IRange range)
        {
            return (range.End - range.Start) / Count;
        }
    }
}
