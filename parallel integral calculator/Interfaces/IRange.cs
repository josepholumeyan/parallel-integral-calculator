using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parallel_integral_calculator.Interfaces
{
    public interface IRange
    {
        double Start { get;}
        double End { get;}

        double width();
    }
}
