using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeMonitor.Engine.Web.Controller
{
    public class IndicatorControllerResponse
    {
        public bool Success { get; set; }
        public List<Indicator> Indicators { get; set; }
        public List<RangeIndicator> RangeIndicators { get; set; }

        public override string ToString()
        {
            var indicators = new StringBuilder();
            foreach (var item in Indicators)
            {
                indicators.Append(item.Type.ToString())
                    .Append(": ")
                    .Append(item.Quote.ToString())
                    .Append("\n");
            }
            foreach (var item in RangeIndicators)
            {
                indicators.Append(item.Type.ToString())
                    .Append(": ")
                    .Append(" - Lower: ")
                    .Append(item.Lower.ToString())
                    .Append(" - Upper: ")
                    .Append(item.Upper.ToString())
                    .Append("\n");
            }

            return "Success: " + Success.ToString()
                + "\nIndicators:\n" + indicators.ToString();
        }
    }

    public class Indicator
    {
        public IndicatorType Type { get; set; }
        public double Quote { get; set; }
    }

    public class RangeIndicator
    {
        public RangeIndicatorType Type { get; set; }
        public double Upper { get; set; }
        public double Lower { get; set; }
    }

    public enum IndicatorType
    {
        None,
        Sma,
        Ema,
        Mfi,
        Macd,
        Rsi
    }

    public enum RangeIndicatorType
    {
        None,
        Stoch,
        Bollinger
    }
}
