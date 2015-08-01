using ExchangeMonitor.Engine.Controller;
using ExchangeMonitor.Engine.Threading;
using ExchangeMonitor.Engine.Web.Controller;
using ExchangeMonitor.Engine.Web.Yql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeMonitorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //var response = ExchangeMonitor.Engine.Web.YahooApis.Query.Request.QuotesForSingle("GOOG");
            //var responsex = ExchangeMonitor.Engine.Web.YahooApis.Query.Request.XchangeForSingle("EURUSD=X");
            //var responsex2 = ExchangeMonitor.Engine.Web.YahooApis.Query.Request.XchangeForSingle("EURUSD");

            var dc = new DataController();
            dc.DataFetched += dc_DataFetched;
            dc.AddTicker("GOOG");
            dc.AddTicker("YHOO");
            Console.ReadKey();
            Console.ReadKey();
        }

        static void dc_DataFetched(object sender, EventArgs e)
        {
            var args = (DataControllerEventArgs)e;
            Console.WriteLine("----");
            Console.WriteLine(args.Data);
        }

    }
}
