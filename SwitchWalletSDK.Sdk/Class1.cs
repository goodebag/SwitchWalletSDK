//namespace SwitchWalletSDK.Sdk
//{
//    using SwitchWallet.Sdk;
//    using SwitchWalletSDK.Sdk.Models;

//#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
//#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
//#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
//#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
//#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."
//#pragma warning disable 8073 // Disable "CS8073 The result of the expression is always 'false' since a value of type 'T' is never equal to 'null' of type 'T?'"
//#pragma warning disable 3016 // Disable "CS3016 Arrays as attribute arguments is not CLS-compliant"
//#pragma warning disable 8603 // Disable "CS8603 Possible null reference return"


//    using System = global::System;

//        [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
//        public partial class SwitchWalletClient
//        {
//            private string _baseUrl = "";
//            private string _ProductionbaseUrl = "https://mainnet.switchwallet.io/";
//            private string _SandboxbaseUrl = "https://testnet.switchwallet.io/";
//            private System.Net.Http.HttpClient _httpClient;
//            private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;

//            public SwitchWalletClient(EnvironmentType environment, System.Net.Http.HttpClient httpClient)
//            {
//                SetBaseUrl(environment);
//                _httpClient = httpClient;
//                _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(CreateSerializerSettings);
//            }
//            private void SetBaseUrl(EnvironmentType environmentType)
//            {
//                if (environmentType == EnvironmentType.Production)
//                    _baseUrl = _ProductionbaseUrl;
//                else if (environmentType == EnvironmentType.Sandbox)
//                    _baseUrl = _SandboxbaseUrl;
//                else
//                    _baseUrl = _SandboxbaseUrl;
//            }
//            private Newtonsoft.Json.JsonSerializerSettings CreateSerializerSettings()
//            {
//                var settings = new Newtonsoft.Json.JsonSerializerSettings();
//                UpdateJsonSerializerSettings(settings);
//                return settings;
//            }

//            public string BaseUrl
//            {
//                get { return _baseUrl; }
//                set { _baseUrl = value; }
//            }

//            protected Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings { get { return _settings.Value; } }

//            partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);

//            partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
//            partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
//            partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);



//            /// <summary>
//            /// Starts a withdrawal process
//            /// </summary>
//            /// <returns>Success</returns>
//            /// <exception cref="ApiException">A server side error occurred.</exception>
//            public virtual System.Threading.Tasks.Task<InitiateWithdrawalResponseApiResponseModel> MerchantClientWithdrawalAsync(InitiateWithdrawalPayload body)
//            {
//                return MerchantClientWithdrawalAsync(body, System.Threading.CancellationToken.None);
//            }

//            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
//            /// <summary>
//            /// Starts a withdrawal process
//            /// </summary>
//            /// <returns>Success</returns>
//            /// <exception cref="ApiException">A server side error occurred.</exception>
//            protected virtual async System.Threading.Tasks.Task<InitiateWithdrawalResponseApiResponseModel> MerchantClientWithdrawalAsync(InitiateWithdrawalPayload body, System.Threading.CancellationToken cancellationToken)
//            {
//                var urlBuilder_ = new System.Text.StringBuilder();
//                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/merchantClientWithdrawal?");
//                urlBuilder_.Length--;

//                var client_ = _httpClient;
//                var disposeClient_ = false;
//                try
//                {
//                    using (var request_ = new System.Net.Http.HttpRequestMessage())
//                    {
//                        var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
//                        var content_ = new System.Net.Http.StringContent(json_);
//                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json-patch+json; ver=1.0");
//                        request_.Content = content_;
//                        request_.Method = new System.Net.Http.HttpMethod("POST");
//                        request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain; ver=1.0"));

//                        PrepareRequest(client_, request_, urlBuilder_);

//                        var url_ = urlBuilder_.ToString();
//                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

//                        PrepareRequest(client_, request_, url_);

//                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
//                        var disposeResponse_ = true;
//                        try
//                        {
//                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
//                            if (response_.Content != null && response_.Content.Headers != null)
//                            {
//                                foreach (var item_ in response_.Content.Headers)
//                                    headers_[item_.Key] = item_.Value;
//                            }

//                            ProcessResponse(client_, response_);

