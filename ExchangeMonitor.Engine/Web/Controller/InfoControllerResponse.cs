namespace ExchangeMonitor.Engine.Web.Controller
{
    public class InfoControllerResponse
    {
        public bool Success { get; set; }
        public string Name { get; set; }
        public string Ticker { get; set; }
        public string Symbol { get; set; }
        public string StockExchange { get; set; }

        public override string ToString()
        {
            return "Success: " + Success.ToString()
                + "\nName: " + Name
                + "\nTicker: " + Ticker
                + "\nSymbol: " + Symbol
                + "\nStockExchange: " + StockExchange;
        }
    }
}
