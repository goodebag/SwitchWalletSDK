using SwitchWalletSDK.Sdk.Models;
using SwitchWalletSDK.Sdk.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchWalletSDK.Sdk.Services
{
    internal class SwitchWalletClient: ISwitchWalletClient
    {
        private readonly IWalletServices _walletServices;

        public SwitchWalletClient(IWalletServices walletServices)
        {
            _walletServices = walletServices;
        }

        public async Task<CreatedMerchantViewModelApiResponseModel> AddNetworkChainAsync(AddSupportedNetworkDto body)
        {
            return await  _walletServices.AddNetworkChainAsync(body);
        }

        public async Task<WithdrawalStatusResponseApiResponseModel> ClientWithdrawalStatusAsync(string merchantReference)
        {
           return await _walletServices.ClientWithdrawalStatusAsync(merchantReference);
        }

        public async Task<GenerateDepositAddressRespsoneApiResponseModel> GenerateWalletAddressAsync(GenerateAddressForPaymentPayload body)
        {
            return await _walletServices.GenerateWalletAddressAsync(body);
        }

        public async Task<TransactionRecordResponse> GetTimedTransactionRecordAsync(int? page = 1, int? pageSize = 30, long? startTimeStamp = null, long? endTimeStamp = null)
        {
           return await _walletServices.GetTimedTransactionRecordAsync(page, pageSize, startTimeStamp, endTimeStamp);
        }

        public async Task<TransactionRecordResponse> GetTransactionRecordAsync(long? startTimeStamp = null, long? endTimeStamp = null, CurrencySymbol? currency = null, NetworkChain? networkChain = null, OperationStatus? status = null, string transactionHash = null, string walletAddress = null, TransactionType? transactionType = null, int? page = 1, int? pageSize = 30)
        {
            return await _walletServices.GetTransactionRecordAsync(startTimeStamp, endTimeStamp, currency, networkChain,status, transactionHash, walletAddress, transactionType, page, pageSize);
        }

        public async Task<InitiateWithdrawalResponseApiResponseModel> MerchantClientWithdrawalAsync(InitiateWithdrawalPayload body)
        {
            return await _walletServices.MerchantClientWithdrawalAsync(body);
        }

        public async Task<WalletBalanceApiResponseModel> OriginAccountBalanceAsync(string publicKey)
        {
           return await _walletServices.OriginAccountBalanceAsync(publicKey);
        }
    }
}
