using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ExchangeMonitor.Engine.Controller {
  public class DataController {

    private List<string> _tickers = new List<string>();
    private Timer _timer = new Timer(5000);

    public event EventHandler DataFetched;
    protected virtual void OnDataFetched(EventArgs e) {
      if (DataFetched != null) DataFetched(this, e);
    }

    public DataController() {
      _timer.Elapsed += _timerElapsed;
      _timer.Enabled = true;
    }

    private void _timerElapsed(object sender, ElapsedEventArgs e) {
      foreach (var item in _tickers) {
        var webData = Web.DataCatcher.Catch(item);
        var data = new ViewModel.Data() {
          Ticker = item,
          Name = webData.Name,
          Rate = webData.Rate
        };
        OnDataFetched(new DataControllerEventArgs() { Data = data, Success = webData.Success });
      }
    }

    public void AddTickers(string ticker){
      if (!_tickers.Contains(ticker)) 
        _tickers.Add(ticker);
    }
  }

  public class DataControllerEventArgs : EventArgs {
    public ViewModel.Data Data { get; set; }
    public bool Success { get; set; }
  }
}