//                            var status_ = (int)response_.StatusCode;
//                            if (status_ == 200)
//                            {
//                                var objectResponse_ = await ReadObjectResponseAsync<InitiateWithdrawalResponseApiResponseModel>(response_, headers_, cancellationToken).ConfigureAwait(false);
//                                if (objectResponse_.Object == null)
//                                {
//                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
//                                }
//                                return objectResponse_.Object;
//                            }
//                            else
//                            if (status_ == 400)
//                            {
//                                var objectResponse_ = await ReadObjectResponseAsync<ApiResponseModel>(response_, headers_, cancellationToken).ConfigureAwait(false);
//                                if (objectResponse_.Object == null)
//                                {
//                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
//                                }
//                                throw new ApiException<ApiResponseModel>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
//                            }
//                            else
//                            if (status_ == 401)
//                            {
//                                var objectResponse_ = await ReadObjectResponseAsync<ProblemDetails>(response_, headers_, cancellationToken).ConfigureAwait(false);
//                                if (objectResponse_.Object == null)
//                                {
//                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
//                                }
//                                throw new ApiException<ProblemDetails>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
//                            }
//                            else
//                            {
//                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
//                                throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
//                            }
//                        }
//                        finally
//                        {
//                            if (disposeResponse_)
//                                response_.Dispose();
//                        }
//                    }
//                }
//                finally
//                {
//                    if (disposeClient_)
//                        client_.Dispose();
//                }
//            }

//            /// <summary>
//            /// Retrieves the status of an initiated withdrawal
//            /// </summary>
//            /// <returns>Success</returns>
//            /// <exception cref="ApiException">A server side error occurred.</exception>
//            public virtual System.Threading.Tasks.Task<WithdrawalStatusResponseApiResponseModel> ClientWithdrawalStatusAsync(string merchantReference)
//            {
//                return ClientWithdrawalStatusAsync(merchantReference, System.Threading.CancellationToken.None);
//            }

//            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
//            /// <summary>
//            /// Retrieves the status of an initiated withdrawal
//            /// </summary>
//            /// <returns>Success</returns>
//            /// <exception cref="ApiException">A server side error occurred.</exception>
//            protected virtual async System.Threading.Tasks.Task<WithdrawalStatusResponseApiResponseModel> ClientWithdrawalStatusAsync(string merchantReference, System.Threading.CancellationToken cancellationToken)
//            {
//                if (merchantReference == null)
//                    throw new System.ArgumentNullException("merchantReference");

//                var urlBuilder_ = new System.Text.StringBuilder();
//                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/merchantClientWithdrawal/status/{merchantReference}?");
//                urlBuilder_.Replace("{merchantReference}", System.Uri.EscapeDataString(ConvertToString(merchantReference, System.Globalization.CultureInfo.InvariantCulture)));
//                urlBuilder_.Length--;

//                var client_ = _httpClient;
//                var disposeClient_ = false;
//                try
//                {
//                    using (var request_ = new System.Net.Http.HttpRequestMessage())
//                    {
//                        request_.Method = new System.Net.Http.HttpMethod("GET");
//                        request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain; ver=1.0"));

//                        PrepareRequest(client_, request_, urlBuilder_);

//                        var url_ = urlBuilder_.ToString();
//                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

//                        PrepareRequest(client_, request_, url_);

//                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
//                        var disposeResponse_ = true;
//                        try
//                        {
//                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
//                            if (response_.Content != null && response_.Content.Headers != null)
//                            {
//                                foreach (var item_ in response_.Content.Headers)
//                                    headers_[item_.Key] = item_.Value;
//                            }

//                            ProcessResponse(client_, response_);

//                            var status_ = (int)response_.StatusCode;
//                            if (status_ == 200)
//                            {
//                                var objectResponse_ = await ReadObjectResponseAsync<WithdrawalStatusResponseApiResponseModel>(response_, headers_, cancellationToken).ConfigureAwait(false);
//                                if (objectResponse_.Object == null)
//                                {
//                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
//                                }
//                                return objectResponse_.Object;
//                            }
//                            else
//                            if (status_ == 400)
//                            {
//                                var objectResponse_ = await ReadObjectResponseAsync<ApiResponseModel>(response_, headers_, cancellationToken).ConfigureAwait(false);
//                                if (objectResponse_.Object == null)
//                                {
//                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
//                                }
//                                throw new ApiException<ApiResponseModel>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
//                            }
//                            else
//                            if (status_ == 401)
//                            {
//                                var objectResponse_ = await ReadObjectResponseAsync<ProblemDetails>(response_, headers_, cancellationToken).ConfigureAwait(false);
//                                if (objectResponse_.Object == null)
//                                {
//                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
//                                }
//                                throw new ApiException<ProblemDetails>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
//                            }
//                            else
//                            {
//                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
//                                throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
//                            }
//                        }
//                        finally
//                        {
//                            if (disposeResponse_)
//                                response_.Dispose();
//                        }
//                    }
//                }
//                finally
//                {
//                    if (disposeClient_)
//                        client_.Dispose();
//                }
//            }

