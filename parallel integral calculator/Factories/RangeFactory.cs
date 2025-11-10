using parallel_integral_calculator.Interfaces;
using parallel_integral_calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parallel_integral_calculator.Factories
{
    internal class RangeFactory:IRangeFactory
    {
        public List<IRange> CreateRanges()  
        {
            return new List<IRange> {
                new Range(0,10),
                new Range(3,12),
                new Range(5,14)
            };
        }
    }
}
