using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExchangeMonitor.Engine.Web.YahooApis.Query.YahooFinanceQuotes
{
    [XmlRoot(ElementName = "LastTradeWithTime")]
    public class LastTradeWithTime
    {
        [XmlElement(ElementName = "b")]
        public string B { get; set; }
    }

    [XmlRoot(ElementName = "quote")]
    public class Quote
    {
        [XmlElement(ElementName = "Ask")]
        public string Ask { get; set; }
        [XmlElement(ElementName = "AverageDailyVolume")]
        public string AverageDailyVolume { get; set; }
        [XmlElement(ElementName = "Bid")]
        public string Bid { get; set; }
        [XmlElement(ElementName = "AskRealtime")]
        public string AskRealtime { get; set; }
        [XmlElement(ElementName = "BidRealtime")]
        public string BidRealtime { get; set; }
        [XmlElement(ElementName = "BookValue")]
        public string BookValue { get; set; }
        [XmlElement(ElementName = "Change_PercentChange")]
        public string Change_PercentChange { get; set; }
        [XmlElement(ElementName = "Change")]
        public string Change { get; set; }
        [XmlElement(ElementName = "Commission")]
        public string Commission { get; set; }
        [XmlElement(ElementName = "Currency")]
        public string Currency { get; set; }
        [XmlElement(ElementName = "ChangeRealtime")]
        public string ChangeRealtime { get; set; }
        [XmlElement(ElementName = "AfterHoursChangeRealtime")]
        public string AfterHoursChangeRealtime { get; set; }
        [XmlElement(ElementName = "DividendShare")]
        public string DividendShare { get; set; }
        [XmlElement(ElementName = "LastTradeDate")]
        public string LastTradeDate { get; set; }
        [XmlElement(ElementName = "TradeDate")]
        public string TradeDate { get; set; }
        [XmlElement(ElementName = "EarningsShare")]
        public string EarningsShare { get; set; }
        [XmlElement(ElementName = "ErrorIndicationreturnedforsymbolchangedinvalid")]
        public string ErrorIndicationreturnedforsymbolchangedinvalid { get; set; }
        [XmlElement(ElementName = "EPSEstimateCurrentYear")]
        public string EPSEstimateCurrentYear { get; set; }
        [XmlElement(ElementName = "EPSEstimateNextYear")]
        public string EPSEstimateNextYear { get; set; }
        [XmlElement(ElementName = "EPSEstimateNextQuarter")]
        public string EPSEstimateNextQuarter { get; set; }
        [XmlElement(ElementName = "DaysLow")]
        public string DaysLow { get; set; }
        [XmlElement(ElementName = "DaysHigh")]
        public string DaysHigh { get; set; }
        [XmlElement(ElementName = "YearLow")]
        public string YearLow { get; set; }
        [XmlElement(ElementName = "YearHigh")]
        public string YearHigh { get; set; }
        [XmlElement(ElementName = "HoldingsGainPercent")]
        public string HoldingsGainPercent { get; set; }
        [XmlElement(ElementName = "AnnualizedGain")]
        public string AnnualizedGain { get; set; }
        [XmlElement(ElementName = "HoldingsGain")]
        public string HoldingsGain { get; set; }
        [XmlElement(ElementName = "HoldingsGainPercentRealtime")]
        public string HoldingsGainPercentRealtime { get; set; }
        [XmlElement(ElementName = "HoldingsGainRealtime")]
        public string HoldingsGainRealtime { get; set; }
        [XmlElement(ElementName = "MoreInfo")]
        public string MoreInfo { get; set; }
        [XmlElement(ElementName = "OrderBookRealtime")]
        public string OrderBookRealtime { get; set; }
        [XmlElement(ElementName = "MarketCapitalization")]
        public string MarketCapitalization { get; set; }
        [XmlElement(ElementName = "MarketCapRealtime")]
        public string MarketCapRealtime { get; set; }
        [XmlElement(ElementName = "EBITDA")]
        public string EBITDA { get; set; }
        [XmlElement(ElementName = "ChangeFromYearLow")]
        public string ChangeFromYearLow { get; set; }
        [XmlElement(ElementName = "PercentChangeFromYearLow")]
        public string PercentChangeFromYearLow { get; set; }
        [XmlElement(ElementName = "LastTradeRealtimeWithTime")]
        public string LastTradeRealtimeWithTime { get; set; }
        [XmlElement(ElementName = "ChangePercentRealtime")]
        public string ChangePercentRealtime { get; set; }
        [XmlElement(ElementName = "ChangeFromYearHigh")]
        public string ChangeFromYearHigh { get; set; }
        [XmlElement(ElementName = "PercebtChangeFromYearHigh")]
        public string PercebtChangeFromYearHigh { get; set; }
        [XmlElement(ElementName = "LastTradeWithTime")]
        public LastTradeWithTime LastTradeWithTime { get; set; }
        [XmlElement(ElementName = "LastTradePriceOnly")]
        public string LastTradePriceOnly { get; set; }
        [XmlElement(ElementName = "HighLimit")]
        public string HighLimit { get; set; }
        [XmlElement(ElementName = "LowLimit")]
        public string LowLimit { get; set; }
        [XmlElement(ElementName = "DaysRange")]
        public string DaysRange { get; set; }
        [XmlElement(ElementName = "DaysRangeRealtime")]
        public string DaysRangeRealtime { get; set; }
        [XmlElement(ElementName = "FiftydayMovingAverage")]
        public string FiftydayMovingAverage { get; set; }
        [XmlElement(ElementName = "TwoHundreddayMovingAverage")]
        public string TwoHundreddayMovingAverage { get; set; }
        [XmlElement(ElementName = "ChangeFromTwoHundreddayMovingAverage")]
        public string ChangeFromTwoHundreddayMovingAverage { get; set; }
        [XmlElement(ElementName = "PercentChangeFromTwoHundreddayMovingAverage")]
        public string PercentChangeFromTwoHundreddayMovingAverage { get; set; }
        [XmlElement(ElementName = "ChangeFromFiftydayMovingAverage")]
        public string ChangeFromFiftydayMovingAverage { get; set; }
        [XmlElement(ElementName = "PercentChangeFromFiftydayMovingAverage")]
        public string PercentChangeFromFiftydayMovingAverage { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Notes")]
        public string Notes { get; set; }
        [XmlElement(ElementName = "Open")]
        public string Open { get; set; }
        [XmlElement(ElementName = "PreviousClose")]
        public string PreviousClose { get; set; }
        [XmlElement(ElementName = "PricePaid")]
        public string PricePaid { get; set; }
        [XmlElement(ElementName = "ChangeinPercent")]
        public string ChangeinPercent { get; set; }
        [XmlElement(ElementName = "PriceSales")]
        public string PriceSales { get; set; }
        [XmlElement(ElementName = "PriceBook")]
        public string PriceBook { get; set; }
        [XmlElement(ElementName = "ExDividendDate")]
        public string ExDividendDate { get; set; }
        [XmlElement(ElementName = "PERatio")]
        public string PERatio { get; set; }
        [XmlElement(ElementName = "DividendPayDate")]
        public string DividendPayDate { get; set; }
        [XmlElement(ElementName = "PERatioRealtime")]
        public string PERatioRealtime { get; set; }
        [XmlElement(ElementName = "PEGRatio")]
        public string PEGRatio { get; set; }
        [XmlElement(ElementName = "PriceEPSEstimateCurrentYear")]
        public string PriceEPSEstimateCurrentYear { get; set; }
        [XmlElement(ElementName = "PriceEPSEstimateNextYear")]
        public string PriceEPSEstimateNextYear { get; set; }
        [XmlElement(ElementName = "Symbol")]
        public string Symbol { get; set; }
        [XmlAttribute(AttributeName = "symbol")]
        public string _Symbol { get; set; }
        [XmlElement(ElementName = "SharesOwned")]
        public string SharesOwned { get; set; }
        [XmlElement(ElementName = "ShortRatio")]
        public string ShortRatio { get; set; }
        [XmlElement(ElementName = "LastTradeTime")]
        public string LastTradeTime { get; set; }
        [XmlElement(ElementName = "TickerTrend")]
        public string TickerTrend { get; set; }
        [XmlElement(ElementName = "OneyrTargetPrice")]
        public string OneyrTargetPrice { get; set; }
        [XmlElement(ElementName = "Volume")]
        public string Volume { get; set; }
        [XmlElement(ElementName = "HoldingsValue")]
        public string HoldingsValue { get; set; }
        [XmlElement(ElementName = "HoldingsValueRealtime")]
        public string HoldingsValueRealtime { get; set; }
        [XmlElement(ElementName = "YearRange")]
        public string YearRange { get; set; }
        [XmlElement(ElementName = "DaysValueChange")]
        public string DaysValueChange { get; set; }
        [XmlElement(ElementName = "DaysValueChangeRealtime")]
        public string DaysValueChangeRealtime { get; set; }
        [XmlElement(ElementName = "StockExchange")]
        public string StockExchange { get; set; }
        [XmlElement(ElementName = "DividendYield")]
        public string DividendYield { get; set; }
        [XmlElement(ElementName = "PercentChange")]
        public string PercentChange { get; set; }
    }

    [XmlRoot(ElementName = "results")]
    public class Results
    {
        [XmlElement(ElementName = "quote")]
        public List<Quote> Quote { get; set; }
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
