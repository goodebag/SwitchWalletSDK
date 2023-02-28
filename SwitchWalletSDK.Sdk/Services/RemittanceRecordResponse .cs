using SwitchWalletSDK.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HttpStatusCode = SwitchWalletSDK.Sdk.Models.HttpStatusCode;

namespace SwitchWalletSDK.Sdk.Services
{
    public class RemittanceRecordResponse : ServiceResponse
    {
        public PaginatedResult<RemittanceByMerchantResponse> Data { get; set; }
    }
    public abstract class ServiceResponse
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; } 
        public KYC_Status KYC_Status { get; set; }
    }
    public class PaginatedResult<T> where T : class
    {
        public IEnumerable<T> Records { get; set; } = Enumerable.Empty<T>();
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
    }
    public class RemittanceByMerchantResponse
    {
        public string Reference { get; set; }
        public string Status { get; set; }
        public string FailureReason { get; set; }
        public string ToAddress { get; set; }
        public string FromAddress { get; set; }
        public string ToAddressUrl { get; set; }
        public string FromAddressUrl { get; set; }
        public Currency Currency { get; set; }
        public long TransactionTimeStamp { get; set; }
        public GasPaymentResponse GasPayment { get; set; }
        public RemittancePaymentResponse RemittancePayment { get; set; }
    }
}