//            /// <returns>Success</returns>
//            /// <exception cref="ApiException">A server side error occurred.</exception>
//            public virtual System.Threading.Tasks.Task<GenerateDepositAddressRespsoneApiResponseModel> GenerateWalletAddressAsync(GenerateAddressForPaymentPayload body)
//            {
//                return GenerateWalletAddressAsync(body, System.Threading.CancellationToken.None);
//            }

//            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
//            /// <returns>Success</returns>
//            /// <exception cref="ApiException">A server side error occurred.</exception>
//            protected virtual async System.Threading.Tasks.Task<GenerateDepositAddressRespsoneApiResponseModel> GenerateWalletAddressAsync(GenerateAddressForPaymentPayload body, System.Threading.CancellationToken cancellationToken)
//            {
//                var urlBuilder_ = new System.Text.StringBuilder();
//                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/v1/walletAddress/generate?");
//                urlBuilder_.Length--;

//                var client_ = _httpClient;
//                var disposeClient_ = false;
//                try
//                {
//                    using (var request_ = new System.Net.Http.HttpRequestMessage())
//                    {
//                        var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
//                        var content_ = new System.Net.Http.StringContent(json_);
//                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json-patch+json; ver=1.0");
//                        request_.Content = content_;
//                        request_.Method = new System.Net.Http.HttpMethod("POST");
//                        request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain; ver=1.0"));

//                        PrepareRequest(client_, request_, urlBuilder_);

//                        var url_ = urlBuilder_.ToString();
//                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

//                        PrepareRequest(client_, request_, url_);

//                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
//                        var disposeResponse_ = true;
//                        try
//                        {
//                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
//                            if (response_.Content != null && response_.Content.Headers != null)
//                            {
//                                foreach (var item_ in response_.Content.Headers)
//                                    headers_[item_.Key] = item_.Value;
//                            }

//                            ProcessResponse(client_, response_);

//                            var status_ = (int)response_.StatusCode;
//                            if (status_ == 200)
//                            {
//                                var objectResponse_ = await ReadObjectResponseAsync<GenerateDepositAddressRespsoneApiResponseModel>(response_, headers_, cancellationToken).ConfigureAwait(false);
//                                if (objectResponse_.Object == null)
//                                {
//                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
//                                }
//                                return objectResponse_.Object;
//                            }
//                            else
//                            if (status_ == 400)
//                            {
//                                var objectResponse_ = await ReadObjectResponseAsync<ErrorDetailsApiResponseModel>(response_, headers_, cancellationToken).ConfigureAwait(false);
//                                if (objectResponse_.Object == null)
//                                {
//                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
//                                }
//                                throw new ApiException<ErrorDetailsApiResponseModel>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
//                            }
//                            else
//                            {
//                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
//                                throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
//                            }
//                        }
//                        finally
//                        {
//                            if (disposeResponse_)
//                                response_.Dispose();
//                        }
//                    }
//                }
//                finally
//                {
//                    if (disposeClient_)
//                        client_.Dispose();
//                }
//            }

//            /// <returns>Success</returns>
//            /// <exception cref="ApiException">A server side error occurred.</exception>
//            public virtual System.Threading.Tasks.Task<WalletBalanceApiResponseModel> OriginAccountBalanceAsync(string publicKey)
//            {
//                return OriginAccountsAsync(publicKey, System.Threading.CancellationToken.None);
//            }

//            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
//            /// <returns>Success</returns>
//            /// <exception cref="ApiException">A server side error occurred.</exception>
//            protected virtual async System.Threading.Tasks.Task<WalletBalanceApiResponseModel> OriginAccountsAsync(string publicKey, System.Threading.CancellationToken cancellationToken)
//            {
//                var urlBuilder_ = new System.Text.StringBuilder();
//                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/v1/walletBalance/originAccounts?");
//                if (publicKey != null)
//                {
//                    urlBuilder_.Append(System.Uri.EscapeDataString("publicKey") + "=").Append(System.Uri.EscapeDataString(ConvertToString(publicKey, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
//                }
//                urlBuilder_.Length--;

