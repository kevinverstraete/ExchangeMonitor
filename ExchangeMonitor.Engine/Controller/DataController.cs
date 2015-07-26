using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ExchangeMonitor.Engine.Controller
{
    public class DataController
    {
        #region private members
        private Dictionary<string, DataControllerEventArgs> _tickers = new Dictionary<string, DataControllerEventArgs>();
        private Timer _timer;
        #endregion private members

        #region events
        public event EventHandler DataFetched;
        protected virtual void OnDataFetched(EventArgs e)
        {
            if (DataFetched != null) DataFetched(this, e);
            DataFetched += DataControllerDataFetched;
        }
        #endregion events

        #region constructors
        public DataController(): this(5000) { }
        public DataController(double interval)
        {
            _timer = new Timer(interval);
            _timer.Elapsed += _onTimerElapsed;
            _timer.Enabled = true;
        }
        #endregion constructors

        #region Timer
        private void _onTimerElapsed(object sender, ElapsedEventArgs e)
        {
            foreach (var item in _tickers)
            {
                var webData = Web.DataCatcher.Catch(item.Key);
                var webInfo = Web.InfoCatcher.Catch(item.Key);
                var data = new ViewModel.Data()
                {
                    Ticker = item.Key,
                    StockExchange = webInfo.StockExchange,
                    Name = webData.Name,
                    Rate = webData.Rate,
                };
                OnDataFetched(new DataControllerEventArgs() { Data = data, Success = webData.Success });
            }
        }
        #endregion Timer

        #region Alarm
        private void DataControllerDataFetched(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion Alarm

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
    }

    public class DataControllerEventArgs : EventArgs
    {
        public ViewModel.Data Data { get; set; }
        public bool Success { get; set; }
    }
}