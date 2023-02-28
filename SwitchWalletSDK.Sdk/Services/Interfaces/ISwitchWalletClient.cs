using SwitchWalletSDK.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchWalletSDK.Sdk.Services.Interfaces
{
    public interface ISwitchWalletClient
    {
        Task<InitiateWithdrawalResponseApiResponseModel> MerchantClientWithdrawalAsync(InitiateWithdrawalPayload body);
        Task<WithdrawalStatusResponseApiResponseModel> ClientWithdrawalStatusAsync(string merchantReference);
        Task<GenerateDepositAddressRespsoneApiResponseModel> GenerateWalletAddressAsync(GenerateAddressForPaymentPayload body);
        Task<WalletBalanceApiResponseModel> OriginAccountBalanceAsync(string publicKey);
        Task<CreatedMerchantViewModelApiResponseModel> AddNetworkChainAsync(AddSupportedNetworkDto body);
        Task<TransactionRecordResponse> GetTransactionRecordAsync(long? startTimeStamp = null, long? endTimeStamp = null, CurrencySymbol? currency = null, NetworkChain? networkChain = null, OperationStatus? status = null, string transactionHash = null, string walletAddress = null, TransactionType? transactionType = null, int? page = 1, int? pageSize = 30);
        Task<TransactionRecordResponse> GetTimedTransactionRecordAsync(int? page = 1, int? pageSize = 30, long? startTimeStamp = null, long? endTimeStamp = null);
        Task<RemittanceRecordResponse> RemittanceRecordAsync(OperationStatus? status = null, string toAddress = null, CurrencySymbol? currencySymbol = null, NetworkChain? networkChain = null, long? startTimeStamp = null, long? endTimeStamp = null, int? page = 1, int? pageSize = 30);
        Task<WalletBalanceTimeSeriesMetricsResponse> UnremittedTransactionAsync(GroupByCategory? currencyOrNetwork = null, GroupByPeriod? groupByPeriod = null, long? startTimeStamp = null, long? endTimeStamp = null);
        Task<CurrencyModelIEnumerableApiResponseModel> GetActiveCurrenciesAsync();
        Task<CurrencyModelIEnumerableApiResponseModel> SupportedCurrenciesAsync();
        Task<NetworkModelIEnumerableApiResponseModel> SupportedNetworksAsync();
        Task SetCurrencesAsync(IEnumerable<System.Guid> body);
    }
}
