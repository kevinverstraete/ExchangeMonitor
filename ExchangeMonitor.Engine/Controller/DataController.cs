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
        private Dictionary<string, DataControllerEventArgs> _tickers = new Dictionary<string, DataControllerEventArgs>();
        #endregion private members

        #region events
        public event EventHandler DataFetched;
        protected virtual void OnDataFetched(EventArgs e)
        {
            if (DataFetched != null) DataFetched(this, e);
        }
        #endregion events

        #region Pull
        public void Pull()
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