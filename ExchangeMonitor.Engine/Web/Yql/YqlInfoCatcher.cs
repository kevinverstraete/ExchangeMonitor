using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExchangeMonitor.Engine.Web.Yql
{
    internal class YqlInfoCatcher
    {
        private const string _uri = "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.quotes%20where%20symbol%20in%20%28%22{0}%22%29%0A%09%09&env=http%3A%2F%2Fdatatables.org%2Falltables.env";

        internal YqlInfoResponse Catch(string ticker)
        {
            if (string.IsNullOrEmpty(ticker))
                return new YqlInfoResponse();

            try
            {
                string url = string.Format(_uri, ticker);
                XDocument doc = XDocument.Load(url);
                var rootElement = doc.Element("query");
                var resultsElement = rootElement.Element("results");
                var quoteElement = resultsElement.Element("quote");

                var bidItem = quoteElement.Element("Bid");
                if (string.IsNullOrEmpty(bidItem.Value))
                    return new YqlInfoResponse();

                var nameItem = quoteElement.Element("Name");
                var symbolItem = quoteElement.Element("Symbol");
                var stockExchangeItem = quoteElement.Element("StockExchange");

                var result = new YqlInfoResponse();
                result.Name = nameItem.Value;
                result.Symbol = symbolItem.Value;
                result.StockExchange = stockExchangeItem.Value;

                result.Success = true;
                return result;
            }
            catch
            {
                return new YqlInfoResponse();
            }
        }
    }

    internal class YqlInfoResponse
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
