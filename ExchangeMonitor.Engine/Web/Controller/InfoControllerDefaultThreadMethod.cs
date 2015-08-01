using ExchangeMonitor.Engine.Threading;
using System.Collections.Generic;

namespace ExchangeMonitor.Engine.Web.Controller
{
    internal class InfoControllerDefaultThreadMethod : AThreadWorkerMethod<InfoControllerResponse>
    {
        public InfoControllerDefaultThreadMethod(List<string> tickers)
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