//                var client_ = _httpClient;
//                var disposeClient_ = false;
//                try
//                {
//                    using (var request_ = new System.Net.Http.HttpRequestMessage())
//                    {
//                        request_.Method = new System.Net.Http.HttpMethod("GET");
//                        request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain; ver=1.0"));

//                        PrepareRequest(client_, request_, urlBuilder_);

//                        var url_ = urlBuilder_.ToString();
//                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

//                        PrepareRequest(client_, request_, url_);

//                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
//                        var disposeResponse_ = true;
//                        try
//                        {
//                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
//                            if (response_.Content != null && response_.Content.Headers != null)
//                            {
//                                foreach (var item_ in response_.Content.Headers)
//                                    headers_[item_.Key] = item_.Value;
//                            }

//                            ProcessResponse(client_, response_);

//                            var status_ = (int)response_.StatusCode;
//                            if (status_ == 200)
//                            {
//                                var objectResponse_ = await ReadObjectResponseAsync<WalletBalanceApiResponseModel>(response_, headers_, cancellationToken).ConfigureAwait(false);
//                                if (objectResponse_.Object == null)
//                                {
//                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
//                                }
//                                return objectResponse_.Object;
//                            }
//                            else
//                            if (status_ == 400)
//                            {
//                                var objectResponse_ = await ReadObjectResponseAsync<ApiResponseModel>(response_, headers_, cancellationToken).ConfigureAwait(false);
//                                if (objectResponse_.Object == null)
//                                {
//                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
//                                }
//                                throw new ApiException<ApiResponseModel>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
//                            }
//                            else
//                            {
//                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
//                                throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
//                            }
//                        }
//                        finally
//                        {
//                            if (disposeResponse_)
//                                response_.Dispose();
//                        }
//                    }
//                }
//                finally
//                {
//                    if (disposeClient_)
//                        client_.Dispose();
//                }
//            }


//            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
//            /// <summary>
//            /// Authenticates a user and generates an access token to be used in subsequent requests
//            /// </summary>
//            /// <returns>Success</returns>
//            /// <exception cref="ApiException">A server side error occurred.</exception>


//            /// <summary>
//            /// Support new network
//            /// </summary>
//            /// <returns>Success</returns>
//            /// <exception cref="ApiException">A server side error occurred.</exception>
//            public virtual System.Threading.Tasks.Task<CreatedMerchantViewModelApiResponseModel> AddNetworkChainAsync(AddSupportedNetworkDto body)
//            {
//                return AddNetworkChainAsync(body, System.Threading.CancellationToken.None);
//            }

//            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
//            /// <summary>
//            /// Support new network
//            /// </summary>
//            /// <returns>Success</returns>
//            /// <exception cref="ApiException">A server side error occurred.</exception>
//            protected virtual async System.Threading.Tasks.Task<CreatedMerchantViewModelApiResponseModel> AddNetworkChainAsync(AddSupportedNetworkDto body, System.Threading.CancellationToken cancellationToken)
//            {
//                var urlBuilder_ = new System.Text.StringBuilder();
//                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/v2/merchant/add-network-chain?");
//                urlBuilder_.Length--;

//                var client_ = _httpClient;
//                var disposeClient_ = false;
//                try
//                {
//                    using (var request_ = new System.Net.Http.HttpRequestMessage())
//                    {
//                        var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
//                        var content_ = new System.Net.Http.StringContent(json_);
//                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json-patch+json; ver=2.0");
//                        request_.Content = content_;
//                        request_.Method = new System.Net.Http.HttpMethod("POST");
//                        request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain; ver=2.0"));

//                        PrepareRequest(client_, request_, urlBuilder_);

//                        var url_ = urlBuilder_.ToString();
//                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

//                        PrepareRequest(client_, request_, url_);

//                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
//                        var disposeResponse_ = true;
//                        try
//                        {
//                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
//                            if (response_.Content != null && response_.Content.Headers != null)
//                            {
//                                foreach (var item_ in response_.Content.Headers)
//                                    headers_[item_.Key] = item_.Value;
//                            }

//                            ProcessResponse(client_, response_);

