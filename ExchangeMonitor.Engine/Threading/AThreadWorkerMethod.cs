using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeMonitor.Engine.Threading
{
    public abstract class AThreadWorkerMethod<T>
    {
        #region Events
        public event EventHandler Start;
        protected virtual void OnStart(ThreadMethodEventArgs<T> e)
        {
            if (Start == null) return;
            Start(this, e);
        }
        public event EventHandler DataFetched;
        protected virtual void OnDataFetched(ThreadMethodEventArgs<T> e)
        {
            if (DataFetched == null) return;
            DataFetched(this, e);
        }
        public event EventHandler Stop;
        protected virtual void OnStop(ThreadMethodEventArgs<T> e)
        {
            if (Stop == null) return;
            Stop(this, e);
        }
        #endregion Events

        #region Members
        public List<string> Tickers { get; set; }
        public string GetTicker() { return String.Join(",", Tickers.ToArray()); }
        #endregion Members

        #region ctor
        public AThreadWorkerMethod(List<string> tickers)
        {
            Tickers = new List<string>();
            foreach (var item in tickers) Tickers.Add(item);
        }
        #endregion ctor

        #region Run
        public void Run()
        {
            OnStart(new ThreadMethodEventArgs<T>(GetTicker()));
            Method();
            OnStop(new ThreadMethodEventArgs<T>(GetTicker()));
        }
        #endregion Run
        abstract public void Method();
    }
}
