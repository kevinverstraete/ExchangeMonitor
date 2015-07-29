using ExchangeMonitor.Engine.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeMonitor.Engine.Web
{
    internal static class ChartCatcher
    {
        internal static ChartCatcherResponse Catch(string ticker)
        {
            try
            {
                var yqlResponse = Web.Yql.YqlChartCatcher.Catch(ticker);
                if (!yqlResponse.Success)
                    return new ChartCatcherResponse() { Success = false };


                var data =
                    (from item in yqlResponse.Data.chart.result
                    where item.meta.symbol == ticker
                    select item).FirstOrDefault();
                var bollinger = data.indicators.bollinger.FirstOrDefault();

                var bollingerlower = (from item in bollinger.lower
                                          where item.HasValue==true
                                      select item).LastOrDefault().GetValueOrDefault();
                var bollingerupper= (from item in bollinger.upper
                                      where item.HasValue == true
                                      select item).LastOrDefault().GetValueOrDefault();


                return new ChartCatcherResponse()
                {
                    Success = true,
                    StockExchange = data.meta.exchangeName,
                    BollingerUpper = bollingerupper,
                    BollingerLower = bollingerlower
                };
            }
            catch
            {
                return new ChartCatcherResponse();
            }
        }
    }
    internal class ChartCatcherResponse
    {
        public bool Success { get; set; }
        public string StockExchange { get; set; }
        public double BollingerUpper { get; set; }
        public double BollingerLower { get; set; }
    }
}