//                            var status_ = (int)response_.StatusCode;
//                            if (status_ == 200)
//                            {
//                                var objectResponse_ = await ReadObjectResponseAsync<CreatedMerchantViewModelApiResponseModel>(response_, headers_, cancellationToken).ConfigureAwait(false);
//                                if (objectResponse_.Object == null)
//                                {
//                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
//                                }
//                                return objectResponse_.Object;
//                            }
//                            else
//                            if (status_ == 400)
//                            {
//                                var objectResponse_ = await ReadObjectResponseAsync<ApiResponseModel>(response_, headers_, cancellationToken).ConfigureAwait(false);
//                                if (objectResponse_.Object == null)
//                                {
//                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
//                                }
//                                throw new ApiException<ApiResponseModel>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
//                            }
//                            else
//                            if (status_ == 401)
//                            {
//                                var objectResponse_ = await ReadObjectResponseAsync<ProblemDetails>(response_, headers_, cancellationToken).ConfigureAwait(false);
//                                if (objectResponse_.Object == null)
//                                {
//                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
//                                }
//                                throw new ApiException<ProblemDetails>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
//                            }
//                            else
//                            {
//                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
//                                throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
//                            }
//                        }
//                        finally
//                        {
//                            if (disposeResponse_)
//                                response_.Dispose();
//                        }
//                    }
//                }
//                finally
//                {
//                    if (disposeClient_)
//                        client_.Dispose();
//                }
//            }

         

//            /// <summary>
//            /// Get Transaction Record
//            /// </summary>
//            /// <param name="currency">1 = BTC
//            /// <br/>
//            /// <br/>2 = LTC
//            /// <br/>
//            /// <br/>3 = BNB
//            /// <br/>
//            /// <br/>4 = USDT
//            /// <br/>
//            /// <br/>5 = DAI
//            /// <br/>
//            /// <br/>6 = BUSD
//            /// <br/>
//            /// <br/>7 = XEND
//            /// <br/>
//            /// <br/>8 = ETH
//            /// <br/>
//            /// <br/>9 = MATIC
//            /// <br/>
//            /// <br/>10 = WNT
//            /// <br/>
//            /// <br/>11 = USDC
//            /// <br/>
//            /// <br/>12 = cUSD
//            /// <br/>
//            /// <br/>13 = cEUR
//            /// <br/>
//            /// <br/>14 = CELO
//            /// <br/>
//            /// <br/>15 = TRX
//            /// <br/>
//            /// <br/>16 = USDJ
//            /// <br/>
//            /// <br/>17 = TUSD</param>
//            /// <param name="networkChain">1 = BSC
//            /// <br/>
//            /// <br/>2 = ETHEREUM
//            /// <br/>
//            /// <br/>3 = POLYGON
//            /// <br/>
//            /// <br/>4 = CELO
//            /// <br/>
//            /// <br/>5 = ARBITRUM
//            /// <br/>
//            /// <br/>6 = AVALANCHE
//            /// <br/>
//            /// <br/>7 = HecoChain
//            /// <br/>
//            /// <br/>8 = TRON</param>
//            /// <param name="status">0 = Pending
//            /// <br/>
//            /// <br/>1 = Successful
//            /// <br/>
//            /// <br/>2 = Failed
//            /// <br/>
//            /// <br/>3 = Initiated</param>
//            /// <param name="transactionType">1 = Deposit
//            /// <br/>
//            /// <br/>2 = Withdrawal</param>
//            /// <returns>Success</returns>
//            /// <exception cref="ApiException">A server side error occurred.</exception>
//            public virtual System.Threading.Tasks.Task<TransactionRecordResponse> GetTransactionRecordAsync(long? startTimeStamp = null, long? endTimeStamp = null, CurrencySymbol? currency = null, NetworkChain? networkChain = null, OperationStatus? status = null, string transactionHash = null, string walletAddress = null, TransactionType? transactionType = null, int? page = 1, int? pageSize = 30)
//            {
//                return TransactionRecordAsync(currency, networkChain, status, transactionHash, walletAddress, transactionType, page, pageSize, startTimeStamp, endTimeStamp, System.Threading.CancellationToken.None);
//            }

