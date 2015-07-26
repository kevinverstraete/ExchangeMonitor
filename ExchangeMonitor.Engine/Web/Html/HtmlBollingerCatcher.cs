using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using HtmlAgilityPack;

namespace ExchangeMonitor.Engine.Web.Html
{
    internal class HtmlBollingerCatcher
    {
        private const string _uri = "http://finance.yahoo.com/echarts?s={0}";
        private const string _uriAppend = "#{\"showBollinger\":true,\"range\":\"1d\",\"allowChartStacking\":true}";

        internal static HtmlBollingerResponse Catch(string ticker)
        {
            if (string.IsNullOrEmpty(ticker))
                return new HtmlBollingerResponse();

            try
            {
                string url = string.Format(_uri, ticker);
                url = url + _uriAppend;
                var client = new WebClient();

                string reply = client.DownloadString(url);
                var doc = new HtmlDocument();
                doc.LoadHtml(reply);



                var response = new HtmlBollingerResponse();
                
                var memoryStream = new System.IO.MemoryStream();
                doc.Save(memoryStream);
                memoryStream.Position = 0;

                var sr = new System.IO.StreamReader(memoryStream);
                sr.DiscardBufferedData(); 

                
                var qtring = sr.ReadToEnd();

                var chart = doc.GetElementbyId("chart-main");
                var bollingerNode = FindBollinger(chart);

                if (bollingerNode!= null){
                    var innerHtml = bollingerNode.InnerHtml;
                }

                return response;
            }
            catch
            {
                return new HtmlBollingerResponse();
            }
        }

        private static HtmlNode FindBollinger(HtmlNode parent)
        {
            // item zoeken
            foreach (var item in parent.ChildNodes)
            {
                if (item.GetAttributeValue("data-ns", string.Empty) == "bollinger"
                    && item.GetAttributeValue("class", string.Empty) == "virgo-pill") 
                    return item;
            };

            // alle childs zelfde logica
            foreach (var item in parent.ChildNodes)
            {
                var result = FindBollinger(item);
                if (result != null) return result;
            };

            return null;
        }
    }

    internal class HtmlBollingerResponse
    {
        public bool Success { get { return Upper > 0 && Lower > 0; } }
        public Double Upper { get; set; }
        public Double Lower { get; set; }

        public override string ToString()
        {
            return "Success: " + Success.ToString()
                + "\nUpper: " + Upper.ToString()
                + "\nLower: " + Lower.ToString();
        }
    }
}
