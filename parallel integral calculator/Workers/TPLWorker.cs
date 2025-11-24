using parallel_integral_calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace parallel_integral_calculator.Workers
{
    internal class TPLWorker : Iworker
    {
        private Task<double> _task;
        private CancellationTokenSource _cts;

        private ICalculator _calculator;
        private IFunction _function;
        private IRange _range;
        private IStep _steps;


        public double Result { get; private set; }

        public TPLWorker(ICalculator calculator, IFunction function, IStep steps, IRange range)
        {
            _calculator = calculator;
            _function = function;
            _steps = steps;
            _range = range;

            _cts = new CancellationTokenSource();
        }

        public void Start()
        {
            CancellationToken token = _cts.Token;

            _task = Task.Run<double>(() =>
            {
                return _calculator.Calculate(_function, _range, _steps, token, null);
            }, token);


            _task.ContinueWith(t =>
            {
                if (t.IsCanceled)
                {
                    Console.WriteLine($"Range {_range.Start}-{_range.End} was cancelled.");
                }
                else
                {
                    Result = t.Result;
                    Console.WriteLine($"Range {_range.Start}-{_range.End} finished. Result = {Result}");
                }
            });
        }
        public void Cancel()
        {
            _cts.Cancel();
        }
    }
}
