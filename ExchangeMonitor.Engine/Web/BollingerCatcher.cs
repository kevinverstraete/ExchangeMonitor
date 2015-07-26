using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeMonitor.Engine.Web
{
    public static class BollingerCatcher
    {
        public static BollingerResponse Catch(string ticker)
        {
            var yqlBollingerResponse = Html.HtmlBollingerCatcher.Catch(ticker);
            return new BollingerResponse { Lower = yqlBollingerResponse.Lower, Upper = yqlBollingerResponse.Upper };
        }
    }

    public class BollingerResponse
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
