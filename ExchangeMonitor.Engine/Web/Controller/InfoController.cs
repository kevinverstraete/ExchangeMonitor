using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ExchangeMonitor.Engine.Threading;
using ExchangeMonitor.Engine.Web.YahooApis.Query;

namespace ExchangeMonitor.Engine.Web.Controller
{
    public class InfoController : ThreadWorker<InfoControllerResponse>
    {
        #region Events
        public event EventHandler DataFetched;
        protected virtual void OnDataFetched(ThreadMethodEventArgs<InfoControllerResponse> e)
        {
            if (DataFetched == null) return;
            DataFetched(this, e);
        }
        #endregion Events

        private static Dictionary<string, InfoControllerResponse> _cachedData = new Dictionary<string, InfoControllerResponse>();

        public void Run(List<string> tickers)
        {
            var tickersToFetch = new List<string>();
            foreach (var item in tickers)
            {
                var infoControllerResponse = new InfoControllerResponse();
                if (_cachedData.TryGetValue(item, out infoControllerResponse))
                {
                    var method = new InfoControllerDefaultThreadMethod(new List<string>{item}) { Response = infoControllerResponse };
                    method.DataFetched += MethodDataFetched;
                    base.Run(method);
                }
                else
                {
                    tickersToFetch.Add(item);
                }
            }

            if (tickersToFetch.Count > 0)
            {
                var method = new InfoControllerThreadMethod(tickersToFetch);
                method.DataFetched += MethodDataFetched;
                base.Run(method);
            }
        }
        private Object thisLock = new Object();
        private void MethodDataFetched(object sender, EventArgs e)
        {
            var args = (ThreadMethodEventArgs<InfoControllerResponse>)e;
            lock (thisLock)
            {
                if (!_cachedData.ContainsKey(args.Ticker)) _cachedData.Add(args.Ticker, args.Data);
                else _cachedData[args.Ticker] = args.Data;
            }
            OnDataFetched(args);
        }
    }






}
