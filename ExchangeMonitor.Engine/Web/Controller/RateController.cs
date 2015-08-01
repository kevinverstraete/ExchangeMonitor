using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ExchangeMonitor.Engine.Threading;
using ExchangeMonitor.Engine.Web.YahooApis.Query;

namespace ExchangeMonitor.Engine.Web.Controller
{
    public class RateController : ThreadWorker<RateControllerResponse>
    {

        #region Events
        public event EventHandler DataFetched;
        protected virtual void OnDataFetched(ThreadMethodEventArgs<RateControllerResponse> e)
        {
            if (DataFetched == null) return;
            DataFetched(this, e);
        }
        #endregion Events

        private class TickerProperties
        {
            public bool UsesYahooXchange { get; set; }
            public string KeyToUse { get; set; }
        }
        private static Dictionary<string, TickerProperties> _tickerProperties = new Dictionary<string, TickerProperties>();
        
        private Object thisLock = new Object();
        public void Run(List<string> tickers)
        {
            var yahooTickers = new List<string>();
            var htmlTickers = new List<string>();
            foreach (var item in tickers)
            {
                lock (thisLock)
                {
                    var tickerProperties = new TickerProperties();
                    if (!_tickerProperties.TryGetValue(item, out tickerProperties)) tickerProperties = PrepareTicker(item);
                    if (tickerProperties.UsesYahooXchange) {
                        if (!yahooTickers.Contains(tickerProperties.KeyToUse))
                            yahooTickers.Add(tickerProperties.KeyToUse);
                    }
                    else htmlTickers.Add(tickerProperties.KeyToUse);
                }
            }

            foreach (var item in htmlTickers)
            {       
                    var method = new RateControllerHtmlThreadMethod(new List<string> { item });
                    method.DataFetched += MethodDataFetched;
                    base.Run(method);
            }

            if (yahooTickers.Count > 0)
            {
                var method = new RateControllerYahooThreadMethod(yahooTickers);
                method.DataFetched += MethodDataFetched;
                base.Run(method);

            }
        }

        private TickerProperties PrepareTicker(string ticker)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            provider.NumberGroupSeparator = ",";
            provider.NumberGroupSizes = new int[] { 3 };

            var localTicker = ticker;
            if (localTicker.EndsWith("=X")) localTicker = localTicker.Substring(0, localTicker.Length - 2);
            var x = Request.XchangeForSingle(localTicker);
            double test = 0.0;
            if (Double.TryParse(x.Results.Rate.FirstOrDefault().XRate, NumberStyles.Number, provider, out test))
            {
                var prop = new TickerProperties() { UsesYahooXchange = true, KeyToUse = localTicker };
                _tickerProperties.Add(ticker, prop);
                return prop;
            }
            else {
                var prop = new TickerProperties() { UsesYahooXchange = false, KeyToUse = localTicker };
                _tickerProperties.Add(ticker,prop);
                return prop;
            }
        }

        private Object fetchLock = new Object();
        private void MethodDataFetched(object sender, EventArgs e)
        {
            var args = (ThreadMethodEventArgs<RateControllerResponse>)e;
            OnDataFetched(args);
        }
    }
}