//            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
//            /// <summary>
//            /// Get Transaction Record
//            /// </summary>
//            /// <param name="currency">1 = BTC
//            /// <br/>
//            /// <br/>2 = LTC
//            /// <br/>
//            /// <br/>3 = BNB
//            /// <br/>
//            /// <br/>4 = USDT
//            /// <br/>
//            /// <br/>5 = DAI
//            /// <br/>
//            /// <br/>6 = BUSD
//            /// <br/>
//            /// <br/>7 = XEND
//            /// <br/>
//            /// <br/>8 = ETH
//            /// <br/>
//            /// <br/>9 = MATIC
//            /// <br/>
//            /// <br/>10 = WNT
//            /// <br/>
//            /// <br/>11 = USDC
//            /// <br/>
//            /// <br/>12 = cUSD
//            /// <br/>
//            /// <br/>13 = cEUR
//            /// <br/>
//            /// <br/>14 = CELO
//            /// <br/>
//            /// <br/>15 = TRX
//            /// <br/>
//            /// <br/>16 = USDJ
//            /// <br/>
//            /// <br/>17 = TUSD</param>
//            /// <param name="networkChain">1 = BSC
//            /// <br/>
//            /// <br/>2 = ETHEREUM
//            /// <br/>
//            /// <br/>3 = POLYGON
//            /// <br/>
//            /// <br/>4 = CELO
//            /// <br/>
//            /// <br/>5 = ARBITRUM
//            /// <br/>
//            /// <br/>6 = AVALANCHE
//            /// <br/>
//            /// <br/>7 = HecoChain
//            /// <br/>
//            /// <br/>8 = TRON</param>
//            /// <param name="status">0 = Pending
//            /// <br/>
//            /// <br/>1 = Successful
//            /// <br/>
//            /// <br/>2 = Failed
//            /// <br/>
//            /// <br/>3 = Initiated</param>
//            /// <param name="transactionType">1 = Deposit
//            /// <br/>
//            /// <br/>2 = Withdrawal</param>
//            /// <returns>Success</returns>
//            /// <exception cref="ApiException">A server side error occurred.</exception>
//            protected virtual async System.Threading.Tasks.Task<TransactionRecordResponse> TransactionRecordAsync(CurrencySymbol? currency, NetworkChain? networkChain, OperationStatus? status, string transactionHash, string walletAddress, TransactionType? transactionType, int? page, int? pageSize, long? startTimeStamp, long? endTimeStamp, System.Threading.CancellationToken cancellationToken)
//            {
//                var urlBuilder_ = new System.Text.StringBuilder();
//                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/v2/analytics/transaction-record?");
//                if (currency != null)
//                {
//                    urlBuilder_.Append(System.Uri.EscapeDataString("Currency") + "=").Append(System.Uri.EscapeDataString(ConvertToString(currency, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
//                }
//                if (networkChain != null)
//                {
//                    urlBuilder_.Append(System.Uri.EscapeDataString("NetworkChain") + "=").Append(System.Uri.EscapeDataString(ConvertToString(networkChain, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
//                }
//                if (status != null)
//                {
//                    urlBuilder_.Append(System.Uri.EscapeDataString("Status") + "=").Append(System.Uri.EscapeDataString(ConvertToString(status, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
//                }
//                if (transactionHash != null)
//                {
//                    urlBuilder_.Append(System.Uri.EscapeDataString("TransactionHash") + "=").Append(System.Uri.EscapeDataString(ConvertToString(transactionHash, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
//                }
//                if (walletAddress != null)
//                {
//                    urlBuilder_.Append(System.Uri.EscapeDataString("WalletAddress") + "=").Append(System.Uri.EscapeDataString(ConvertToString(walletAddress, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
//                }
//                if (transactionType != null)
//                {
//                    urlBuilder_.Append(System.Uri.EscapeDataString("TransactionType") + "=").Append(System.Uri.EscapeDataString(ConvertToString(transactionType, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
//                }
//                if (page != null)
//                {
//                    urlBuilder_.Append(System.Uri.EscapeDataString("Page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
//                }
//                if (pageSize != null)
//                {
//                    urlBuilder_.Append(System.Uri.EscapeDataString("PageSize") + "=").Append(System.Uri.EscapeDataString(ConvertToString(pageSize, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
//                }
//                if (startTimeStamp != null)
//                {
//                    urlBuilder_.Append(System.Uri.EscapeDataString("StartTimeStamp") + "=").Append(System.Uri.EscapeDataString(ConvertToString(startTimeStamp, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
//                }
//                if (endTimeStamp != null)
//                {
//                    urlBuilder_.Append(System.Uri.EscapeDataString("EndTimeStamp") + "=").Append(System.Uri.EscapeDataString(ConvertToString(endTimeStamp, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
//                }
//                urlBuilder_.Length--;

//                var client_ = _httpClient;
//                var disposeClient_ = false;
//                try
//                {
//                    using (var request_ = new System.Net.Http.HttpRequestMessage())
//                    {
//                        request_.Method = new System.Net.Http.HttpMethod("GET");
//                        request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

