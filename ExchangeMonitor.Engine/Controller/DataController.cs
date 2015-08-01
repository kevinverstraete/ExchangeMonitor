using ExchangeMonitor.Engine.Threading;
using ExchangeMonitor.Engine.Web.Controller;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ExchangeMonitor.Engine.Controller
{
    public class DataController
    {
        #region Private Members
        private Dictionary<string, ViewModel.Data> _tickers = new Dictionary<string, ViewModel.Data>();

        private IndicatorController _indicatorController = new IndicatorController();
        private InfoController _infoController = new InfoController();
        private RateController _rateController = new RateController();

        private System.Timers.Timer _rateTimer = new System.Timers.Timer();
        private System.Timers.Timer _indicatorTimer = new System.Timers.Timer();
        #endregion Private Members

        #region ctor
        public DataController()
        {
            DefineControllers();
            DefineTimers();
        }
        private void DefineControllers()
        {
            _infoController.DataFetched += _infoControllerDataFetched;
            _rateController.DataFetched += _rateControllerDataFetched;
            _indicatorController.DataFetched += _indicatorControllerDataFetched;
        }
        private void DefineTimers()
        {
            _rateTimer = new System.Timers.Timer(2000);
            _indicatorTimer = new System.Timers.Timer(10000);
            _rateTimer.Elapsed += _rateTimerElapsed;
            _indicatorTimer.Elapsed += _indicatorTimerElapsed;
            _rateTimer.Enabled = true;
            _indicatorTimer.Enabled = true;
        }
        #endregion ctor

        #region events
        public event EventHandler DataFetched;
        protected virtual void OnDataFetched(ViewModel.Data data)
        {
            OnDataFetched(new DataControllerEventArgs(){
                Success = true,
                Data = data
            });
        }
        protected virtual void OnDataFetched(DataControllerEventArgs e)
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

        #region Tickers
        public void AddTicker(string ticker)
        {
            AddTickers(new List<string>{ ticker});
        }
        public void AddTickers(List<string> tickers)
        {
            var todo = new List<string>();
            foreach (var item in tickers)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    AddtickerToDictionary(item);
                    todo.Add(item);
                }
            }
            _infoController.Run(todo);
            _rateController.Run(todo);
            _indicatorController.Run(todo);
        }
        private Object addtickerToDictionaryLock = new Object();
        private void AddtickerToDictionary(string ticker)
        {
            lock (addtickerToDictionaryLock)
            {
                if (_tickers.ContainsKey(ticker)) return ;
                var data = new ViewModel.Data()
                {
                    Ticker = ticker
                };
                _tickers.Add(ticker, data);
                OnDataFetched(data);
            }
        }
        public void RemoveTicker(string ticker)
        {
            _tickers.Remove(ticker);
        }
        #endregion Tickers

        #region Timer
        private void _indicatorTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            List<string> tickers = (from ticker in _tickers
                          select ticker.Key).ToList<string>();
            _indicatorController.Run(tickers);
        }
        private void _rateTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            List<string> tickers = (from ticker in _tickers
                                    select ticker.Key).ToList<string>();
            _rateController.Run(tickers);
        }
        #endregion TimerElapsed

        #region Controller Data Fecthed
        private ViewModel.Data GetData(string ticker)
        {
            var data = new ViewModel.Data();
            if (_tickers.TryGetValue(ticker, out data)) return data;
            return null;
        }
        private void _indicatorControllerDataFetched(object sender, EventArgs e)
        {
            var args = (ThreadMethodEventArgs<IndicatorControllerResponse>)e;
            var data = GetData(args.Ticker);
            if (data != null)
            {
                var bollinger = 
                    (from ind in args.Data.RangeIndicators
                    where ind.Type == RangeIndicatorType.Bollinger
                    select ind).FirstOrDefault();
                data.BollingerLower = bollinger.Lower;
                data.BollingerUpper = bollinger.Upper;
                data.RequestProcessingTime = DateTime.Now;
                OnDataFetched(data);
            }
        }
        private void _rateControllerDataFetched(object sender, EventArgs e)
        {
            var args = (ThreadMethodEventArgs<RateControllerResponse>)e;
            var data = GetData(args.Ticker);
            if (data != null)
            {
                data.Rate = args.Data.Rate;
                OnDataFetched(data);
            }
        }
        private void _infoControllerDataFetched(object sender, EventArgs e)
        {
            var args = (ThreadMethodEventArgs<InfoControllerResponse>)e;
            var data = GetData(args.Ticker);
            if (data != null)
            {
                data.Name = args.Data.Name;
                data.StockExchange = args.Data.StockExchange;
                OnDataFetched(data);
            }
        }
        #endregion Controller Data Fecthed
    }

    public class DataControllerEventArgs : EventArgs
    {
        public ViewModel.Data Data { get; set; }
        public bool Success { get; set; }
    }
}
