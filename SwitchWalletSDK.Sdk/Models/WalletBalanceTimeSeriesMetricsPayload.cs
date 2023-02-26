using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchWalletSDK.Sdk.Models
{
    public partial class WalletBalanceTimeSeriesMetricsPayload
    {
        [Newtonsoft.Json.JsonProperty("chartData", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<TimeSeriesData> ChartData { get; set; }

    }
}
