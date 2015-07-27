using System;

namespace ExchangeMonitor.Engine.Helper
{
    public class Period
    {
        public DateTime Start { get; private set; }
        public DateTime Stop { get; private set; }

        public Period(DateTime start, DateTime stop)
        {
            Start = start;
            Stop = stop;
        }

        public TimeSpan Diff()
        {
            return  Stop.Subtract(Start);
        }
    }
}
