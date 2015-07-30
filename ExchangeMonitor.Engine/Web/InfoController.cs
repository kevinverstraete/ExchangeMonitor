using ExchangeMonitor.Engine.Threading;
using ExchangeMonitor.Engine.Web.YahooApis.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeMonitor.Engine.Web
{
    public class InfoController : ThreadRunner<InfoControllerResponse>
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
                    var method = new DefaultThreadMethod(new List<string> { item }) { Response = infoControllerResponse };
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
                var method = new ThreadMethod(tickersToFetch);
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

        private class ThreadMethod : AThreadMethod<InfoControllerResponse>
        {
            public ThreadMethod(List<string> tickers): base(tickers)
            {

            }
            public override void Method()
            {
                try
                {
                    var yahooResult = Request.QuotesForList(Tickers);
                    foreach (var quote in yahooResult.Results.Quote)
                    {
                        var response = new InfoControllerResponse()
                            {
                                Ticker = quote.Symbol,
                                Symbol = quote.Symbol,
                                Success = true,
                                Name = quote.Name,
                                StockExchange = quote.StockExchange
                            };
                        var e = new ThreadMethodEventArgs<InfoControllerResponse>(response.Ticker) { Data = response };
                        OnDataFetched(e);
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        private class DefaultThreadMethod : AThreadMethod<InfoControllerResponse>
        {
            public DefaultThreadMethod(List<string> tickers)
                : base(tickers)
            {

            }
            public InfoControllerResponse Response { get; set; }

            public override void Method()
            {
                var e = new ThreadMethodEventArgs<InfoControllerResponse>(Response.Ticker);
                e.Data = Response;
                OnDataFetched(e);
            }
        }
    }

    public class InfoControllerResponse
    {
        public bool Success { get; set; }
        public string Name { get; set; }
        public string Ticker { get; set; }
        public string Symbol { get; set; }
        public string StockExchange { get; set; }

        public override string ToString()
        {
            return "Success: " + Success.ToString()
                + "\nName: " + Name
                + "\nTicker: " + Ticker
                + "\nSymbol: " + Symbol
                + "\nStockExchange: " + StockExchange;
        }
    }
}
