using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeMonitor.Engine.Threading
{
    public class ThreadMethodEventArgs<T> : EventArgs
    {
        public string Ticker { get; private set; }
        public T Data { get; set; }
        public ThreadMethodEventArgs(string ticker)
        {
            Ticker = ticker;
        }
    }
}
