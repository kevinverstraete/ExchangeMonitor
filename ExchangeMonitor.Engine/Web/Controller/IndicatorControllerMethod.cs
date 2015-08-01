using ExchangeMonitor.Engine.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeMonitor.Engine.Web.Controller
{
    internal class IndicatorControllerMethod : AThreadWorkerMethod<IndicatorControllerResponse>
    {
        public IndicatorControllerMethod(List<string> tickers)
            : base(tickers)
        {

        }

        public override void Method()
        {
            foreach (var ticker in Tickers)
            {
                try
                {
                    var yqlResponse = Web.Yql.YqlChartCatcher.Catch(ticker);
                    if (yqlResponse.Success)
                    {
                        foreach (var chart in yqlResponse.Data.chart.result)
                        {

                            var response = new IndicatorControllerResponse();
                            response.Indicators = new List<Indicator>();
                            response.RangeIndicators = new List<RangeIndicator>();
                            response.Indicators.Add(new Indicator()
                            {
                                Type = IndicatorType.Ema,
                                Quote = chart.indicators.ema.LastOrDefault().ema.LastOrDefault()
                            });
                            response.Indicators.Add(new Indicator()
                            {
                                Type = IndicatorType.Macd,
                                Quote = chart.indicators.macd.LastOrDefault().macd.LastOrDefault()
                            });
                            response.Indicators.Add(new Indicator()
                            {
                                Type = IndicatorType.Mfi,
                                Quote = chart.indicators.mfi.LastOrDefault().mfi.LastOrDefault()
                            });
                            response.Indicators.Add(new Indicator()
                            {
                                Type = IndicatorType.Sma,
                                Quote = chart.indicators.sma.LastOrDefault().sma.LastOrDefault()
                            });
                            response.Indicators.Add(new Indicator()
                            {
                                Type = IndicatorType.Rsi,
                                Quote = chart.indicators.rsi.LastOrDefault().rsi.LastOrDefault()
                            });
                            response.RangeIndicators.Add(new RangeIndicator()
                            {
                                Type = RangeIndicatorType.Bollinger,
                                Lower = chart.indicators.bollinger.LastOrDefault().lower.LastOrDefault(),
                                Upper = chart.indicators.bollinger.LastOrDefault().upper.LastOrDefault()
                            });
                            response.RangeIndicators.Add(new RangeIndicator()
                            {
                                Type = RangeIndicatorType.Stoch,
                                Lower = chart.indicators.stoch.LastOrDefault().d.LastOrDefault(),
                                Upper = chart.indicators.stoch.LastOrDefault().k.LastOrDefault()
                            });
                            var e = new ThreadMethodEventArgs<IndicatorControllerResponse>(ticker) { Data = response };
                            OnDataFetched(e);
                        }
                    }
                }
                catch
                {
                    //loop
                }
            }
        }
    }
}
