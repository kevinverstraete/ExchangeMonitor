using ExchangeMonitor.Engine.Controller;
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

            var controller = new DataController();
            controller.AddTickers("EURUSD=X");
            controller.AddTickers("GOOG");

            controller.DataFetched += controller_DataFetched;

            Console.ReadKey();
        }

        static void controller_DataFetched(object sender, EventArgs e) {
          var eventArgs = (DataControllerEventArgs)e;

          Console.WriteLine("\nEvent");
          Console.WriteLine(eventArgs.Data.ToString());
        }
    }
}
