using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeMonitor.Engine.Web.Yql.Meta.Chart
{
    internal class Pre
    {
        public string timezone { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public int gmtoffset { get; set; }
    }

    internal class Regular
    {
        public string timezone { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public int gmtoffset { get; set; }
    }

    internal class Post
    {
        public string timezone { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public int gmtoffset { get; set; }
    }

    internal class CurrentTradingPeriod
    {
        public Pre pre { get; set; }
        public Regular regular { get; set; }
        public Post post { get; set; }
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
        public CurrentTradingPeriod currentTradingPeriod { get; set; }
        public string dataGranularity { get; set; }
        public List<string> validRanges { get; set; }
    }

    internal class Quote
    {
        public List<double> open { get; set; }
        public List<double> high { get; set; }
        public List<double> low { get; set; }
        public List<double> close { get; set; }
        public List<int> volume { get; set; }
    }

    internal class Params
    {
        public double period2 { get; set; }
        public double period1 { get; set; }
        public double signal { get; set; }
    }

    internal class Macd
    {
        public List<double> macd { get; set; }
        public List<double> signal { get; set; }
        public List<double> divergence { get; set; }
        public Params @params { get; set; }
    }

    internal class Params2
    {
        public double period { get; set; }
    }

    internal class Sma
    {
        public List<double> sma { get; set; }
        public Params2 @params { get; set; }
    }

    internal class Params3
    {
        public double period { get; set; }
    }

    internal class Ema
    {
        public List<double> ema { get; set; }
        public Params3 @params { get; set; }
    }

    internal class Params4
    {
        public double period { get; set; }
    }

    internal class Mfi
    {
        public List<double> mfi { get; set; }
        public Params4 @params { get; set; }
    }

    internal class Params5
    {
        public double period { get; set; }
    }

    internal class Rsi
    {
        public List<double> rsi { get; set; }
        public Params5 @params { get; set; }
    }

    internal class Params6
    {
        public double periodk { get; set; }
        public double period { get; set; }
        public double periodd { get; set; }
    }

    internal class Stoch
    {
        public List<double> d { get; set; }
        public List<double> k { get; set; }
        public Params6 @params { get; set; }
    }

    internal class Params7
    {
        public double period { get; set; }
        public double nstddev { get; set; }
    }

    internal class Bollinger
    {
        public List<double> bandwidth { get; set; }
        public List<double> lower { get; set; }
        public List<double> upper { get; set; }
        public Params7 @params { get; set; }
    }

    internal class Indicators
    {
        public List<Quote> quote { get; set; }
        public List<Macd> macd { get; set; }
        public List<Sma> sma { get; set; }
        public List<Ema> ema { get; set; }
        public List<Mfi> mfi { get; set; }
        public List<Rsi> rsi { get; set; }
        public List<Stoch> stoch { get; set; }
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
