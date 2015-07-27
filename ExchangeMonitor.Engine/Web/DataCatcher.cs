using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeMonitor.Engine.Helper;

namespace ExchangeMonitor.Engine.Web
{
    internal static class DataCatcher
    {
        private static Dictionary<string, TickerProperties> _tickerProperties = new Dictionary<string, TickerProperties>();

        internal static DataCatcherResponse Catch(string ticker)
        {
            var tickerProperties = new TickerProperties();
            if (!_tickerProperties.TryGetValue(ticker, out tickerProperties)) tickerProperties = PrepareTicker(ticker);
            return Catch(tickerProperties);
        }

        private static DataCatcherResponse Catch(TickerProperties tickerProperties)
        {
            if (tickerProperties.HasYqlData)
            {
                var response = Yql.YqlDataCatcher.Catch(tickerProperties.KeyToUse);
                return new DataCatcherResponse()
                {
                    Name = response.Name,
                    Rate = response.Rate,
                    Success = response.Success
                };
            }
            else
            {
                var response = Html.HtmlDataCatcher.Catch(tickerProperties.KeyToUse);
                return new DataCatcherResponse()
                {
                    Name = response.Name,
                    Rate = response.Rate,
                    Success = response.Success
                };
            }
        }

        private static TickerProperties PrepareTicker(string ticker)
        {
            var localTicker = ticker;
            if (localTicker.EndsWith("=X")) localTicker = localTicker.Substring(0, localTicker.Length - 2);

            var propYql = new TickerProperties() { HasYqlData = true, KeyToUse = localTicker };
            var propHtml = new TickerProperties() { HasYqlData = false, KeyToUse = localTicker };

            var yql = Catch(propYql);
            if (yql.Success)
            {
                _tickerProperties.Add(ticker, propYql);
                return propYql;
            }
            _tickerProperties.Add(ticker, propHtml);
            return propHtml;
        }

        private class TickerProperties
        {
            public bool HasYqlData { get; set; }
            public string KeyToUse { get; set; }
        }
    }

    internal class DataCatcherResponse
    {
        public bool Success { get; set; }
        public string Name { get; set; }
        public Double Rate { get; set; }

        public override string ToString()
        {
            return "Success: " + Success.ToString()
                + "\nName: " + Name
                + "\nRate: " + Rate.ToString();
        }
    }
}
