using ExchangeMonitor.Engine.Threading;
using ExchangeMonitor.Engine.Web.DataTypes;
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
                    if (yqlResponse.Success.State == SuccessState.Success)
                    {
                        foreach (var chart in yqlResponse.Data.chart.result)
                        {
                            var response = new IndicatorControllerResponse();
                            response.Indicators = new List<Indicator>();
                            response.RangeIndicators = new List<RangeIndicator>();
                            response.Indicators.Add(new Indicator()
                            {
                                Type = IndicatorType.Ema,
                                Quote = chart.indicators.ema.LastOrDefault().ema.Where(x => x.HasValue).LastOrDefault().GetValueOrDefault()
                            });
                            response.Indicators.Add(new Indicator()
                            {
                                Type = IndicatorType.Macd,
                                Quote = chart.indicators.macd.LastOrDefault().macd.Where(x => x.HasValue).LastOrDefault().GetValueOrDefault()
                            });
                            response.Indicators.Add(new Indicator()
                            {
                                Type = IndicatorType.Mfi,
                                Quote = chart.indicators.mfi.LastOrDefault().mfi.Where(x => x.HasValue).LastOrDefault().GetValueOrDefault()
                            });
                            response.Indicators.Add(new Indicator()
                            {
                                Type = IndicatorType.Sma,
                                Quote = chart.indicators.sma.LastOrDefault().sma.Where(x => x.HasValue).LastOrDefault().GetValueOrDefault()
                            });
                            response.Indicators.Add(new Indicator()
                            {
                                Type = IndicatorType.Rsi,
                                Quote = chart.indicators.rsi.LastOrDefault().rsi.Where(x => x.HasValue).LastOrDefault().GetValueOrDefault()
                            });
                            response.RangeIndicators.Add(new RangeIndicator()
                            {
                                Type = RangeIndicatorType.Bollinger,
                                Lower = chart.indicators.bollinger.LastOrDefault().lower.Where(x => x.HasValue).LastOrDefault().GetValueOrDefault(),
                                Upper = chart.indicators.bollinger.LastOrDefault().upper.Where(x => x.HasValue).LastOrDefault().GetValueOrDefault()
                            });
                            response.RangeIndicators.Add(new RangeIndicator()
                            {
                                Type = RangeIndicatorType.Stoch,
                                Lower = chart.indicators.stoch.LastOrDefault().d.Where(x => x.HasValue).LastOrDefault().GetValueOrDefault(),
                                Upper = chart.indicators.stoch.LastOrDefault().k.Where(x => x.HasValue).LastOrDefault().GetValueOrDefault()
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
