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
        private System.Timers.Timer _timer = new System.Timers.Timer();
        #endregion private members

        #region Public Properties
        private int _bollingerMargin;
        public int BollingerMargin
        {
            get { return _bollingerMargin; }
            set
            {
                _bollingerMargin = value;
                if (_bollingerMargin > 100) _bollingerMargin = 100;
                else if (_bollingerMargin < 0) _bollingerMargin = 0;
            }
        }
        #endregion Public Properties

        #region events
        public event EventHandler DataFetched;
        protected virtual void OnDataFetched(EventArgs e)
        {
            if (DataFetched == null) return;
            DataFetched(this, e);
        }
        public event EventHandler BollingerAlarm;
        protected virtual void OnBollingerAlarm(EventArgs e)
        {
            if (BollingerAlarm == null) return;
            BollingerAlarm(this, e);
        }
        #endregion events

        #region ctor
        public DataController()
        {

            BollingerMargin = 0;
            _interval = 2000;
            DataFetched += DataControllerDataFetched;
            _timer = new System.Timers.Timer(_interval);
            _timer.Elapsed += _timerElapsed;
            _timer.Enabled = true;
        }


        public DataController(int interval) : this()
        {
            if (interval > 0) _interval = interval;
        }
        #endregion ctor

        #region PullData
        private void _timerElapsed(object sender, ElapsedEventArgs e)
        {
            Pull();
        }
        public void Pull()
        {
            foreach (var item in _tickers)
            {
                PulldataForTicker(item.Key);
            }
        }

        private Object pullDataLock = new Object();
        private void PulldataForTicker(string ticker)
        {
            lock (pullDataLock)
            {
                if (_threads.ContainsKey(ticker)) return;
                var ttr = new ThreadToRetriever();
                ttr.DataRetriever = new DataRetriever(ticker, DataPulledByRetriever);
                ttr.Thread = new Thread(new ThreadStart(ttr.DataRetriever.Run));
                _threads.Add(ticker, ttr);
                ttr.Thread.Start();
            }
        }
        #endregion PullAll

        #region DataPulled
        private bool DataPulledByRetriever(bool success, ViewModel.Data data)
        {
            _threads.Remove(data.Ticker);
            if (!_tickers.ContainsKey(data.Ticker)) return false;
            var e = new DataControllerEventArgs()
            {
                Success = success,
                Data = data
            };
            OnDataFetched(e);
            return true;
        }
        private void DataControllerDataFetched(object sender, EventArgs e)
        { 
            var args = (DataControllerEventArgs) e;
            if (!args.Success) return;

            // fetch previous data
            DataControllerEventArgs previousArgs;
            if (!_tickers.TryGetValue(args.Data.Ticker, out previousArgs)) previousArgs = new DataControllerEventArgs();

            // verify
            if (previousArgs.Success) 
                if (!DataNeedsAlarm(previousArgs.Data) && DataNeedsAlarm(args.Data)) 
                    OnBollingerAlarm(args);
            else if (DataNeedsAlarm(args.Data)) 
                    OnBollingerAlarm(args);

            // save current data
            if (_tickers.ContainsKey(args.Data.Ticker)) _tickers[args.Data.Ticker] = args;
        }
        #endregion PullData

        #region BollingerAlarm
        private bool DataNeedsAlarm(ViewModel.Data data)
        {
            if (data.BollingerUpper == 0.0) return false;
            if (data.BollingerLower == 0.0) return false;

            // standard checks, alarm needed if yu cross the line
            if (data.BollingerUpper < data.Rate) return true;
            if (data.BollingerLower > data.Rate) return true;

            // use a margin
            var marginPercentage = Convert.ToDouble(BollingerMargin)/100;
            var bollingerUpperWithMargin = data.BollingerUpper - ((data.BollingerUpper - data.Rate) * marginPercentage);
            if (bollingerUpperWithMargin < data.Rate) return true;
            var bollingerLowerWithMargin = data.BollingerLower + ((data.Rate - data.BollingerLower) * marginPercentage);
            if (bollingerLowerWithMargin > data.Rate) return true;

            return false;
        }
        #endregion BollingerAlarm

        #region Tickers
        public void AddTickers(string ticker)
        {
            _tickers.Add(ticker, new DataControllerEventArgs());
            PulldataForTicker(ticker);
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