using ExchangeMonitor.Engine.Threading;
using ExchangeMonitor.Engine.Web.YahooApis.Query;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ExchangeMonitor.Engine.Web.Controller
{
    internal class RateControllerYahooThreadMethod : AThreadWorkerMethod<RateControllerResponse>
    {
        public RateControllerYahooThreadMethod(List<string> tickers)
            : base(tickers)
        {

        }
        public override void Method()
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            provider.NumberGroupSeparator = ",";
            provider.NumberGroupSizes = new int[] { 3 };

            try
            {
                var yahooResult = Request.XchangeForList(Tickers);
                foreach (var rate in yahooResult.Results.Rate)
                {
                    double dRate = 0.0;
                    if (Double.TryParse(rate.XRate, NumberStyles.Number, provider, out dRate))
                    {
                        var data = new RateControllerResponse()
                        {
                            Name = rate.Name,
                            Rate = dRate,
                            Success = true
                        };
                        var e = new ThreadMethodEventArgs<RateControllerResponse>(rate.Id + "=X") { Data = data };
                        OnDataFetched(e);
                    }
                }
            }
            catch
            {
                return;
            }
        }
    }
}
