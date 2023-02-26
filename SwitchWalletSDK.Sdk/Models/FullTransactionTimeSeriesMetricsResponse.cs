using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchWalletSDK.Sdk.Models
{
    /// <summary>
    /// 
    /// <br/>
    /// <br/>1 = BTC
    /// <br/>
    /// <br/>2 = LTC
    /// <br/>
    /// <br/>3 = BNB
    /// <br/>
    /// <br/>4 = USDT
    /// <br/>
    /// <br/>5 = DAI
    /// <br/>
    /// <br/>6 = BUSD
    /// <br/>
    /// <br/>7 = XEND
    /// <br/>
    /// <br/>8 = ETH
    /// <br/>
    /// <br/>9 = MATIC
    /// <br/>
    /// <br/>10 = WNT
    /// <br/>
    /// <br/>11 = USDC
    /// <br/>
    /// <br/>12 = cUSD
    /// <br/>
    /// <br/>13 = cEUR
    /// <br/>
    /// <br/>14 = CELO
    /// <br/>
    /// <br/>15 = TRX
    /// <br/>
    /// <br/>16 = USDJ
    /// <br/>
    /// <br/>17 = TUSD
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class FullTransactionTimeSeriesMetricsPayload
    {
        [Newtonsoft.Json.JsonProperty("count", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Count { get; set; }

        [Newtonsoft.Json.JsonProperty("chartData", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<TimeSeriesData> ChartData { get; set; }

        [Newtonsoft.Json.JsonProperty("aggregatedData", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<TransactionCurrencyMetricsData> AggregatedData { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class FullTransactionTimeSeriesMetricsResponse
    {
        [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public FullTransactionTimeSeriesMetricsPayload Data { get; set; }

        [Newtonsoft.Json.JsonProperty("isSuccessful", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsSuccessful { get; set; }

        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Message { get; set; }

        [Newtonsoft.Json.JsonProperty("httpStatusCode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public HttpStatusCode HttpStatusCode { get; set; }

        [Newtonsoft.Json.JsonProperty("kyC_Status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public KYC_Status KyC_Status { get; set; }

    }

}
