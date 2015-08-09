using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ExchangeMonitor.Engine.Web.Yql.Meta.Chart;
using ExchangeMonitor.Engine.Web.DataTypes;

namespace ExchangeMonitor.Engine.Web.Yql
{
    internal static class YqlChartCatcher
    {
        internal static YqlChartResponse Catch(string ticker)
        {
            #region Validate ticker
            if (string.IsNullOrEmpty(ticker))
                return new YqlChartResponse()
                {
                    Success = new Success()
                    {
                        State = SuccessState.NoData,
                        Information = "No Ticker was given"
                    }
                };
            #endregion Validate ticker

            #region Get Data in raw form --> string reply
            string reply = string.Empty;
            try
            {
                reply = DownloadData(ticker);
            }
            catch (Exception ex)
            {
                return new YqlChartResponse()
                {
                    Success = new Success()
                    {
                        State = SuccessState.Error,
                        Information = "Error During Data Download",
                        ErrorInformation = ex.InnerException.ToString()
                    }
                };
            }
            #endregion Get Data in raw form --> string reply

            #region Convert raw data to objects --> RootObject data
            var data = new RootObject();
            try
            {
                data = Deserialize(reply);
            }
            catch (Exception ex)
            {
                return new YqlChartResponse()
                {
                    Success = new Success()
                    {
                        State = SuccessState.Error,
                        Information = "Error During Deserializing",
                        ErrorInformation = ex.InnerException.ToString() + "\n\nData: " + reply
                    }
                };
            }
            #endregion Convert raw data to objects --> RootObject data

            #region Return
            return new YqlChartResponse()
            {
                Success = new Success() { State = SuccessState.Success},
                Data = data
            };
            #endregion Return
        }

        #region Download Data
        private static string DownloadData(string ticker)
        {
            string url = BuildUri(ticker);
            var client = new WebClient();
            return client.DownloadString(url);
        }      
        private static string BuildUri(string ticker)
        {
            var pipeSep = "%7C";
            var uri = new StringBuilder();
            uri.Append(@"https://finance-yql.media.yahoo.com/v7/finance/chart/");
            uri.Append(ticker);
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
        #endregion Download Data

        #region Deserilize
        private static RootObject Deserialize(string json)
        {
            Newtonsoft.Json.JsonSerializer s = new JsonSerializer();
            return s.Deserialize<RootObject>(new JsonTextReader(new StringReader(json)));
        }
        #endregion Deserilize
    }

    internal class YqlChartResponse
    {
        public Success Success { get; set; }
        public RootObject Data { get; set; }
        internal YqlChartResponse()
        {
            Success = new Success();
            Data = new RootObject();
        }
    }
}
