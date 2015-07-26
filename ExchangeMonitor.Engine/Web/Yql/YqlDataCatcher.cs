using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExchangeMonitor.Engine.Web.Yql
{
    internal static class YqlDataCatcher
    {
        private const string _uri = "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.xchange%20where%20pair%20in%20(%22{0}%22)&env=store://datatables.org/alltableswithkeys";

        internal static YqlDataResponse Catch(string ticker)
        {
            if (string.IsNullOrEmpty(ticker)) 
                return new YqlDataResponse(); 
            
            try
            {
                string url = string.Format(_uri, ticker);
                XDocument doc = XDocument.Load(url);
                var rootElement = doc.Element("query");
                var resultsElement = rootElement.Element("results");
                var rateElement = resultsElement.Element("rate");
                
                var nameItem = rateElement.Element("Name");
                var rateItem = rateElement.Element("Rate");
                var dateItem = rateElement.Element("Date");
                var timeItem = rateElement.Element("Time");
                var askItem = rateElement.Element("Ask");
                var bidItem = rateElement.Element("Bid");

                var result = new YqlDataResponse();
                result.Name = nameItem.Value;
                result.Rate = Convert.ToDouble(rateItem.Value);
                result.Ask = Convert.ToDouble(askItem.Value);
                result.Bid = Convert.ToDouble(bidItem.Value);

                result.Success = true;
                return result;
            }
            catch
            {
                return new YqlDataResponse();
            }
        }
    }

    internal class YqlDataResponse
    {
        public bool Success { get; set; }
        public string Name { get; set; }
        public Double Rate { get; set; }
        public Double Ask { get; set; }
        public Double Bid { get; set; }

        public override string ToString()
        {
            return "Success: " + Success.ToString() 
                + "\nName: " + Name 
                + "\nRate: " + Rate.ToString()
                + "\nAsk: " + Ask.ToString()
                + "\nBid: " + Bid.ToString();
        }
    }
}
