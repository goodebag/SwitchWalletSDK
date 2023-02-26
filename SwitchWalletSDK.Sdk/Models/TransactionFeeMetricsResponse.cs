using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchWalletSDK.Sdk.Models
{
    public partial class TransactionFeeMetricsData
    {
        [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NetworkChain { get; set; }

        [Newtonsoft.Json.JsonProperty("highest", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Highest { get; set; }

        [Newtonsoft.Json.JsonProperty("lowest", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Lowest { get; set; }

        [Newtonsoft.Json.JsonProperty("average", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Average { get; set; }

        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Total { get; set; }

    }
    public partial class TransactionFeeMetricsPayload
    {
        [Newtonsoft.Json.JsonProperty("fees", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<TransactionFeeMetricsData> Fees { get; set; }

    }
    public partial class TransactionFeeMetricsResponse
    {
        [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public TransactionFeeMetricsPayload Data { get; set; }

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
