using ExchangeMonitor.Engine.Controller;
using ExchangeMonitor.Engine.Threading;
using ExchangeMonitor.Engine.Web;
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

            var c = new InfoController();
            c.DataFetched += c_DataFetched;
            c.Run(new List<string> { "GOOG", "YHOO","NDAQ"});


            c.Run(new List<string> { "GOOG", "YHOO", "GOOG" });


            c.Run(new List<string> { "GOOG", "GOOG", "GOOG" });


            c.Run(new List<string> { "YHOO", "GOOG", "GOOG" });

            Console.ReadKey();
            c.Run(new List<string> { "GOOG", "YHOO", "NDAQ" });
            /*
            var controller = new DataController();

            controller.DataFetched += controller_DataFetched;
            controller.AddTickers("EURUSD=X");
            controller.AddTickers("GOOG");
            */

            Console.ReadKey();
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