//                        PrepareRequest(client_, request_, urlBuilder_);

//                        var url_ = urlBuilder_.ToString();
//                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

//                        PrepareRequest(client_, request_, url_);

//                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
//                        var disposeResponse_ = true;
//                        try
//                        {
//                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
//                            if (response_.Content != null && response_.Content.Headers != null)
//                            {
//                                foreach (var item_ in response_.Content.Headers)
//                                    headers_[item_.Key] = item_.Value;
//                            }

//                            ProcessResponse(client_, response_);

//                            var status_ = (int)response_.StatusCode;
//                            if (status_ == 200)
//                            {
//                                var objectResponse_ = await ReadObjectResponseAsync<TransactionRecordResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
//                                if (objectResponse_.Object == null)
//                                {
//                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
//                                }
//                                return objectResponse_.Object;
//                            }
//                            else
//                            if (status_ == 400)
//                            {
//                                var objectResponse_ = await ReadObjectResponseAsync<ErrorDetails>(response_, headers_, cancellationToken).ConfigureAwait(false);
//                                if (objectResponse_.Object == null)
//                                {
//                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
//                                }
//                                throw new ApiException<ErrorDetails>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
//                            }
//                            else
//                            {
//                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
//                                throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
//                            }
//                        }
//                        finally
//                        {
//                            if (disposeResponse_)
//                                response_.Dispose();
//                        }
//                    }
//                }
//                finally
//                {
//                    if (disposeClient_)
//                        client_.Dispose();
//                }
//            }

//            /// <summary>
//            /// Get Timed Transaction Record,Defualted To Last 7 Days
//            /// </summary>
//            /// <returns>Success</returns>
//            /// <exception cref="ApiException">A server side error occurred.</exception>
//            public virtual System.Threading.Tasks.Task<TransactionRecordResponse> GetTimedTransactionRecordAsync(int? page = 1, int? pageSize = 30, long? startTimeStamp = null, long? endTimeStamp = null)
//            {
//                return TimedTransactionRecordAsync(page, pageSize, startTimeStamp, endTimeStamp, System.Threading.CancellationToken.None);
//            }

//            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
//            /// <summary>
//            /// Get Timed Transaction Record,Defualted To Last 7 Days
//            /// </summary>
//            /// <returns>Success</returns>
//            /// <exception cref="ApiException">A server side error occurred.</exception>
//            protected virtual async System.Threading.Tasks.Task<TransactionRecordResponse> TimedTransactionRecordAsync(int? page, int? pageSize, long? startTimeStamp, long? endTimeStamp, System.Threading.CancellationToken cancellationToken)
//            {
//                var urlBuilder_ = new System.Text.StringBuilder();
//                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/v2/analytics/timed-transaction-record?");
//                if (page != null)
//                {
//                    urlBuilder_.Append(System.Uri.EscapeDataString("Page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
//                }
//                if (pageSize != null)
//                {
//                    urlBuilder_.Append(System.Uri.EscapeDataString("PageSize") + "=").Append(System.Uri.EscapeDataString(ConvertToString(pageSize, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
//                }
//                if (startTimeStamp != null)
//                {
//                    urlBuilder_.Append(System.Uri.EscapeDataString("StartTimeStamp") + "=").Append(System.Uri.EscapeDataString(ConvertToString(startTimeStamp, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
//                }
//                if (endTimeStamp != null)
//                {
//                    urlBuilder_.Append(System.Uri.EscapeDataString("EndTimeStamp") + "=").Append(System.Uri.EscapeDataString(ConvertToString(endTimeStamp, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
//                }
//                urlBuilder_.Length--;

//                var client_ = _httpClient;
//                var disposeClient_ = false;
//                try
//                {
//                    using (var request_ = new System.Net.Http.HttpRequestMessage())
//                    {
//                        request_.Method = new System.Net.Http.HttpMethod("GET");
//                        request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

//                        PrepareRequest(client_, request_, urlBuilder_);

//                        var url_ = urlBuilder_.ToString();
//                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

//                        PrepareRequest(client_, request_, url_);

//                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
//                        var disposeResponse_ = true;
//                        try
//                        {
//                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
//                            if (response_.Content != null && response_.Content.Headers != null)
//                            {
//                                foreach (var item_ in response_.Content.Headers)
//                                    headers_[item_.Key] = item_.Value;
//                            }

