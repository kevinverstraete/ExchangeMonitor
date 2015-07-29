using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeMonitor.Engine.Web.Yql.Meta
{
    internal class Pre
    {
        public string timezone { get; set; }
        public int end { get; set; }
        public int start { get; set; }
        public int gmtoffset { get; set; }
    }

    internal class Regular
    {
        public string timezone { get; set; }
        public int end { get; set; }
        public int start { get; set; }
        public int gmtoffset { get; set; }
    }

    internal class Post
    {
        public string timezone { get; set; }
        public int end { get; set; }
        public int start { get; set; }
        public int gmtoffset { get; set; }
    }

    internal class CurrentTradingPeriod
    {
        public Pre pre { get; set; }
        public Regular regular { get; set; }
        public Post post { get; set; }
    }

    internal class TradingPeriods
    {
        public List<List<Pre>> pre { get; set; }
        public List<List<Post>> post { get; set; }
        public List<List<Regular>> regular { get; set; }
    }

    internal class Meta
    {
        public string currency { get; set; }
        public string symbol { get; set; }
        public string exchangeName { get; set; }
        public string instrumentType { get; set; }
        public int firstTradeDate { get; set; }
        public int gmtoffset { get; set; }
        public string timezone { get; set; }
        public double previousClose { get; set; }
        public int scale { get; set; }
        public CurrentTradingPeriod currentTradingPeriod { get; set; }
        public TradingPeriods tradingPeriods { get; set; }
        public string dataGranularity { get; set; }
        public List<string> validRanges { get; set; }
    }

    internal class Quote
    {
        public List<double?> open { get; set; }
        public List<double?> high { get; set; }
        public List<double?> close { get; set; }
        public List<double?> low { get; set; }
        public List<int?> volume { get; set; }
    }

    internal class Params
    {
        public double period { get; set; }
        public double nstddev { get; set; }
    }

    internal class Bollinger
    {
        public List<double?> bandwidth { get; set; }
        public List<double?> lower { get; set; }
        public List<double?> upper { get; set; }
        public Params @params { get; set; }
    }

    internal class Indicators
    {
        public List<Quote> quote { get; set; }
        public List<Bollinger> bollinger { get; set; }
    }

    internal class Result
    {
        public Meta meta { get; set; }
        public List<int> timestamp { get; set; }
        public Indicators indicators { get; set; }
    }

    internal class Chart
    {
        public List<Result> result { get; set; }
        public object error { get; set; }
    }

    internal class RootObject
    {
        public Chart chart { get; set; }
    }
}
