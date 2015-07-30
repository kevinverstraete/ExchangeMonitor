using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExchangeMonitor.Engine.Web.YahooApis.Query.YahooFinanceXchange
{
    [XmlRoot(ElementName = "rate")]
    public class Rate
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Rate")]
        public string XRate { get; set; }
        [XmlElement(ElementName = "Date")]
        public string Date { get; set; }
        [XmlElement(ElementName = "Time")]
        public string Time { get; set; }
        [XmlElement(ElementName = "Ask")]
        public string Ask { get; set; }
        [XmlElement(ElementName = "Bid")]
        public string Bid { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "results")]
    public class Results
    {
        [XmlElement(ElementName = "rate")]
        public List<Rate> Rate { get; set; }
    }

    [XmlRoot(ElementName = "query")]
    public class Query
    {
        [XmlElement(ElementName = "results")]
        public Results Results { get; set; }
        [XmlAttribute(AttributeName = "yahoo", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Yahoo { get; set; }
        [XmlAttribute(AttributeName = "count", Namespace = "http://www.yahooapis.com/v1/base.rng")]
        public string Count { get; set; }
        [XmlAttribute(AttributeName = "created", Namespace = "http://www.yahooapis.com/v1/base.rng")]
        public string Created { get; set; }
        [XmlAttribute(AttributeName = "lang", Namespace = "http://www.yahooapis.com/v1/base.rng")]
        public string Lang { get; set; }
    }
}
