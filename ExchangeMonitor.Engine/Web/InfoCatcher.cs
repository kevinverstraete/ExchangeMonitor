using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeMonitor.Engine.Helper;

namespace ExchangeMonitor.Engine.Web
{
    internal static class InfoCatcher
    {
        private static Dictionary<string, InfoCactherResponse> _cachedData = new Dictionary<string, InfoCactherResponse>();

        public static InfoCactherResponse Catch(string ticker)
        {
            // via cache
            var infoResponse = new InfoCactherResponse();
            if (_cachedData.TryGetValue(ticker, out infoResponse)) return infoResponse;

            // via html
            var yqlInfoResponse = Yql.YqlInfoCatcher.Catch(ticker);
            infoResponse =  new InfoCactherResponse()
            {
                Success = yqlInfoResponse.Success,
                Name = yqlInfoResponse.Name,
                Symbol = yqlInfoResponse.Symbol,
                StockExchange = yqlInfoResponse.StockExchange
            };

            _cachedData.Add(ticker, infoResponse);
            return infoResponse;
        }
    }

    internal class InfoCactherResponse
    {
        public bool Success { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string StockExchange { get; set; }

        public override string ToString()
        {
            return "Success: " + Success.ToString()
                + "\nName: " + Name
                + "\nSymbol: " + Symbol
                + "\nStockExchange: " + StockExchange;
        }
    }
}