//                            ProcessResponse(client_, response_);

//                            var status_ = (int)response_.StatusCode;
//                            if (status_ == 200)
//                            {
//                                var objectResponse_ = await ReadObjectResponseAsync<TransactionRecordResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
//                                if (objectResponse_.Object == null)
//                                {
//                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
//                                }
//                                return objectResponse_.Object;
//                            }
//                            else
//                            if (status_ == 400)
//                            {
//                                var objectResponse_ = await ReadObjectResponseAsync<ErrorDetails>(response_, headers_, cancellationToken).ConfigureAwait(false);
//                                if (objectResponse_.Object == null)
//                                {
//                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
//                                }
//                                throw new ApiException<ErrorDetails>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
//                            }
//                            else
//                            {
//                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
//                                throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
//                            }
//                        }
//                        finally
//                        {
//                            if (disposeResponse_)
//                                response_.Dispose();
//                        }
//                    }
//                }
//                finally
//                {
//                    if (disposeClient_)
//                        client_.Dispose();
//                }
//            }
//            protected struct ObjectResponseResult<T>
//            {
//                public ObjectResponseResult(T responseObject, string responseText)
//                {
//                    this.Object = responseObject;
//                    this.Text = responseText;
//                }

//                public T Object { get; }

//                public string Text { get; }
//            }

//            public bool ReadResponseAsString { get; set; }

//            protected virtual async System.Threading.Tasks.Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(System.Net.Http.HttpResponseMessage response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Threading.CancellationToken cancellationToken)
//            {
//                if (response == null || response.Content == null)
//                {
//                    return new ObjectResponseResult<T>(default(T), string.Empty);
//                }

//                if (ReadResponseAsString)
//                {
//                    var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
//                    try
//                    {
//                        var typedBody = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseText, JsonSerializerSettings);
//                        return new ObjectResponseResult<T>(typedBody, responseText);
//                    }
//                    catch (Newtonsoft.Json.JsonException exception)
//                    {
//                        var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
//                        throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
//                    }
//                }
//                else
//                {
//                    try
//                    {
//                        using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
//                        using (var streamReader = new System.IO.StreamReader(responseStream))
//                        using (var jsonTextReader = new Newtonsoft.Json.JsonTextReader(streamReader))
//                        {
//                            var serializer = Newtonsoft.Json.JsonSerializer.Create(JsonSerializerSettings);
//                            var typedBody = serializer.Deserialize<T>(jsonTextReader);
//                            return new ObjectResponseResult<T>(typedBody, string.Empty);
//                        }
//                    }
//                    catch (Newtonsoft.Json.JsonException exception)
//                    {
//                        var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
//                        throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
//                    }
//                }
//            }

//            private string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
//            {
//                if (value == null)
//                {
//                    return "";
//                }

//                if (value is System.Enum)
//                {
//                    var name = System.Enum.GetName(value.GetType(), value);
//                    if (name != null)
//                    {
//                        var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
//                        if (field != null)
//                        {
//                            var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute))
//                                as System.Runtime.Serialization.EnumMemberAttribute;
//                            if (attribute != null)
//                            {
//                                return attribute.Value != null ? attribute.Value : name;
//                            }
//                        }

//                        var converted = System.Convert.ToString(System.Convert.ChangeType(value, System.Enum.GetUnderlyingType(value.GetType()), cultureInfo));
//                        return converted == null ? string.Empty : converted;
//                    }
//                }
//                else if (value is bool)
//                {
//                    return System.Convert.ToString((bool)value, cultureInfo).ToLowerInvariant();
//                }
//                else if (value is byte[])
//                {
//                    return System.Convert.ToBase64String((byte[])value);
//                }
//                else if (value.GetType().IsArray)
//                {
//                    var array = System.Linq.Enumerable.OfType<object>((System.Array)value);
//                    return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
//                }

//                var result = System.Convert.ToString(value, cultureInfo);
//                return result == null ? "" : result;
//            }
//        }





//        /// <summary>
//        /// 
//        /// <br/>
//        /// <br/>1 = ACTIVE
//        /// <br/>
//        /// <br/>2 = INACTIVE
//        /// </summary>


       


//    }

//#pragma warning restore 1591
//#pragma warning restore 1573
//#pragma warning restore 472
//#pragma warning restore 114
//#pragma warning restore 108
//#pragma warning restore 3016
//#pragma warning restore 8603

