using ExchangeMonitor.Engine.Threading;
using ExchangeMonitor.Engine.Web.YahooApis.Query;
using System.Collections.Generic;

namespace ExchangeMonitor.Engine.Web.Controller
{
    internal class InfoControllerThreadMethod : AThreadWorkerMethod<InfoControllerResponse>
    {
        public InfoControllerThreadMethod(List<string> tickers)
            : base(tickers)
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
}
