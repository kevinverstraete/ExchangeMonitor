﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeMonitor.Engine.ViewModel {
  public class Data {
    public string Ticker { get; set; }
    public string Name { get; set; }
    public double Rate { get; set; }
    public double BollingerUpper { get; set; }
    public double BollingerLower { get; set; }

    public override string ToString() {
      return "Ticker: " + Ticker
          + "\nName: " + Name
          + "\nRate: " + Rate.ToString()
          + "\nBollingerUpper: " + BollingerUpper.ToString()
          + "\nBollingerLower: " + BollingerLower.ToString();
    }
  }
}
