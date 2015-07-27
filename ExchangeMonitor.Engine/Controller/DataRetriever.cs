using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeMonitor.Engine.Helper;

namespace ExchangeMonitor.Engine.Controller
{
    public class DataRetriever
    {
        private string _ticker;
        private Func<bool, ViewModel.Data, bool> _func;
        public DataRetriever(string ticker, Func<bool, ViewModel.Data, bool> func)
        {
            _ticker = ticker;
            _func = func;
        }
        public void Run()
        {
            var startTime = DateTime.Now;
            var webData = Web.DataCatcher.Catch(_ticker);
            var webInfo = Web.InfoCatcher.Catch(_ticker);
            var bollingerInfo = Web. ChartCatcher.Catch(_ticker);
            var data = new ViewModel.Data()
            {
                Ticker = _ticker,
                StockExchange = webInfo.StockExchange,
                Name = webData.Name,
                Rate = webData.Rate,
                BollingerLower = bollingerInfo.BollingerLower,
                BollingerUpper= bollingerInfo.BollingerUpper,
                RequestProcessingTime = new Period(startTime, DateTime.Now)
            };
            _func(webData.Success, data);
        }
    }
}
