using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using HtmlAgilityPack;

namespace ExchangeMonitor.Engine.Web.Html
{
    internal class HtmlDataCatcher
    {
        private const string _uri = "http://finance.yahoo.com/q?s={0}";

        internal static HtmlDataResponse Catch(string ticker)
        {
            if (string.IsNullOrEmpty(ticker))
                return new HtmlDataResponse(); 

            try
            {
                string url = string.Format(_uri, ticker);
                var client = new WebClient();

                string reply = client.DownloadString(url);
                var doc = new HtmlDocument();
                doc.LoadHtml(reply);
                HtmlNode specificNode = doc.GetElementbyId("yfi_rt_quote_summary");

                var response = new HtmlDataResponse() { Name = string.Empty, Rate=0 };

                // Loop trough de divs
                foreach (var divLvl1 in specificNode.ChildNodes)
                {
                    if (divLvl1.GetAttributeValue("class",string.Empty) == "hd")
                    {
                        foreach (var divLvl2 in divLvl1.ChildNodes)
                        {
                            if (divLvl2.GetAttributeValue("class",string.Empty) == "title")
                            {
                                foreach (var divLvl3 in divLvl2.ChildNodes)
                                {
                                    if (divLvl3.Name.ToUpper() == "H2") response.Name = divLvl3.InnerText;
                                }
                            }
                        }
                    }
                    else if (divLvl1.GetAttributeValue("class",string.Empty).Contains("summary"))
                    {
                        foreach (var divLvl2 in divLvl1.ChildNodes)
                        {
                            foreach (var divLvl3 in divLvl2.ChildNodes)
                            {
                                if (divLvl3.Name.ToUpper() == "SPAN")
                                {
                                    if (divLvl3.GetAttributeValue("class", string.Empty).Contains("time_rtq_ticker"))
                                    {
                                        foreach (var divLvl4 in divLvl3.ChildNodes)
                                        {
                                            if (divLvl4.GetAttributeValue("id", string.Empty).ToUpper().Contains(ticker)) response.Rate = Convert.ToDouble(divLvl4.InnerHtml); ;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                
                return response;
            }
            catch
            {
                return new HtmlDataResponse();
            }
        }
    }

    internal class HtmlDataResponse
    {
        public bool Success { get { return Rate > 0 && !String.IsNullOrEmpty(Name); } }
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
