using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchWalletSDK.Sdk.Models
{
    public partial class TransactionRecordResponse
    {
        [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public TransactionRecordPayloadPaginatedResult Data { get; set; }

        [Newtonsoft.Json.JsonProperty("isSuccessful", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsSuccessful { get; set; }

        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Message { get; set; }

        [Newtonsoft.Json.JsonProperty("httpStatusCode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public HttpStatusCode HttpStatusCode { get; set; }

        [Newtonsoft.Json.JsonProperty("kyC_Status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public KYC_Status KyC_Status { get; set; }

    }
    public partial class TransactionRecordPayloadPaginatedResult
    {
        [Newtonsoft.Json.JsonProperty("records", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<TransactionRecordPayload> Records { get; set; }

        [Newtonsoft.Json.JsonProperty("pageSize", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PageSize { get; set; }

        [Newtonsoft.Json.JsonProperty("currentPage", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CurrentPage { get; set; }

        [Newtonsoft.Json.JsonProperty("totalPages", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int TotalPages { get; set; }

        [Newtonsoft.Json.JsonProperty("totalRecords", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int TotalRecords { get; set; }

    }
    public partial class TransactionRecordPayload
    {
        [Newtonsoft.Json.JsonProperty("transactionStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TransactionStatus { get; set; }

        [Newtonsoft.Json.JsonProperty("transactionType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TransactionType { get; set; }

        [Newtonsoft.Json.JsonProperty("transactionHash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TransactionHash { get; set; }

        [Newtonsoft.Json.JsonProperty("transactionHashUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TransactionHashUrl { get; set; }

        [Newtonsoft.Json.JsonProperty("toAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ToAddress { get; set; }

        [Newtonsoft.Json.JsonProperty("fromAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FromAddress { get; set; }

        [Newtonsoft.Json.JsonProperty("toAddressUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ToAddressUrl { get; set; }

        [Newtonsoft.Json.JsonProperty("fromAddressUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FromAddressUrl { get; set; }

        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Amount { get; set; }

        [Newtonsoft.Json.JsonProperty("network", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Network { get; set; }

        [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Currency { get; set; }

        [Newtonsoft.Json.JsonProperty("transactionTimeStamp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long TransactionTimeStamp { get; set; }

        [Newtonsoft.Json.JsonProperty("reference", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Reference { get; set; }

        [Newtonsoft.Json.JsonProperty("createdAt", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset CreatedAt { get; set; }

    }
    public partial class TransactionMetricsResponse
    {
        [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public TransactionMetricsPayload Data { get; set; }

        [Newtonsoft.Json.JsonProperty("isSuccessful", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsSuccessful { get; set; }

        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Message { get; set; }

        [Newtonsoft.Json.JsonProperty("httpStatusCode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public HttpStatusCode HttpStatusCode { get; set; }

        [Newtonsoft.Json.JsonProperty("kyC_Status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public KYC_Status KyC_Status { get; set; }

    }
    public partial class TransactionMetricsPayload
    {
        [Newtonsoft.Json.JsonProperty("deposits", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public TransactionMetricsData Deposits { get; set; }

        [Newtonsoft.Json.JsonProperty("withdrawals", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public TransactionMetricsData Withdrawals { get; set; }

    }
    public partial class TransactionMetricsData
    {
        [Newtonsoft.Json.JsonProperty("volume", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Volume { get; set; }

        [Newtonsoft.Json.JsonProperty("count", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Count { get; set; }

        [Newtonsoft.Json.JsonProperty("currencies", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<TransactionCurrencyMetricsData> Currencies { get; set; }

    }
}
