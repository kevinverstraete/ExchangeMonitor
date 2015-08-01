using System;
using ExchangeMonitor.Engine.Threading;
using System.Collections.Generic;

namespace ExchangeMonitor.Engine.Web.Controller
{
    public class IndicatorController : ThreadWorker<IndicatorControllerResponse>
    {
        #region Events
        public event EventHandler DataFetched;
        protected virtual void OnDataFetched(ThreadMethodEventArgs<IndicatorControllerResponse> e)
        {
            if (DataFetched == null) return;
            DataFetched(this, e);
        }
        #endregion Events

        public void Run(List<string> tickers)
        {
            foreach (var item in tickers)
            {
                var method = new IndicatorControllerMethod(new List<string> { item });
                method.DataFetched += MethodDataFetched;
                base.Run(method);
            }
        }

        private void MethodDataFetched(object sender, EventArgs e)
        {
            var args = (ThreadMethodEventArgs<IndicatorControllerResponse>)e;
            OnDataFetched(args);
        }
    }
}
