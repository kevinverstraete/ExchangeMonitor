using System;
namespace ExchangeMonitor.Engine.Web.Controller
{
    public class RateControllerResponse
    {
        public bool Success { get; set; }
        public string Name { get; set; }
        public Double Rate { get; set; }

        public override string ToString()
        {
            return "Success: " + Success.ToString()
                + "\nName: " + Name
                + "\nRate: " + Rate.ToString();
        }
    }
}
