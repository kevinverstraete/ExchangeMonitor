using System;
using System.Collections.Generic;
using System.Threading;

namespace ExchangeMonitor.Engine.Threading
{
    public class ThreadRunner<T>
    {
        private class ThreadModel<S>
        {
            public AThreadMethod<S> Method { get; set; }
            public Thread Thread { get; set; }
        }
        private Dictionary<string, ThreadModel<T>> _threads = new Dictionary<string, ThreadModel<T>>();

        protected void Run(AThreadMethod<T> method)
        {
            if (_threads.ContainsKey(method.GetTicker())) return;
            var tm = new ThreadModel<T>() { Thread = new Thread(new ThreadStart(method.Run)), Method = method };
            _threads.Add(method.GetTicker(), tm);
            method.Stop += MethodStop;
            tm.Thread.Start();
        }

        private void MethodStop(object sender, EventArgs e)
        {
            var args = (ThreadMethodEventArgs<T>)e;
            _threads.Remove(args.Ticker);
        }
    }

    public abstract class AThreadMethod<T>
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
        public AThreadMethod(List<string> tickers)
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

    public class ThreadMethodEventArgs<T>: EventArgs
    {
        public string Ticker { get; private set; }
        public T Data{ get; set; }
        public ThreadMethodEventArgs(string ticker)
        {
            Ticker = ticker;
        }
    }
}

