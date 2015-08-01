using ExchangeMonitor.Engine.Threading;
using System.Collections.Generic;
namespace ExchangeMonitor.Engine.Web.Controller
{
    internal class RateControllerHtmlThreadMethod : AThreadWorkerMethod<RateControllerResponse>
    {
        public RateControllerHtmlThreadMethod(List<string> tickers)
            : base(tickers)
        {

        }
        public override void Method()
        {
            try
            {
                foreach (var item in Tickers)
                {
                    var response = Html.HtmlDataCatcher.Catch(item);
                    var data = new RateControllerResponse()
                    {
                        Name = response.Name,
                        Rate = response.Rate,
                        Success = response.Success
                    };
                    var e = new ThreadMethodEventArgs<RateControllerResponse>(item) { Data = data };
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
