using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml.Serialization;
using System.IO;

namespace ExchangeMonitor.Engine.Web.YahooApis.Query
{
    public static class Request
    {
        // Quotes moet met =X
        // Xchange zonder =X

        private const string _encapsulator = "%22";
        private const string _iterationSymbol = ",";
        private const string _yahooFinanceQuotesUri = "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.quotes%20where%20symbol%20in%20({0})%0A%09%09&env=http%3A%2F%2Fdatatables.org%2Falltables.env";
        private const string _yahooFinanceXchangeUri = "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.xchange%20where%20pair%20in%20({0})&env=store://datatables.org/alltableswithkeys";

        private static string GetXmlForTickers(string uri, List<string> tickers)
        {
            if (string.IsNullOrEmpty(uri)) return string.Empty;
            if (tickers == null) return string.Empty;
            if (tickers.Count == 0) return string.Empty;

            try
            {
                var tickerList = new StringBuilder();
                foreach (var item in tickers)
                {
                    if (tickerList.Length > 0) tickerList.Append(_iterationSymbol);
                    tickerList.Append(_encapsulator).Append(item).Append(_encapsulator);
                }
                string url = string.Format(uri, tickerList);
                return new WebClient().DownloadString(url);
            }
            catch
            {
                return string.Empty;
            }
        }

        private static T DeserializeFromXmlString<T>(string xmlString)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(xmlString))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public static YahooFinanceQuotes.Query QuotesForSingle(string ticker)
        {
            return QuotesForList(new List<string> { ticker });
        }
        public static YahooFinanceQuotes.Query QuotesForList(List<string> tickers)
        {
            try
            {
                return DeserializeFromXmlString<YahooFinanceQuotes.Query>(GetXmlForTickers(_yahooFinanceQuotesUri, tickers));
            }
            catch
            {
                return new YahooFinanceQuotes.Query();
            }
        }

        public static YahooFinanceXchange.Query XchangeForSingle(string ticker)
        {
            return XchangeForList(new List<string> { ticker });
        }
        public static YahooFinanceXchange.Query XchangeForList(List<string> tickers)
        {
            try
            {
                return DeserializeFromXmlString<YahooFinanceXchange.Query>(GetXmlForTickers(_yahooFinanceXchangeUri, tickers));
            }
            catch
            {
                return new YahooFinanceXchange.Query();
            }
        }
    }
}
