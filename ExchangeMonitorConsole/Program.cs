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

            var ic = new IndicatorController();
            ic.DataFetched += ic_DataFetched; ;
            ic.Run(new List<string> { "GOOG" });
            Console.ReadKey();
            ic.Run(new List<string> { "GOOG", "YHOO", "EURUSD", "EURUSD=X" });

            Console.ReadKey();
            ic.Run(new List<string> { "GOOG", "YHOO", "EURUSD", "EURUSD=X" });


            Console.ReadKey();
        }

        static void ic_DataFetched(object sender, EventArgs e)
        {
            var eventArgs = (ThreadMethodEventArgs<IndicatorControllerResponse>)e;

            Console.WriteLine("\nEvent-");
            Console.WriteLine(eventArgs.Data.ToString());
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
