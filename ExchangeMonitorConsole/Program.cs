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
            var input = "EURUSD=X";
            while (input != "EXIT" && input != "")
            {
                Console.Clear();

                CatchData(input);
                Console.WriteLine("");
                Console.WriteLine("Give ticker or nothing to leave:");
                input = Console.ReadLine().ToUpper();
            }
        }

        static void CatchData(string ticker)
        {
            var infoResponse = InfoCatcher.Catch(ticker);

            Console.WriteLine("Info:");

            Console.WriteLine(infoResponse.ToString());

            if (infoResponse.Success)
            {
                Console.WriteLine("\nData");
                var result = DataCatcher.Catch(ticker);
                Console.WriteLine(result.ToString());

                Console.WriteLine("\nBollinger");
                var bollinger = BollingerCatcher.Catch(ticker);
                Console.WriteLine(bollinger.ToString());
            }
        } 
    }
}
