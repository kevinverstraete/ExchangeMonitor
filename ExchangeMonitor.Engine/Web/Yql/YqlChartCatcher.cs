using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ExchangeMonitor.Engine.Web.Yql.Meta.Chart;

namespace ExchangeMonitor.Engine.Web.Yql
{
    internal static class YqlChartCatcher
    {
        internal static YqlChartResponse Catch(string ticker)
        {
            if (string.IsNullOrEmpty(ticker))
                return new YqlChartResponse();

            try
            {
                string url = BuildUri(ticker);
                var client = new WebClient();
                string reply = client.DownloadString(url);
                return new YqlChartResponse() { 
                    Success = true, 
                    Data = Deserialize(reply)
                };
            }
            catch
            {
                return new YqlChartResponse();
            }
        }

        private static RootObject Deserialize(string json)
        {
            Newtonsoft.Json.JsonSerializer s = new JsonSerializer();
            return s.Deserialize<RootObject>(new JsonTextReader(new StringReader(json)));
        }

        private static string BuildUri(string ticker)
        {
            var pipeSep = "%7C";
            var uri = new StringBuilder();
            uri.Append(@"https://finance-yql.media.yahoo.com/v7/finance/chart/").Append(ticker);
            //uri.Append("?").Append("interval=1m");
            uri.Append("?").Append("interval=5m");
            uri.Append(@"&").Append("indicators=quote");
            uri.Append(pipeSep).Append("bollinger~20-2");
            uri.Append(pipeSep).Append("sma~50");
            uri.Append(pipeSep).Append("ema~50");
            uri.Append(pipeSep).Append("mfi~14");
            uri.Append(pipeSep).Append("macd~26-12-9");
            uri.Append(pipeSep).Append("rsi~14");
            uri.Append(pipeSep).Append("stoch~14-1-3");
            uri.Append(@"&").Append("includePrePost=true");
            uri.Append(@"&").Append("events=div");
            uri.Append(pipeSep).Append("split");
            uri.Append(pipeSep).Append("earn");
            uri.Append(@"&").Append("corsDomain=finance.yahoo.com");
            return uri.ToString();
        }
    }

    internal class YqlChartResponse
    {
        public bool Success { get; set; }
        public RootObject Data { get; set; }
    }
}
