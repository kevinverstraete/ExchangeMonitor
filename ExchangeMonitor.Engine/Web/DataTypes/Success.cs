using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeMonitor.Engine.Web.DataTypes
{
    internal class Success
    {
        public SuccessState State { get; set; }
        public string Information { get; set; }
        public string ErrorInformation { get; set; }

        public Success()
        {
            State = SuccessState.NoData;
            Information = string.Empty;
            ErrorInformation = string.Empty;
        }
    }

    internal enum SuccessState
    {
        Error,
        NoData,
        Success
    }
}
