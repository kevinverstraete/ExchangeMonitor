using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ExchangeMonitor.Engine.Controller
{
    public class DataController
    {
        #region private members
        private int _interval;
        private Dictionary<string, DataControllerEventArgs> _tickers = new Dictionary<string, DataControllerEventArgs>();
        private Dictionary<string, ThreadToRetriever> _threads = new Dictionary<string, ThreadToRetriever>();
        #endregion private members

        #region events
        public event EventHandler DataFetched;
        protected virtual void OnDataFetched(EventArgs e)
        {
            if (DataFetched != null) DataFetched(this, e);
        }
        #endregion events

        #region ctor
        public DataController()
        {
            _interval = 5000;
        }
        public DataController(int interval) : this()
        {
            if (interval > 0) _interval = interval;
        }
        #endregion ctor

        #region PullAll
        public void Pull()
        {
            foreach (var item in _tickers)
            {
                if (!_threads.ContainsKey(item.Key))
                {
                    var ttr = new ThreadToRetriever();
                    ttr.DataRetriever = new DataRetriever(item.Key, DataPulledByRetriever);
                    ttr.Thread = new Thread(new ThreadStart(ttr.DataRetriever.Run));
                    _threads.Add(item.Key,ttr);
                    ttr.Thread.Start();
                }
            }
        }
        #endregion PullAll

        #region PullData
        private bool DataPulledByRetriever(bool success, ViewModel.Data data){
            _threads.Remove(data.Ticker);
            var e = new DataControllerEventArgs()
            {
                Success = success,
                Data = data
            };
            OnDataFetched(e);
            return true;
        }
        #endregion PullData

        #region Tickers
        public void AddTickers(string ticker)
        {
            _tickers.Add(ticker, new DataControllerEventArgs());
        }
        public void RemoveTicker(string ticker)
        {
            _tickers.Remove(ticker);
        }
        #endregion Tickers

        #region Retriever Class
        private class ThreadToRetriever
        {
            public DataRetriever DataRetriever { get; set; }
            public Thread Thread { get; set; }
        }
        #endregion Retriever Class
    }

    public class DataControllerEventArgs : EventArgs
    {
        public ViewModel.Data Data { get; set; }
        public bool Success { get; set; }
    }
}