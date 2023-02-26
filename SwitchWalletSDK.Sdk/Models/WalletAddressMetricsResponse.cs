using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchWalletSDK.Sdk.Models
{
    public partial class WalletAddressMetricsResponse
    {
        [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public WalletAddressMetricsPayloadPaginatedResult Data { get; set; }

        [Newtonsoft.Json.JsonProperty("isSuccessful", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsSuccessful { get; set; }

        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Message { get; set; }

        [Newtonsoft.Json.JsonProperty("httpStatusCode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public HttpStatusCode HttpStatusCode { get; set; }

        [Newtonsoft.Json.JsonProperty("kyC_Status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public KYC_Status KyC_Status { get; set; }

    }
    public partial class WalletAddressMetricsPayloadPaginatedResult
    {
        [Newtonsoft.Json.JsonProperty("records", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<WalletAddressMetricsPayload> Records { get; set; }

        [Newtonsoft.Json.JsonProperty("pageSize", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PageSize { get; set; }

        [Newtonsoft.Json.JsonProperty("currentPage", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CurrentPage { get; set; }

        [Newtonsoft.Json.JsonProperty("totalPages", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int TotalPages { get; set; }

        [Newtonsoft.Json.JsonProperty("totalRecords", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int TotalRecords { get; set; }

    }
    public partial class WalletAddressMetricsPayload
    {
        [Newtonsoft.Json.JsonProperty("walletAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string WalletAddress { get; set; }

        [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Status { get; set; }

        [Newtonsoft.Json.JsonProperty("isAssigned", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsAssigned { get; set; }

        [Newtonsoft.Json.JsonProperty("dateAssigned", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long? DateAssigned { get; set; }

        [Newtonsoft.Json.JsonProperty("balances", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<AggregatedWalletBalanceData> Balances { get; set; }

        [Newtonsoft.Json.JsonProperty("totalBalanceInUSD", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TotalBalanceInUSD { get; set; }

        [Newtonsoft.Json.JsonProperty("currenciesReceivedByAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CurrencyCategoryData> CurrenciesReceivedByAddress { get; set; }

        [Newtonsoft.Json.JsonProperty("deposits", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public TransactionMetricsData Deposits { get; set; }

    }
}
