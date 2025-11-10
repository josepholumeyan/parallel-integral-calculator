using parallel_integral_calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parallel_integral_calculator.Workers
{
    internal class IntegralWorker
    {
        private BackgroundWorker _worker;
        private ICalculator _calculator;
        private IFunction _function;
        private IRange _range;
        private IStep _steps;
        public IRange Range
        {
            get { return _range; }
        }

        public double Result { get; private set; }

        public IntegralWorker(ICalculator calculator, IFunction function, IStep steps, IRange range)
        {
            _calculator = calculator;
            _function = function;
            _steps = steps;
            _range = range;

            _worker = new BackgroundWorker();
            _worker.WorkerReportsProgress = true;
            _worker.WorkerSupportsCancellation = true;

            _worker.DoWork += DoWorkHandler;
            _worker.ProgressChanged += ProgressChangedHandler;
            _worker.RunWorkerCompleted += RunWorkerCompletedHandler;
        }

        private void DoWorkHandler(object sender, DoWorkEventArgs e)
        {
            Result = _calculator.Calculate(_function, _range, _steps, ReportProgressFromCalculator);
            e.Result = Result;

            if (_worker.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void ReportProgressFromCalculator(int percent)
        {
            _worker.ReportProgress(percent);
        }

        private void ProgressChangedHandler(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine("Range " + _range.Start + "-" + _range.End + ": " + e.ProgressPercentage + "% completed");
        }

        internal void RunWorkerCompletedHandler(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Console.WriteLine("Calculation for range " + _range.Start + "-" + _range.End + " was cancelled.");
            }
            else
            {
                Console.WriteLine("Calculation for range " + _range.Start + "-" + _range.End + " finished. Result: " + e.Result);
            }
        }

        public void Start()
        {
            _worker.RunWorkerAsync();
        }

        public void Cancel()
        {
            _worker.CancelAsync();
        }

        public bool IsBusy()
        {
            return _worker.IsBusy;
        }
    }
}

