﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace ExchangeMonitor.Engine.Threading
{
    public class ThreadWorker<T>
    {
        private class ThreadModel<S>
        {
            public AThreadWorkerMethod<S> Method { get; set; }
            public Thread Thread { get; set; }
        }
        private Dictionary<string, ThreadModel<T>> _threads = new Dictionary<string, ThreadModel<T>>();

        protected void Run(AThreadWorkerMethod<T> method)
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
}
