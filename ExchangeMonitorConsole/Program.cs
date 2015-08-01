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

            var rc = new RateController();
            rc.DataFetched += rc_DataFetched;
            rc.Run(new List<string> { "GOOG", "YHOO", "EURUSD", "EURUSD=X" });

            Console.ReadKey();
            rc.Run(new List<string> { "GOOG", "YHOO", "EURUSD", "EURUSD=X" });


            Console.ReadKey();
        }

        static void rc_DataFetched(object sender, EventArgs e)
        {
            var eventArgs = (ThreadMethodEventArgs<RateControllerResponse>)e;

            Console.WriteLine("\nEvent-");
            Console.WriteLine(eventArgs.Data.ToString());
        }

        static void c_DataFetched(object sender, EventArgs e)
        {
            var eventArgs = (ThreadMethodEventArgs<InfoControllerResponse>)e;

            Console.WriteLine("\nEvent-");
            Console.WriteLine(eventArgs.Data.ToString());
        }

        static void controller_DataFetched(object sender, EventArgs e) {
          var eventArgs = (DataControllerEventArgs)e;

          Console.WriteLine("\nEvent");
          Console.WriteLine(eventArgs.Data.ToString());
        }
    }
}
