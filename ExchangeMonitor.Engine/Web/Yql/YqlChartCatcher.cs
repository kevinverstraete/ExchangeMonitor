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
        private const string _uri = "https://finance-yql.media.yahoo.com/v7/finance/chart/{0}?interval=1m&indicators=quote%7Cbollinger~20-2&includeTimestamps=true&includePrePost=true&events=div%7Csplit%7Cearn&corsDomain=finance.yahoo.com";
        internal static YqlChartResponse Catch(string ticker)
        {
            if (string.IsNullOrEmpty(ticker))
                return new YqlChartResponse();

            try
            {
                string url = string.Format(_uri, ticker);
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
    }

    internal class YqlChartResponse
    {
        public bool Success { get; set; }
        public RootObject Data { get; set; }
    }
}
