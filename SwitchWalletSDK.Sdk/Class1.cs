namespace SwitchWalletSDK.Sdk
{
    using SwitchWallet.Sdk;

#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."
#pragma warning disable 8073 // Disable "CS8073 The result of the expression is always 'false' since a value of type 'T' is never equal to 'null' of type 'T?'"
#pragma warning disable 3016 // Disable "CS3016 Arrays as attribute arguments is not CLS-compliant"
#pragma warning disable 8603 // Disable "CS8603 Possible null reference return"


        using System = global::System;

        [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class SwitchWalletClient
        {
            private string _baseUrl = "";
            private string _ProductionbaseUrl = "https://mainnet.switchwallet.io/";
            private string _SandboxbaseUrl = "https://testnet.switchwallet.io/";
            private System.Net.Http.HttpClient _httpClient;
            private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;

            public SwitchWalletClient(EnvironmentType environment, System.Net.Http.HttpClient httpClient)
            {
                SetBaseUrl(environment);
                _httpClient = httpClient;
                _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(CreateSerializerSettings);
            }
            private void SetBaseUrl(EnvironmentType environmentType)
            {
                if (environmentType == EnvironmentType.Production)
                    _baseUrl = _ProductionbaseUrl;
                else if (environmentType == EnvironmentType.Sandbox)
                    _baseUrl = _SandboxbaseUrl;
                else
                    _baseUrl = _SandboxbaseUrl;
            }
            private Newtonsoft.Json.JsonSerializerSettings CreateSerializerSettings()
            {
                var settings = new Newtonsoft.Json.JsonSerializerSettings();
                UpdateJsonSerializerSettings(settings);
                return settings;
            }

            public string BaseUrl
            {
                get { return _baseUrl; }
                set { _baseUrl = value; }
            }

            protected Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings { get { return _settings.Value; } }

            partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);

            partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
            partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
            partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);



            /// <summary>
            /// Starts a withdrawal process
            /// </summary>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            public virtual System.Threading.Tasks.Task<InitiateWithdrawalResponseApiResponseModel> MerchantClientWithdrawalAsync(InitiateWithdrawalPayload body)
            {
                return MerchantClientWithdrawalAsync(body, System.Threading.CancellationToken.None);
            }

            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            /// <summary>
            /// Starts a withdrawal process
            /// </summary>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            protected virtual async System.Threading.Tasks.Task<InitiateWithdrawalResponseApiResponseModel> MerchantClientWithdrawalAsync(InitiateWithdrawalPayload body, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/merchantClientWithdrawal?");
                urlBuilder_.Length--;

                var client_ = _httpClient;
                var disposeClient_ = false;
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                        var content_ = new System.Net.Http.StringContent(json_);
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json-patch+json; ver=1.0");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("POST");
                        request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain; ver=1.0"));

                        PrepareRequest(client_, request_, urlBuilder_);

                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        var disposeResponse_ = true;
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = (int)response_.StatusCode;
                            if (status_ == 200)
                            {
                                var objectResponse_ = await ReadObjectResponseAsync<InitiateWithdrawalResponseApiResponseModel>(response_, headers_, cancellationToken).ConfigureAwait(false);
                                if (objectResponse_.Object == null)
                                {
                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                                }
                                return objectResponse_.Object;
                            }
                            else
                            if (status_ == 400)
                            {
                                var objectResponse_ = await ReadObjectResponseAsync<ApiResponseModel>(response_, headers_, cancellationToken).ConfigureAwait(false);
                                if (objectResponse_.Object == null)
                                {
                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                                }
                                throw new ApiException<ApiResponseModel>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                            }
                            else
                            if (status_ == 401)
                            {
                                var objectResponse_ = await ReadObjectResponseAsync<ProblemDetails>(response_, headers_, cancellationToken).ConfigureAwait(false);
                                if (objectResponse_.Object == null)
                                {
                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                                }
                                throw new ApiException<ProblemDetails>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                            }
                            else
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                            }
                        }
                        finally
                        {
                            if (disposeResponse_)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (disposeClient_)
                        client_.Dispose();
                }
            }

            /// <summary>
            /// Retrieves the status of an initiated withdrawal
            /// </summary>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            public virtual System.Threading.Tasks.Task<WithdrawalStatusResponseApiResponseModel> ClientWithdrawalStatusAsync(string merchantReference)
            {
                return ClientWithdrawalStatusAsync(merchantReference, System.Threading.CancellationToken.None);
            }

            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            /// <summary>
            /// Retrieves the status of an initiated withdrawal
            /// </summary>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            protected virtual async System.Threading.Tasks.Task<WithdrawalStatusResponseApiResponseModel> ClientWithdrawalStatusAsync(string merchantReference, System.Threading.CancellationToken cancellationToken)
            {
                if (merchantReference == null)
                    throw new System.ArgumentNullException("merchantReference");

                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/merchantClientWithdrawal/status/{merchantReference}?");
                urlBuilder_.Replace("{merchantReference}", System.Uri.EscapeDataString(ConvertToString(merchantReference, System.Globalization.CultureInfo.InvariantCulture)));
                urlBuilder_.Length--;

                var client_ = _httpClient;
                var disposeClient_ = false;
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain; ver=1.0"));

                        PrepareRequest(client_, request_, urlBuilder_);

                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        var disposeResponse_ = true;
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = (int)response_.StatusCode;
                            if (status_ == 200)
                            {
                                var objectResponse_ = await ReadObjectResponseAsync<WithdrawalStatusResponseApiResponseModel>(response_, headers_, cancellationToken).ConfigureAwait(false);
                                if (objectResponse_.Object == null)
                                {
                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                                }
                                return objectResponse_.Object;
                            }
                            else
                            if (status_ == 400)
                            {
                                var objectResponse_ = await ReadObjectResponseAsync<ApiResponseModel>(response_, headers_, cancellationToken).ConfigureAwait(false);
                                if (objectResponse_.Object == null)
                                {
                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                                }
                                throw new ApiException<ApiResponseModel>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                            }
                            else
                            if (status_ == 401)
                            {
                                var objectResponse_ = await ReadObjectResponseAsync<ProblemDetails>(response_, headers_, cancellationToken).ConfigureAwait(false);
                                if (objectResponse_.Object == null)
                                {
                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                                }
                                throw new ApiException<ProblemDetails>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                            }
                            else
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                            }
                        }
                        finally
                        {
                            if (disposeResponse_)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (disposeClient_)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            public virtual System.Threading.Tasks.Task<GenerateDepositAddressRespsoneApiResponseModel> GenerateWalletAddressAsync(GenerateAddressForPaymentPayload body)
            {
                return GenerateWalletAddressAsync(body, System.Threading.CancellationToken.None);
            }

            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            protected virtual async System.Threading.Tasks.Task<GenerateDepositAddressRespsoneApiResponseModel> GenerateWalletAddressAsync(GenerateAddressForPaymentPayload body, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/v1/walletAddress/generate?");
                urlBuilder_.Length--;

                var client_ = _httpClient;
                var disposeClient_ = false;
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                        var content_ = new System.Net.Http.StringContent(json_);
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json-patch+json; ver=1.0");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("POST");
                        request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain; ver=1.0"));

                        PrepareRequest(client_, request_, urlBuilder_);

                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        var disposeResponse_ = true;
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = (int)response_.StatusCode;
                            if (status_ == 200)
                            {
                                var objectResponse_ = await ReadObjectResponseAsync<GenerateDepositAddressRespsoneApiResponseModel>(response_, headers_, cancellationToken).ConfigureAwait(false);
                                if (objectResponse_.Object == null)
                                {
                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                                }
                                return objectResponse_.Object;
                            }
                            else
                            if (status_ == 400)
                            {
                                var objectResponse_ = await ReadObjectResponseAsync<ErrorDetailsApiResponseModel>(response_, headers_, cancellationToken).ConfigureAwait(false);
                                if (objectResponse_.Object == null)
                                {
                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                                }
                                throw new ApiException<ErrorDetailsApiResponseModel>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                            }
                            else
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                            }
                        }
                        finally
                        {
                            if (disposeResponse_)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (disposeClient_)
                        client_.Dispose();
                }
            }

            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            public virtual System.Threading.Tasks.Task<WalletBalanceApiResponseModel> OriginAccountBalanceAsync(string publicKey)
            {
                return OriginAccountsAsync(publicKey, System.Threading.CancellationToken.None);
            }

            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            protected virtual async System.Threading.Tasks.Task<WalletBalanceApiResponseModel> OriginAccountsAsync(string publicKey, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/v1/walletBalance/originAccounts?");
                if (publicKey != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("publicKey") + "=").Append(System.Uri.EscapeDataString(ConvertToString(publicKey, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                var client_ = _httpClient;
                var disposeClient_ = false;
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain; ver=1.0"));

                        PrepareRequest(client_, request_, urlBuilder_);

                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        var disposeResponse_ = true;
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = (int)response_.StatusCode;
                            if (status_ == 200)
                            {
                                var objectResponse_ = await ReadObjectResponseAsync<WalletBalanceApiResponseModel>(response_, headers_, cancellationToken).ConfigureAwait(false);
                                if (objectResponse_.Object == null)
                                {
                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                                }
                                return objectResponse_.Object;
                            }
                            else
                            if (status_ == 400)
                            {
                                var objectResponse_ = await ReadObjectResponseAsync<ApiResponseModel>(response_, headers_, cancellationToken).ConfigureAwait(false);
                                if (objectResponse_.Object == null)
                                {
                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                                }
                                throw new ApiException<ApiResponseModel>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                            }
                            else
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                            }
                        }
                        finally
                        {
                            if (disposeResponse_)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (disposeClient_)
                        client_.Dispose();
                }
            }


            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            /// <summary>
            /// Authenticates a user and generates an access token to be used in subsequent requests
            /// </summary>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>


            /// <summary>
            /// Support new network
            /// </summary>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            public virtual System.Threading.Tasks.Task<CreatedMerchantViewModelApiResponseModel> AddNetworkChainAsync(AddSupportedNetworkDto body)
            {
                return AddNetworkChainAsync(body, System.Threading.CancellationToken.None);
            }

            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            /// <summary>
            /// Support new network
            /// </summary>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            protected virtual async System.Threading.Tasks.Task<CreatedMerchantViewModelApiResponseModel> AddNetworkChainAsync(AddSupportedNetworkDto body, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/v2/merchant/add-network-chain?");
                urlBuilder_.Length--;

                var client_ = _httpClient;
                var disposeClient_ = false;
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value);
                        var content_ = new System.Net.Http.StringContent(json_);
                        content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json-patch+json; ver=2.0");
                        request_.Content = content_;
                        request_.Method = new System.Net.Http.HttpMethod("POST");
                        request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain; ver=2.0"));

                        PrepareRequest(client_, request_, urlBuilder_);

                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        var disposeResponse_ = true;
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = (int)response_.StatusCode;
                            if (status_ == 200)
                            {
                                var objectResponse_ = await ReadObjectResponseAsync<CreatedMerchantViewModelApiResponseModel>(response_, headers_, cancellationToken).ConfigureAwait(false);
                                if (objectResponse_.Object == null)
                                {
                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                                }
                                return objectResponse_.Object;
                            }
                            else
                            if (status_ == 400)
                            {
                                var objectResponse_ = await ReadObjectResponseAsync<ApiResponseModel>(response_, headers_, cancellationToken).ConfigureAwait(false);
                                if (objectResponse_.Object == null)
                                {
                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                                }
                                throw new ApiException<ApiResponseModel>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                            }
                            else
                            if (status_ == 401)
                            {
                                var objectResponse_ = await ReadObjectResponseAsync<ProblemDetails>(response_, headers_, cancellationToken).ConfigureAwait(false);
                                if (objectResponse_.Object == null)
                                {
                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                                }
                                throw new ApiException<ProblemDetails>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                            }
                            else
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                            }
                        }
                        finally
                        {
                            if (disposeResponse_)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (disposeClient_)
                        client_.Dispose();
                }
            }

            /// <param name="vmType">1 = EVM
            /// <br/>
            /// <br/>2 = TVM</param>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            public virtual System.Threading.Tasks.Task<VmCheckResponseApiResponseModel> CheckNetworkChainSupportAsync(NetworkType? vmType)
            {
                return CheckNetworkChainSupportAsync(vmType, System.Threading.CancellationToken.None);
            }

            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            /// <param name="vmType">1 = EVM
            /// <br/>
            /// <br/>2 = TVM</param>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            protected virtual async System.Threading.Tasks.Task<VmCheckResponseApiResponseModel> CheckNetworkChainSupportAsync(NetworkType? vmType, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/v2/merchant/check-network-chain-support?");
                if (vmType != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("vmType") + "=").Append(System.Uri.EscapeDataString(ConvertToString(vmType, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                var client_ = _httpClient;
                var disposeClient_ = false;
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain; ver=2.0"));

                        PrepareRequest(client_, request_, urlBuilder_);

                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        var disposeResponse_ = true;
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = (int)response_.StatusCode;
                            if (status_ == 200)
                            {
                                var objectResponse_ = await ReadObjectResponseAsync<VmCheckResponseApiResponseModel>(response_, headers_, cancellationToken).ConfigureAwait(false);
                                if (objectResponse_.Object == null)
                                {
                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                                }
                                return objectResponse_.Object;
                            }
                            else
                            if (status_ == 400)
                            {
                                var objectResponse_ = await ReadObjectResponseAsync<ApiResponseModel>(response_, headers_, cancellationToken).ConfigureAwait(false);
                                if (objectResponse_.Object == null)
                                {
                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                                }
                                throw new ApiException<ApiResponseModel>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                            }
                            else
                            if (status_ == 401)
                            {
                                var objectResponse_ = await ReadObjectResponseAsync<ProblemDetails>(response_, headers_, cancellationToken).ConfigureAwait(false);
                                if (objectResponse_.Object == null)
                                {
                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                                }
                                throw new ApiException<ProblemDetails>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                            }
                            else
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                            }
                        }
                        finally
                        {
                            if (disposeResponse_)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (disposeClient_)
                        client_.Dispose();
                }
            }

            /// <summary>
            /// Get Transaction Record
            /// </summary>
            /// <param name="currency">1 = BTC
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
            /// <br/>17 = TUSD</param>
            /// <param name="networkChain">1 = BSC
            /// <br/>
            /// <br/>2 = ETHEREUM
            /// <br/>
            /// <br/>3 = POLYGON
            /// <br/>
            /// <br/>4 = CELO
            /// <br/>
            /// <br/>5 = ARBITRUM
            /// <br/>
            /// <br/>6 = AVALANCHE
            /// <br/>
            /// <br/>7 = HecoChain
            /// <br/>
            /// <br/>8 = TRON</param>
            /// <param name="status">0 = Pending
            /// <br/>
            /// <br/>1 = Successful
            /// <br/>
            /// <br/>2 = Failed
            /// <br/>
            /// <br/>3 = Initiated</param>
            /// <param name="transactionType">1 = Deposit
            /// <br/>
            /// <br/>2 = Withdrawal</param>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            public virtual System.Threading.Tasks.Task<TransactionRecordResponse> GetTransactionRecordAsync(long? startTimeStamp = null, long? endTimeStamp = null, CurrencySymbol? currency = null, NetworkChain? networkChain = null, OperationStatus? status = null, string transactionHash = null, string walletAddress = null, TransactionType? transactionType = null, int? page = 1, int? pageSize = 30)
            {
                return TransactionRecordAsync(currency, networkChain, status, transactionHash, walletAddress, transactionType, page, pageSize, startTimeStamp, endTimeStamp, System.Threading.CancellationToken.None);
            }

            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            /// <summary>
            /// Get Transaction Record
            /// </summary>
            /// <param name="currency">1 = BTC
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
            /// <br/>17 = TUSD</param>
            /// <param name="networkChain">1 = BSC
            /// <br/>
            /// <br/>2 = ETHEREUM
            /// <br/>
            /// <br/>3 = POLYGON
            /// <br/>
            /// <br/>4 = CELO
            /// <br/>
            /// <br/>5 = ARBITRUM
            /// <br/>
            /// <br/>6 = AVALANCHE
            /// <br/>
            /// <br/>7 = HecoChain
            /// <br/>
            /// <br/>8 = TRON</param>
            /// <param name="status">0 = Pending
            /// <br/>
            /// <br/>1 = Successful
            /// <br/>
            /// <br/>2 = Failed
            /// <br/>
            /// <br/>3 = Initiated</param>
            /// <param name="transactionType">1 = Deposit
            /// <br/>
            /// <br/>2 = Withdrawal</param>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            protected virtual async System.Threading.Tasks.Task<TransactionRecordResponse> TransactionRecordAsync(CurrencySymbol? currency, NetworkChain? networkChain, OperationStatus? status, string transactionHash, string walletAddress, TransactionType? transactionType, int? page, int? pageSize, long? startTimeStamp, long? endTimeStamp, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/v2/analytics/transaction-record?");
                if (currency != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("Currency") + "=").Append(System.Uri.EscapeDataString(ConvertToString(currency, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (networkChain != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("NetworkChain") + "=").Append(System.Uri.EscapeDataString(ConvertToString(networkChain, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (status != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("Status") + "=").Append(System.Uri.EscapeDataString(ConvertToString(status, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (transactionHash != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("TransactionHash") + "=").Append(System.Uri.EscapeDataString(ConvertToString(transactionHash, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (walletAddress != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("WalletAddress") + "=").Append(System.Uri.EscapeDataString(ConvertToString(walletAddress, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (transactionType != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("TransactionType") + "=").Append(System.Uri.EscapeDataString(ConvertToString(transactionType, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (page != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("Page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (pageSize != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("PageSize") + "=").Append(System.Uri.EscapeDataString(ConvertToString(pageSize, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (startTimeStamp != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("StartTimeStamp") + "=").Append(System.Uri.EscapeDataString(ConvertToString(startTimeStamp, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (endTimeStamp != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("EndTimeStamp") + "=").Append(System.Uri.EscapeDataString(ConvertToString(endTimeStamp, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                var client_ = _httpClient;
                var disposeClient_ = false;
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                        PrepareRequest(client_, request_, urlBuilder_);

                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        var disposeResponse_ = true;
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = (int)response_.StatusCode;
                            if (status_ == 200)
                            {
                                var objectResponse_ = await ReadObjectResponseAsync<TransactionRecordResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                                if (objectResponse_.Object == null)
                                {
                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                                }
                                return objectResponse_.Object;
                            }
                            else
                            if (status_ == 400)
                            {
                                var objectResponse_ = await ReadObjectResponseAsync<ErrorDetails>(response_, headers_, cancellationToken).ConfigureAwait(false);
                                if (objectResponse_.Object == null)
                                {
                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                                }
                                throw new ApiException<ErrorDetails>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                            }
                            else
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                            }
                        }
                        finally
                        {
                            if (disposeResponse_)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (disposeClient_)
                        client_.Dispose();
                }
            }

            /// <summary>
            /// Get Timed Transaction Record,Defualted To Last 7 Days
            /// </summary>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            public virtual System.Threading.Tasks.Task<TransactionRecordResponse> GetTimedTransactionRecordAsync(int? page = 1, int? pageSize = 30, long? startTimeStamp = null, long? endTimeStamp = null)
            {
                return TimedTransactionRecordAsync(page, pageSize, startTimeStamp, endTimeStamp, System.Threading.CancellationToken.None);
            }

            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            /// <summary>
            /// Get Timed Transaction Record,Defualted To Last 7 Days
            /// </summary>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            protected virtual async System.Threading.Tasks.Task<TransactionRecordResponse> TimedTransactionRecordAsync(int? page, int? pageSize, long? startTimeStamp, long? endTimeStamp, System.Threading.CancellationToken cancellationToken)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/api/v2/analytics/timed-transaction-record?");
                if (page != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("Page") + "=").Append(System.Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (pageSize != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("PageSize") + "=").Append(System.Uri.EscapeDataString(ConvertToString(pageSize, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (startTimeStamp != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("StartTimeStamp") + "=").Append(System.Uri.EscapeDataString(ConvertToString(startTimeStamp, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (endTimeStamp != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("EndTimeStamp") + "=").Append(System.Uri.EscapeDataString(ConvertToString(endTimeStamp, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                var client_ = _httpClient;
                var disposeClient_ = false;
                try
                {
                    using (var request_ = new System.Net.Http.HttpRequestMessage())
                    {
                        request_.Method = new System.Net.Http.HttpMethod("GET");
                        request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                        PrepareRequest(client_, request_, urlBuilder_);

                        var url_ = urlBuilder_.ToString();
                        request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                        PrepareRequest(client_, request_, url_);

                        var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                        var disposeResponse_ = true;
                        try
                        {
                            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                            if (response_.Content != null && response_.Content.Headers != null)
                            {
                                foreach (var item_ in response_.Content.Headers)
                                    headers_[item_.Key] = item_.Value;
                            }

                            ProcessResponse(client_, response_);

                            var status_ = (int)response_.StatusCode;
                            if (status_ == 200)
                            {
                                var objectResponse_ = await ReadObjectResponseAsync<TransactionRecordResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                                if (objectResponse_.Object == null)
                                {
                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                                }
                                return objectResponse_.Object;
                            }
                            else
                            if (status_ == 400)
                            {
                                var objectResponse_ = await ReadObjectResponseAsync<ErrorDetails>(response_, headers_, cancellationToken).ConfigureAwait(false);
                                if (objectResponse_.Object == null)
                                {
                                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                                }
                                throw new ApiException<ErrorDetails>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
                            }
                            else
                            {
                                var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                                throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                            }
                        }
                        finally
                        {
                            if (disposeResponse_)
                                response_.Dispose();
                        }
                    }
                }
                finally
                {
                    if (disposeClient_)
                        client_.Dispose();
                }
            }
            protected struct ObjectResponseResult<T>
            {
                public ObjectResponseResult(T responseObject, string responseText)
                {
                    this.Object = responseObject;
                    this.Text = responseText;
                }

                public T Object { get; }

                public string Text { get; }
            }

            public bool ReadResponseAsString { get; set; }

            protected virtual async System.Threading.Tasks.Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(System.Net.Http.HttpResponseMessage response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Threading.CancellationToken cancellationToken)
            {
                if (response == null || response.Content == null)
                {
                    return new ObjectResponseResult<T>(default(T), string.Empty);
                }

                if (ReadResponseAsString)
                {
                    var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    try
                    {
                        var typedBody = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseText, JsonSerializerSettings);
                        return new ObjectResponseResult<T>(typedBody, responseText);
                    }
                    catch (Newtonsoft.Json.JsonException exception)
                    {
                        var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                        throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
                    }
                }
                else
                {
                    try
                    {
                        using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                        using (var streamReader = new System.IO.StreamReader(responseStream))
                        using (var jsonTextReader = new Newtonsoft.Json.JsonTextReader(streamReader))
                        {
                            var serializer = Newtonsoft.Json.JsonSerializer.Create(JsonSerializerSettings);
                            var typedBody = serializer.Deserialize<T>(jsonTextReader);
                            return new ObjectResponseResult<T>(typedBody, string.Empty);
                        }
                    }
                    catch (Newtonsoft.Json.JsonException exception)
                    {
                        var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                        throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
                    }
                }
            }

            private string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
            {
                if (value == null)
                {
                    return "";
                }

                if (value is System.Enum)
                {
                    var name = System.Enum.GetName(value.GetType(), value);
                    if (name != null)
                    {
                        var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                        if (field != null)
                        {
                            var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute))
                                as System.Runtime.Serialization.EnumMemberAttribute;
                            if (attribute != null)
                            {
                                return attribute.Value != null ? attribute.Value : name;
                            }
                        }

                        var converted = System.Convert.ToString(System.Convert.ChangeType(value, System.Enum.GetUnderlyingType(value.GetType()), cultureInfo));
                        return converted == null ? string.Empty : converted;
                    }
                }
                else if (value is bool)
                {
                    return System.Convert.ToString((bool)value, cultureInfo).ToLowerInvariant();
                }
                else if (value is byte[])
                {
                    return System.Convert.ToBase64String((byte[])value);
                }
                else if (value.GetType().IsArray)
                {
                    var array = System.Linq.Enumerable.OfType<object>((System.Array)value);
                    return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
                }

                var result = System.Convert.ToString(value, cultureInfo);
                return result == null ? "" : result;
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class APIResponse
        {
            [Newtonsoft.Json.JsonProperty("isSuccessful", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool IsSuccessful { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("statusCode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public HttpStatusCode StatusCode { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class AddNodeProviderRequest
        {
            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("nodeUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string NodeUrl { get; set; }

            [Newtonsoft.Json.JsonProperty("archiveNodeUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string ArchiveNodeUrl { get; set; }

            [Newtonsoft.Json.JsonProperty("blockchainNetworkId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid BlockchainNetworkId { get; set; }

        }

        /// <summary>
        /// 
        /// <br/>
        /// <br/>1 = ADDRESS_GENERATED
        /// <br/>
        /// <br/>2 = PENDING_ADDRESS_GENERATION
        /// <br/>
        /// <br/>3 = FAILED_ADDRESS_GENERATION
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public enum AddressGenerationStatus
        {

            _1 = 1,

            _2 = 2,

            _3 = 3,

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class AggregatedWalletBalanceData
        {
            [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Currency { get; set; }

            [Newtonsoft.Json.JsonProperty("network", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Network { get; set; }

            [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Amount { get; set; }

            [Newtonsoft.Json.JsonProperty("amountInUSD", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string AmountInUSD { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class AggregatedWalletBalancePayload
        {
            [Newtonsoft.Json.JsonProperty("balances", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<AggregatedWalletBalanceData> Balances { get; set; }

            [Newtonsoft.Json.JsonProperty("lockedBalances", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<AggregatedWalletBalanceData> LockedBalances { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class AggregatedWalletBalanceResponse
        {
            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public AggregatedWalletBalancePayload Data { get; set; }

            [Newtonsoft.Json.JsonProperty("isSuccessful", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool IsSuccessful { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("httpStatusCode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public HttpStatusCode HttpStatusCode { get; set; }

            [Newtonsoft.Json.JsonProperty("kyC_Status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public KYC_Status KyC_Status { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class BlockNotificationRecipientRequest
        {
            [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Email { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class BlockNotificationRecipientResponse
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Email { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class BlockNotificationRecipientResponseListApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<BlockNotificationRecipientResponse> Data { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class BooleanApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Data { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class CallBackUrls
        {
            [Newtonsoft.Json.JsonProperty("callbackWebHookUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string CallbackWebHookUrl { get; set; }

            [Newtonsoft.Json.JsonProperty("remittanceWebHookUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string RemittanceWebHookUrl { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class CreateUserRequest
        {
            [Newtonsoft.Json.JsonProperty("lastName", Required = Newtonsoft.Json.Required.Always)]
            [System.ComponentModel.DataAnnotations.Required]
            public string LastName { get; set; }

            [Newtonsoft.Json.JsonProperty("firstName", Required = Newtonsoft.Json.Required.Always)]
            [System.ComponentModel.DataAnnotations.Required]
            public string FirstName { get; set; }

            [Newtonsoft.Json.JsonProperty("emailAddress", Required = Newtonsoft.Json.Required.Always)]
            [System.ComponentModel.DataAnnotations.Required]
            public string EmailAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("phoneNumber", Required = Newtonsoft.Json.Required.Always)]
            [System.ComponentModel.DataAnnotations.Required]
            public string PhoneNumber { get; set; }

            [Newtonsoft.Json.JsonProperty("gender", Required = Newtonsoft.Json.Required.Always)]
            [System.ComponentModel.DataAnnotations.Required]
            public string Gender { get; set; }

            [Newtonsoft.Json.JsonProperty("password", Required = Newtonsoft.Json.Required.Always)]
            [System.ComponentModel.DataAnnotations.Required]
            public string Password { get; set; }

            [Newtonsoft.Json.JsonProperty("role", Required = Newtonsoft.Json.Required.Always)]
            [System.ComponentModel.DataAnnotations.Required]
            public string Role { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class CreatedMerchantViewModel
        {
            [Newtonsoft.Json.JsonProperty("merchant", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Merchant Merchant { get; set; }

            [Newtonsoft.Json.JsonProperty("merchantWallets", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.IDictionary<string, MerchantWallet> MerchantWallets { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class CreatedMerchantViewModelApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public CreatedMerchantViewModel Data { get; set; }

        }

        /// <summary>
        /// 
        /// <br/>
        /// <br/>1 = COIN
        /// <br/>
        /// <br/>2 = TOKEN
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public enum CryptoType
        {

            _1 = 1,

            _2 = 2,

        }
        public enum EnvironmentType
        {
            Sandbox = 1,
            Production = 2
        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Currency
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("symbol", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Symbol { get; set; }

            [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string NetworkChain { get; set; }

            [Newtonsoft.Json.JsonProperty("contractAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string ContractAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("cryptoType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public CryptoType CryptoType { get; set; }

            [Newtonsoft.Json.JsonProperty("requiredConfirmations", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int RequiredConfirmations { get; set; }

            [Newtonsoft.Json.JsonProperty("decimalUnits", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int DecimalUnits { get; set; }

            [Newtonsoft.Json.JsonProperty("addressValidityInMinutes", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double AddressValidityInMinutes { get; set; }

            [Newtonsoft.Json.JsonProperty("withrawalValidityInMinutes", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double WithrawalValidityInMinutes { get; set; }

            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public StatusEnum Status { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class CurrencyDto
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("symbol", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public CurrencySymbol Symbol { get; set; }

            [Newtonsoft.Json.JsonProperty("logoUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string LogoUrl { get; set; }

            [Newtonsoft.Json.JsonProperty("parentCurrencyId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? ParentCurrencyId { get; set; }

            [Newtonsoft.Json.JsonProperty("contractAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string ContractAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("cryptoType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public CryptoType CryptoType { get; set; }

            [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double Amount { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class CurrencyModel
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("symbol", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public CurrencySymbol Symbol { get; set; }

            [Newtonsoft.Json.JsonProperty("contractAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string ContractAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("cryptoType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public CryptoType CryptoType { get; set; }

            [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public NetworkChain NetworkChain { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class CurrencyModelIEnumerableApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<CurrencyModel> Data { get; set; }

        }

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
        public enum CurrencySymbol
        {

            BTC = 1,

            LTC = 2,

            BNB = 3,

            USDT = 4,

            DAI = 5,

            BUSD = 6,

            XEND = 7,

            ETH = 8,

            MATIC = 9,

            WNT = 10,

            USDC = 11,

            cUSD = 12,

            cEUR = 13,

            CELO = 14,

            TRX = 15,

            USDJ = 16,

            TUSD = 17,

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Deposit
        {
            [Newtonsoft.Json.JsonProperty("checksum", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Checksum { get; set; }

            [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Amount { get; set; }

            [Newtonsoft.Json.JsonProperty("charge", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Charge { get; set; }

            [Newtonsoft.Json.JsonProperty("totalAmountDeposited", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string TotalAmountDeposited { get; set; }

            [Newtonsoft.Json.JsonProperty("depositAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string DepositAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("receiveAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string ReceiveAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public CurrencySymbol Currency { get; set; }

            [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public NetworkChain NetworkChain { get; set; }

            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public TransactionStatus Status { get; set; }

            [Newtonsoft.Json.JsonProperty("merchantClient", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public MerchantClient MerchantClient { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionHash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string TransactionHash { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class DepositPaginatedResult
        {
            [Newtonsoft.Json.JsonProperty("records", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<Deposit> Records { get; set; }

            [Newtonsoft.Json.JsonProperty("pageSize", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int PageSize { get; set; }

            [Newtonsoft.Json.JsonProperty("currentPage", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int CurrentPage { get; set; }

            [Newtonsoft.Json.JsonProperty("totalPages", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int TotalPages { get; set; }

            [Newtonsoft.Json.JsonProperty("totalRecords", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int TotalRecords { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class DepositPaginatedResultApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public DepositPaginatedResult Data { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class DepositReceivedByMerchantResponse
        {
            [Newtonsoft.Json.JsonProperty("toAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string ToAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("fromAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string FromAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Status { get; set; }

            [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Currency { get; set; }

            [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string NetworkChain { get; set; }

            [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Amount { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionExplorerURL", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string TransactionExplorerURL { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionTimeStamp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public long TransactionTimeStamp { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class DepositReceivedByMerchantResponsePaginatedResult
        {
            [Newtonsoft.Json.JsonProperty("records", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<DepositReceivedByMerchantResponse> Records { get; set; }

            [Newtonsoft.Json.JsonProperty("pageSize", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int PageSize { get; set; }

            [Newtonsoft.Json.JsonProperty("currentPage", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int CurrentPage { get; set; }

            [Newtonsoft.Json.JsonProperty("totalPages", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int TotalPages { get; set; }

            [Newtonsoft.Json.JsonProperty("totalRecords", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int TotalRecords { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class DepositReceivedByMerchantResponsePaginatedResultAPIResponse
        {
            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public DepositReceivedByMerchantResponsePaginatedResult Data { get; set; }

            [Newtonsoft.Json.JsonProperty("isSuccessful", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool IsSuccessful { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("statusCode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public HttpStatusCode StatusCode { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class DepositRemittanceInitiatorRequest
        {
            [Newtonsoft.Json.JsonProperty("startDateTimeStamp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public long StartDateTimeStamp { get; set; }

            [Newtonsoft.Json.JsonProperty("endDateTimeStamp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public long EndDateTimeStamp { get; set; }

            [Newtonsoft.Json.JsonProperty("publicKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string PublicKey { get; set; }

        }

        /// <summary>
        /// 
        /// <br/>
        /// <br/>0 = CSV
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public enum DocumentFormat
        {

            _0 = 0,

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class EnableNodeProviderRequest
        {
            [Newtonsoft.Json.JsonProperty("nodeProviderId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid NodeProviderId { get; set; }

            [Newtonsoft.Json.JsonProperty("blockchainNetworkId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid BlockchainNetworkId { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class ErrorDetails
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public ResponseStatus Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public object Data { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class ErrorDetailsApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public ErrorDetails Data { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class GasPaymentResponse
        {
            [Newtonsoft.Json.JsonProperty("fee", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Fee { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionHash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string TransactionHash { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionExplorerURL", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string TransactionExplorerURL { get; set; }

            [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Currency { get; set; }

            [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string NetworkChain { get; set; }

            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Status { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class GasPaymentSummary
        {
            [Newtonsoft.Json.JsonProperty("currencies", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<CurrencyDto> Currencies { get; set; }

            [Newtonsoft.Json.JsonProperty("totalAMountSentAsGas", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double TotalAMountSentAsGas { get; set; }

            [Newtonsoft.Json.JsonProperty("totalNetworkTransactionFees", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double TotalNetworkTransactionFees { get; set; }

            [Newtonsoft.Json.JsonProperty("totalUniqueWalletAddresses", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string TotalUniqueWalletAddresses { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class GasPaymentTransaction
        {
            [Newtonsoft.Json.JsonProperty("business", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Business { get; set; }

            [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double Amount { get; set; }

            [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Currency { get; set; }

            [Newtonsoft.Json.JsonProperty("currencyLogoUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string CurrencyLogoUrl { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionHash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string TransactionHash { get; set; }

            [Newtonsoft.Json.JsonProperty("networkTransactionFee", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double NetworkTransactionFee { get; set; }

            [Newtonsoft.Json.JsonProperty("walletAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string WalletAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string TransactionStatus { get; set; }

            [Newtonsoft.Json.JsonProperty("linkToTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string LinkToTransaction { get; set; }

            [Newtonsoft.Json.JsonProperty("linkToAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string LinkToAddress { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class GasPaymentTransactionPaginatedResult
        {
            [Newtonsoft.Json.JsonProperty("records", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<GasPaymentTransaction> Records { get; set; }

            [Newtonsoft.Json.JsonProperty("pageSize", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int PageSize { get; set; }

            [Newtonsoft.Json.JsonProperty("currentPage", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int CurrentPage { get; set; }

            [Newtonsoft.Json.JsonProperty("totalPages", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int TotalPages { get; set; }

            [Newtonsoft.Json.JsonProperty("totalRecords", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int TotalRecords { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class GasPaymentTransactionPaginatedResultApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public GasPaymentTransactionPaginatedResult Data { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class GenerateAddressForPaymentPayload
        {
            [Newtonsoft.Json.JsonProperty("clientEmailAddress", Required = Newtonsoft.Json.Required.Always)]
            [System.ComponentModel.DataAnnotations.Required]
            public string ClientEmailAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Always)]
            public CurrencySymbol Currency { get; set; }

            [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public NetworkChain NetworkChain { get; set; }

            [Newtonsoft.Json.JsonProperty("publicKey", Required = Newtonsoft.Json.Required.Always)]
            [System.ComponentModel.DataAnnotations.Required]
            public string PublicKey { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class GenerateDepositAddressRespsone
        {
            [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Address { get; set; }

            [Newtonsoft.Json.JsonProperty("merchantClientId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid MerchantClientId { get; set; }

            [Newtonsoft.Json.JsonProperty("addressGenerationStatus", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public AddressGenerationStatus AddressGenerationStatus { get; set; }

            [Newtonsoft.Json.JsonProperty("addressGenerationMessage", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string AddressGenerationMessage { get; set; }

            [Newtonsoft.Json.JsonProperty("addressGenerationTransactionHash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string AddressGenerationTransactionHash { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class GenerateDepositAddressRespsoneApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public GenerateDepositAddressRespsone Data { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class GeneratePaymentAddressResponse
        {
            [Newtonsoft.Json.JsonProperty("addressValidityInMinutes", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double AddressValidityInMinutes { get; set; }

            [Newtonsoft.Json.JsonProperty("paymentAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string PaymentAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("paymentCurrency", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public CurrencySymbol PaymentCurrency { get; set; }

            [Newtonsoft.Json.JsonProperty("paymentAmount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double PaymentAmount { get; set; }

            [Newtonsoft.Json.JsonProperty("paymentDescription", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string PaymentDescription { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class GeneratePaymentAddressResponseApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public GeneratePaymentAddressResponse Data { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public enum HttpStatusCode
        {

            _100 = 100,

            _101 = 101,

            _102 = 102,

            _103 = 103,

            _200 = 200,

            _201 = 201,

            _202 = 202,

            _203 = 203,

            _204 = 204,

            _205 = 205,

            _206 = 206,

            _207 = 207,

            _208 = 208,

            _226 = 226,

            _300 = 300,

            _301 = 301,

            _302 = 302,

            _303 = 303,

            _304 = 304,

            _305 = 305,

            _306 = 306,

            _307 = 307,

            _308 = 308,

            _400 = 400,

            _401 = 401,

            _402 = 402,

            _403 = 403,

            _404 = 404,

            _405 = 405,

            _406 = 406,

            _407 = 407,

            _408 = 408,

            _409 = 409,

            _410 = 410,

            _411 = 411,

            _412 = 412,

            _413 = 413,

            _414 = 414,

            _415 = 415,

            _416 = 416,

            _417 = 417,

            _421 = 421,

            _422 = 422,

            _423 = 423,

            _424 = 424,

            _426 = 426,

            _428 = 428,

            _429 = 429,

            _431 = 431,

            _451 = 451,

            _500 = 500,

            _501 = 501,

            _502 = 502,

            _503 = 503,

            _504 = 504,

            _505 = 505,

            _506 = 506,

            _507 = 507,

            _508 = 508,

            _510 = 510,

            _511 = 511,

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class InitiateContactFormRequest
        {
            [Newtonsoft.Json.JsonProperty("subject", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Subject { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("senderAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string SenderAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class InitiateMerchantReportRequest
        {
            [Newtonsoft.Json.JsonProperty("exportEmail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string ExportEmail { get; set; }

            [Newtonsoft.Json.JsonProperty("currencySymbol", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public CurrencySymbol CurrencySymbol { get; set; }

            [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public NetworkChain NetworkChain { get; set; }

            [Newtonsoft.Json.JsonProperty("format", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public DocumentFormat Format { get; set; }

            [Newtonsoft.Json.JsonProperty("reportType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public MerchantReportType ReportType { get; set; }

            [Newtonsoft.Json.JsonProperty("startTimeStamp", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public long? StartTimeStamp { get; set; }

            [Newtonsoft.Json.JsonProperty("endTimeStamp", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public long? EndTimeStamp { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class InitiateMerchantReportResponse
        {
            [Newtonsoft.Json.JsonProperty("reportGenerationId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid ReportGenerationId { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class InitiateMerchantReportResponseAPIResponse
        {
            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public InitiateMerchantReportResponse Data { get; set; }

            [Newtonsoft.Json.JsonProperty("isSuccessful", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool IsSuccessful { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("statusCode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public HttpStatusCode StatusCode { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class InitiateWithdrawalPayload
        {
            [Newtonsoft.Json.JsonProperty("merchantClientEmailAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string MerchantClientEmailAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("destinationAddress", Required = Newtonsoft.Json.Required.Always)]
            [System.ComponentModel.DataAnnotations.Required]
            public string DestinationAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
            public double Amount { get; set; }

            [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Always)]
            public CurrencySymbol Currency { get; set; }

            [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public NetworkChain NetworkChain { get; set; }

            [Newtonsoft.Json.JsonProperty("merchantReference", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string MerchantReference { get; set; }

            [Newtonsoft.Json.JsonProperty("publicKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string PublicKey { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class InitiateWithdrawalResponse
        {
            [Newtonsoft.Json.JsonProperty("destinationAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string DestinationAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("paymentCurrency", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public CurrencySymbol PaymentCurrency { get; set; }

            [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public NetworkChain NetworkChain { get; set; }

            [Newtonsoft.Json.JsonProperty("withdrawnAmount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double WithdrawnAmount { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionCharge", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double TransactionCharge { get; set; }

            [Newtonsoft.Json.JsonProperty("withdrawnAmountRequested", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double WithdrawnAmountRequested { get; set; }

            [Newtonsoft.Json.JsonProperty("paymentDescription", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string PaymentDescription { get; set; }

            [Newtonsoft.Json.JsonProperty("merchantTransactionReference", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string MerchantTransactionReference { get; set; }

            [Newtonsoft.Json.JsonProperty("switchWalletTransactionReference", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string SwitchWalletTransactionReference { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionChargeCurrency", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public CurrencySymbol TransactionChargeCurrency { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class InitiateWithdrawalResponseApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public InitiateWithdrawalResponse Data { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class InitiatedReportByMerchantResponse
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Status { get; set; }

            [Newtonsoft.Json.JsonProperty("emailExportedTo", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string EmailExportedTo { get; set; }

            [Newtonsoft.Json.JsonProperty("reportType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string ReportType { get; set; }

            [Newtonsoft.Json.JsonProperty("format", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Format { get; set; }

            [Newtonsoft.Json.JsonProperty("failureReason", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string FailureReason { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionTimeStamp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public long TransactionTimeStamp { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class InitiatedReportByMerchantResponsePaginatedResult
        {
            [Newtonsoft.Json.JsonProperty("records", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<InitiatedReportByMerchantResponse> Records { get; set; }

            [Newtonsoft.Json.JsonProperty("pageSize", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int PageSize { get; set; }

            [Newtonsoft.Json.JsonProperty("currentPage", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int CurrentPage { get; set; }

            [Newtonsoft.Json.JsonProperty("totalPages", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int TotalPages { get; set; }

            [Newtonsoft.Json.JsonProperty("totalRecords", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int TotalRecords { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class InitiatedReportByMerchantResponsePaginatedResultAPIResponse
        {
            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public InitiatedReportByMerchantResponsePaginatedResult Data { get; set; }

            [Newtonsoft.Json.JsonProperty("isSuccessful", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool IsSuccessful { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("statusCode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public HttpStatusCode StatusCode { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Jwt
        {
            [Newtonsoft.Json.JsonProperty("accessToken", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string AccessToken { get; set; }

            [Newtonsoft.Json.JsonProperty("issued", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset Issued { get; set; }

            [Newtonsoft.Json.JsonProperty("expires", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset Expires { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class JwtApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Jwt Data { get; set; }

        }

        /// <summary>
        /// 
        /// <br/>
        /// <br/>1 = UnVerified
        /// <br/>
        /// <br/>2 = Initiated
        /// <br/>
        /// <br/>3 = InProgess
        /// <br/>
        /// <br/>4 = Approved
        /// <br/>
        /// <br/>5 = Rejected
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public enum KYC_Status
        {

            _1 = 1,

            _2 = 2,

            _3 = 3,

            _4 = 4,

            _5 = 5,

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class LoginModel
        {
            [Newtonsoft.Json.JsonProperty("emailAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string EmailAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("password", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Password { get; set; }

            [Newtonsoft.Json.JsonProperty("passcode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Passcode { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Merchant
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("merchantBusinessType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int MerchantBusinessType { get; set; }

            [Newtonsoft.Json.JsonProperty("secretKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string SecretKey { get; set; }

            [Newtonsoft.Json.JsonProperty("publicKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string PublicKey { get; set; }

            [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid UserId { get; set; }

            [Newtonsoft.Json.JsonProperty("businessName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BusinessName { get; set; }

            [Newtonsoft.Json.JsonProperty("businessPhoneNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BusinessPhoneNumber { get; set; }

            [Newtonsoft.Json.JsonProperty("businessEmail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BusinessEmail { get; set; }

            [Newtonsoft.Json.JsonProperty("businessAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BusinessAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("businessSupportEmail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BusinessSupportEmail { get; set; }

            [Newtonsoft.Json.JsonProperty("businessSupportPhone", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BusinessSupportPhone { get; set; }

            [Newtonsoft.Json.JsonProperty("country", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Country { get; set; }

            [Newtonsoft.Json.JsonProperty("businessLogoURL", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BusinessLogoURL { get; set; }

            [Newtonsoft.Json.JsonProperty("businessDocumentUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BusinessDocumentUrl { get; set; }

            [Newtonsoft.Json.JsonProperty("bankName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BankName { get; set; }

            [Newtonsoft.Json.JsonProperty("bankAccountNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BankAccountNumber { get; set; }

            [Newtonsoft.Json.JsonProperty("pendingWebHookURL", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string PendingWebHookURL { get; set; }

            [Newtonsoft.Json.JsonProperty("confirmedWebHookURL", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string ConfirmedWebHookURL { get; set; }

            [Newtonsoft.Json.JsonProperty("secretHash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string SecretHash { get; set; }

            [Newtonsoft.Json.JsonProperty("withdrawalCostScheme", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public WithdrawalCostEnum WithdrawalCostScheme { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class MerchantClient
        {
            [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Email { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class MerchantClientBalanceResponse
        {
            [Newtonsoft.Json.JsonProperty("balance", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double Balance { get; set; }

            [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public CurrencySymbol Currency { get; set; }

            [Newtonsoft.Json.JsonProperty("walletAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string WalletAddress { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class MerchantDTO
        {
            [Newtonsoft.Json.JsonProperty("merchantBusinessType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int MerchantBusinessType { get; set; }

            [Newtonsoft.Json.JsonProperty("secretKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string SecretKey { get; set; }

            [Newtonsoft.Json.JsonProperty("publicKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string PublicKey { get; set; }

            [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid UserId { get; set; }

            [Newtonsoft.Json.JsonProperty("businessName", Required = Newtonsoft.Json.Required.Always)]
            [System.ComponentModel.DataAnnotations.Required]
            public string BusinessName { get; set; }

            [Newtonsoft.Json.JsonProperty("businessPhoneNumber", Required = Newtonsoft.Json.Required.Always)]
            [System.ComponentModel.DataAnnotations.Required]
            public string BusinessPhoneNumber { get; set; }

            [Newtonsoft.Json.JsonProperty("businessEmail", Required = Newtonsoft.Json.Required.Always)]
            [System.ComponentModel.DataAnnotations.Required]
            public string BusinessEmail { get; set; }

            [Newtonsoft.Json.JsonProperty("businessAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BusinessAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("businessSupportEmail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BusinessSupportEmail { get; set; }

            [Newtonsoft.Json.JsonProperty("businessSupportPhone", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BusinessSupportPhone { get; set; }

            [Newtonsoft.Json.JsonProperty("country", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Country { get; set; }

            [Newtonsoft.Json.JsonProperty("businessLogoURL", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BusinessLogoURL { get; set; }

            [Newtonsoft.Json.JsonProperty("businessDocumentUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BusinessDocumentUrl { get; set; }

            [Newtonsoft.Json.JsonProperty("bankName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BankName { get; set; }

            [Newtonsoft.Json.JsonProperty("bankAccountNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BankAccountNumber { get; set; }

            [Newtonsoft.Json.JsonProperty("firstName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string FirstName { get; set; }

            [Newtonsoft.Json.JsonProperty("lastName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string LastName { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class MerchantDTOWithAuthCredentials
        {
            [Newtonsoft.Json.JsonProperty("merchantDTO", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public MerchantDTO MerchantDTO { get; set; }

            [Newtonsoft.Json.JsonProperty("userDTO", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public UserDTO UserDTO { get; set; }

            [Newtonsoft.Json.JsonProperty("password", Required = Newtonsoft.Json.Required.Always)]
            [System.ComponentModel.DataAnnotations.Required]
            public string Password { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class MerchantDepositPayload
        {
            [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Always)]
            public CurrencySymbol Currency { get; set; }

            [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.Always)]
            public NetworkChain NetworkChain { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class MerchantDetails
        {
            [Newtonsoft.Json.JsonProperty("firstName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string FirstName { get; set; }

            [Newtonsoft.Json.JsonProperty("lastName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string LastName { get; set; }

            [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Email { get; set; }

            [Newtonsoft.Json.JsonProperty("phoneNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string PhoneNumber { get; set; }

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("merchantBusinessType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int MerchantBusinessType { get; set; }

            [Newtonsoft.Json.JsonProperty("secretKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string SecretKey { get; set; }

            [Newtonsoft.Json.JsonProperty("publicKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string PublicKey { get; set; }

            [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid UserId { get; set; }

            [Newtonsoft.Json.JsonProperty("businessName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BusinessName { get; set; }

            [Newtonsoft.Json.JsonProperty("businessPhoneNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BusinessPhoneNumber { get; set; }

            [Newtonsoft.Json.JsonProperty("businessEmail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BusinessEmail { get; set; }

            [Newtonsoft.Json.JsonProperty("businessAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BusinessAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("businessSupportEmail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BusinessSupportEmail { get; set; }

            [Newtonsoft.Json.JsonProperty("businessSupportPhone", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BusinessSupportPhone { get; set; }

            [Newtonsoft.Json.JsonProperty("country", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Country { get; set; }

            [Newtonsoft.Json.JsonProperty("businessLogoURL", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BusinessLogoURL { get; set; }

            [Newtonsoft.Json.JsonProperty("businessDocumentUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BusinessDocumentUrl { get; set; }

            [Newtonsoft.Json.JsonProperty("bankName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BankName { get; set; }

            [Newtonsoft.Json.JsonProperty("bankAccountNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BankAccountNumber { get; set; }

            [Newtonsoft.Json.JsonProperty("pendingWebHookURL", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string PendingWebHookURL { get; set; }

            [Newtonsoft.Json.JsonProperty("confirmedWebHookURL", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string ConfirmedWebHookURL { get; set; }

            [Newtonsoft.Json.JsonProperty("secretHash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string SecretHash { get; set; }

            [Newtonsoft.Json.JsonProperty("withdrawalCostScheme", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public WithdrawalCostEnum WithdrawalCostScheme { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class MerchantDetailsApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public MerchantDetails Data { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class MerchantIEnumerableApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<Merchant> Data { get; set; }

        }

        /// <summary>
        /// 
        /// <br/>
        /// <br/>0 = Remittance
        /// <br/>
        /// <br/>1 = DepositReceived
        /// <br/>
        /// <br/>2 = Withdrawal
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public enum MerchantReportType
        {

            _0 = 0,

            _1 = 1,

            _2 = 2,

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class MerchantWallet
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("creationDate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset CreationDate { get; set; }

            [Newtonsoft.Json.JsonProperty("merchantId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid MerchantId { get; set; }

            [Newtonsoft.Json.JsonProperty("addressFormat", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int AddressFormat { get; set; }

            [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Currency Currency { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class MerchantWithdrawalPayload
        {
            [Newtonsoft.Json.JsonProperty("destinationAddress", Required = Newtonsoft.Json.Required.Always)]
            [System.ComponentModel.DataAnnotations.Required]
            public string DestinationAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
            public double Amount { get; set; }

            [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Always)]
            public CurrencySymbol Currency { get; set; }

            [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public NetworkChain NetworkChain { get; set; }

        }

        /// <summary>
        /// 
        /// <br/>
        /// <br/>1 = BSC
        /// <br/>
        /// <br/>2 = ETHEREUM
        /// <br/>
        /// <br/>3 = POLYGON
        /// <br/>
        /// <br/>4 = CELO
        /// <br/>
        /// <br/>5 = ARBITRUM
        /// <br/>
        /// <br/>6 = AVALANCHE
        /// <br/>
        /// <br/>7 = HecoChain
        /// <br/>
        /// <br/>8 = TRON
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public enum NetworkChain
        {

            BSC = 1,

            ETHEREUM = 2,

            POLYGON = 3,

            CELO = 4,

            ARBITRUM = 5,

            AVALANCHE = 6,

            HecoChain = 7,

            TRON = 8,

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class NetworkChargeEstimate
        {
            [Newtonsoft.Json.JsonProperty("networkTransactionFee", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double NetworkTransactionFee { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class NetworkChargeEstimateApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public NetworkChargeEstimate Data { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class NetworkModel
        {
            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public NetworkChain NetworkChain { get; set; }

            [Newtonsoft.Json.JsonProperty("vmType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public NetworkType VmType { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class NetworkModelIEnumerableApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<NetworkModel> Data { get; set; }

        }

        /// <summary>
        /// 
        /// <br/>
        /// <br/>1 = EVM
        /// <br/>
        /// <br/>2 = TVM
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public enum NetworkType
        {

            _1 = 1,

            _2 = 2,

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class NodeProviderResponse
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("blockchainNetworkId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid BlockchainNetworkId { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("nodeUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string NodeUrl { get; set; }

            [Newtonsoft.Json.JsonProperty("archiveNodeUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string ArchiveNodeUrl { get; set; }

            [Newtonsoft.Json.JsonProperty("enabled", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Enabled { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class NodeProviderResponseApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public NodeProviderResponse Data { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class NodeProviderResponseListApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<NodeProviderResponse> Data { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class ObjectApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public object Data { get; set; }

        }

        /// <summary>
        /// 
        /// <br/>
        /// <br/>0 = Pending
        /// <br/>
        /// <br/>1 = Successful
        /// <br/>
        /// <br/>2 = Failed
        /// <br/>
        /// <br/>3 = Initiated
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public enum OperationStatus
        {

            Pending = 0,

            Successful = 1,

            Failed = 2,

            Initiated = 3,

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class ProblemDetails
        {
            [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Type { get; set; }

            [Newtonsoft.Json.JsonProperty("title", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Title { get; set; }

            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? Status { get; set; }

            [Newtonsoft.Json.JsonProperty("detail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Detail { get; set; }

            [Newtonsoft.Json.JsonProperty("instance", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Instance { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class RemittanceByMerchantResponse
        {
            [Newtonsoft.Json.JsonProperty("reference", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Reference { get; set; }

            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Status { get; set; }

            [Newtonsoft.Json.JsonProperty("failureReason", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string FailureReason { get; set; }

            [Newtonsoft.Json.JsonProperty("toAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string ToAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("fromAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string FromAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("toAddressUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string ToAddressUrl { get; set; }

            [Newtonsoft.Json.JsonProperty("fromAddressUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string FromAddressUrl { get; set; }

            [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Currency Currency { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionTimeStamp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public long TransactionTimeStamp { get; set; }

            [Newtonsoft.Json.JsonProperty("gasPayment", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public GasPaymentResponse GasPayment { get; set; }

            [Newtonsoft.Json.JsonProperty("remittancePayment", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public RemittancePaymentResponse RemittancePayment { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class RemittanceByMerchantResponsePaginatedResult
        {
            [Newtonsoft.Json.JsonProperty("records", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<RemittanceByMerchantResponse> Records { get; set; }

            [Newtonsoft.Json.JsonProperty("pageSize", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int PageSize { get; set; }

            [Newtonsoft.Json.JsonProperty("currentPage", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int CurrentPage { get; set; }

            [Newtonsoft.Json.JsonProperty("totalPages", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int TotalPages { get; set; }

            [Newtonsoft.Json.JsonProperty("totalRecords", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int TotalRecords { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class RemittanceByMerchantResponsePaginatedResultAPIResponse
        {
            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public RemittanceByMerchantResponsePaginatedResult Data { get; set; }

            [Newtonsoft.Json.JsonProperty("isSuccessful", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool IsSuccessful { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("statusCode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public HttpStatusCode StatusCode { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class RemittancePaymentResponse
        {
            [Newtonsoft.Json.JsonProperty("fee", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Fee { get; set; }

            [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Amount { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionHash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string TransactionHash { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionExplorerURL", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string TransactionExplorerURL { get; set; }

            [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Currency { get; set; }

            [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string NetworkChain { get; set; }

            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Status { get; set; }

            [Newtonsoft.Json.JsonProperty("destinationAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string DestinationAddress { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class RemittanceRequest
        {
            [Newtonsoft.Json.JsonProperty("walletAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string WalletAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("uniqueReference", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string UniqueReference { get; set; }

            [Newtonsoft.Json.JsonProperty("publicKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string PublicKey { get; set; }

            [Newtonsoft.Json.JsonProperty("currencySymbol", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public CurrencySymbol CurrencySymbol { get; set; }

            [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public NetworkChain NetworkChain { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class RemittanceRequestResponseModel
        {
            [Newtonsoft.Json.JsonProperty("currencyId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid CurrencyId { get; set; }

            [Newtonsoft.Json.JsonProperty("merchantId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid MerchantId { get; set; }

            [Newtonsoft.Json.JsonProperty("walletAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string WalletAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("uniqueReference", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string UniqueReference { get; set; }

            [Newtonsoft.Json.JsonProperty("gasPaymentTransactionHash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string GasPaymentTransactionHash { get; set; }

            [Newtonsoft.Json.JsonProperty("remittancePaymentTransactionHash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string RemittancePaymentTransactionHash { get; set; }

            [Newtonsoft.Json.JsonProperty("propagationStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string PropagationStatus { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class RemittanceRequestResponseModelApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public RemittanceRequestResponseModel Data { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class RemittanceSummaryResponse
        {
            [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<CurrencyDto> Currency { get; set; }

            [Newtonsoft.Json.JsonProperty("totalNumberOfTransaction", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public long TotalNumberOfTransaction { get; set; }

            [Newtonsoft.Json.JsonProperty("totalAmount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double TotalAmount { get; set; }

            [Newtonsoft.Json.JsonProperty("totalNetworkFees", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double TotalNetworkFees { get; set; }

            [Newtonsoft.Json.JsonProperty("totalNumberOfNetworkFees", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double TotalNumberOfNetworkFees { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class RemittanceTransaction
        {
            [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double Amount { get; set; }

            [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Currency { get; set; }

            [Newtonsoft.Json.JsonProperty("currencyLogoUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string CurrencyLogoUrl { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionHash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string TransactionHash { get; set; }

            [Newtonsoft.Json.JsonProperty("networkTransactionFee", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double NetworkTransactionFee { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string TransactionStatus { get; set; }

            [Newtonsoft.Json.JsonProperty("destinationAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string DestinationAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("sourceWallet", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string SourceWallet { get; set; }

            [Newtonsoft.Json.JsonProperty("business", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Business { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class RemittanceTransactionPaginatedResult
        {
            [Newtonsoft.Json.JsonProperty("records", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<RemittanceTransaction> Records { get; set; }

            [Newtonsoft.Json.JsonProperty("pageSize", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int PageSize { get; set; }

            [Newtonsoft.Json.JsonProperty("currentPage", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int CurrentPage { get; set; }

            [Newtonsoft.Json.JsonProperty("totalPages", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int TotalPages { get; set; }

            [Newtonsoft.Json.JsonProperty("totalRecords", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int TotalRecords { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class RemittanceTransactionPaginatedResultApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public RemittanceTransactionPaginatedResult Data { get; set; }

        }

        /// <summary>
        /// 
        /// <br/>
        /// <br/>1 = OK
        /// <br/>
        /// <br/>2 = APP_ERROR
        /// <br/>
        /// <br/>3 = FATAL_ERROR
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public enum ResponseStatus
        {

            _1 = 1,

            _2 = 2,

            _3 = 3,

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class RoleManagementRequest
        {
            [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Email { get; set; }

            [Newtonsoft.Json.JsonProperty("role", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Role { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class SetWithdrawalFeeSchemeRequest
        {
            [Newtonsoft.Json.JsonProperty("withdrawalCost", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public WithdrawalCostEnum WithdrawalCost { get; set; }

        }

        /// <summary>
        /// 
        /// <br/>
        /// <br/>1 = ACTIVE
        /// <br/>
        /// <br/>2 = INACTIVE
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public enum StatusEnum
        {

            _1 = 1,

            _2 = 2,

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class ApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Data { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class StringMerchantClientBalanceResponseDictionaryApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.IDictionary<string, MerchantClientBalanceResponse> Data { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class WalletBalanceApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<WalletBalance> Data { get; set; }
        }

        /// <summary>
        /// 
        /// <br/>
        /// <br/>1 = ABOUT_TO_INITIATE
        /// <br/>
        /// <br/>2 = PENDING
        /// <br/>
        /// <br/>3 = CONFIRMED
        /// <br/>
        /// <br/>4 = FAILED
        /// <br/>
        /// <br/>5 = NOT_PROPAGATED
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public enum TransactionStatus
        {

            _1 = 1,

            _2 = 2,

            _3 = 3,

            _4 = 4,

            _5 = 5,

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class UpdateMerchantWebhookUrlRequest
        {
            [Newtonsoft.Json.JsonProperty("webHookUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string WebHookUrl { get; set; }

            [Newtonsoft.Json.JsonProperty("publicKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string PublicKey { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class UserDTO
        {
            [Newtonsoft.Json.JsonProperty("lastName", Required = Newtonsoft.Json.Required.Always)]
            [System.ComponentModel.DataAnnotations.Required]
            public string LastName { get; set; }

            [Newtonsoft.Json.JsonProperty("firstName", Required = Newtonsoft.Json.Required.Always)]
            [System.ComponentModel.DataAnnotations.Required]
            public string FirstName { get; set; }

            [Newtonsoft.Json.JsonProperty("dateOfBirth", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? DateOfBirth { get; set; }

            [Newtonsoft.Json.JsonProperty("imageURL", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string ImageURL { get; set; }

            [Newtonsoft.Json.JsonProperty("emailAddress", Required = Newtonsoft.Json.Required.Always)]
            [System.ComponentModel.DataAnnotations.Required]
            public string EmailAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("phoneNumber", Required = Newtonsoft.Json.Required.Always)]
            [System.ComponentModel.DataAnnotations.Required]
            public string PhoneNumber { get; set; }

            [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Address { get; set; }

            [Newtonsoft.Json.JsonProperty("gender", Required = Newtonsoft.Json.Required.Always)]
            [System.ComponentModel.DataAnnotations.Required]
            public string Gender { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class WalletBalance
        {
            [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Currency { get; set; }

            [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string NetworkChain { get; set; }

            [Newtonsoft.Json.JsonProperty("balance", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double Balance { get; set; }
        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class WalletBalanceDetail
        {
            [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Currency { get; set; }

            [Newtonsoft.Json.JsonProperty("currencyLogoUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string CurrencyLogoUrl { get; set; }

            [Newtonsoft.Json.JsonProperty("lastUpdateDate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset LastUpdateDate { get; set; }

            [Newtonsoft.Json.JsonProperty("lastUpdateTimeStamp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public long LastUpdateTimeStamp { get; set; }

            [Newtonsoft.Json.JsonProperty("balance", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double Balance { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class WalletBalanceResonse
        {
            [Newtonsoft.Json.JsonProperty("currencyPoolId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid CurrencyPoolId { get; set; }

            [Newtonsoft.Json.JsonProperty("walletAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string WalletAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("walletBalances", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<WalletBalanceDetail> WalletBalances { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class WalletBalanceResonsePaginatedResult
        {
            [Newtonsoft.Json.JsonProperty("records", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<WalletBalanceResonse> Records { get; set; }

            [Newtonsoft.Json.JsonProperty("pageSize", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int PageSize { get; set; }

            [Newtonsoft.Json.JsonProperty("currentPage", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int CurrentPage { get; set; }

            [Newtonsoft.Json.JsonProperty("totalPages", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int TotalPages { get; set; }

            [Newtonsoft.Json.JsonProperty("totalRecords", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int TotalRecords { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class WalletBalanceResonsePaginatedResultApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public WalletBalanceResonsePaginatedResult Data { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Withdrawal
        {
            [Newtonsoft.Json.JsonProperty("checksum", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Checksum { get; set; }

            [Newtonsoft.Json.JsonProperty("receiverAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string ReceiverAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("amountRequested", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string AmountRequested { get; set; }

            [Newtonsoft.Json.JsonProperty("amountSent", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string AmountSent { get; set; }

            [Newtonsoft.Json.JsonProperty("charge", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Charge { get; set; }

            [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public CurrencySymbol Currency { get; set; }

            [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public NetworkChain NetworkChain { get; set; }

            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public TransactionStatus Status { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionHash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string TransactionHash { get; set; }

            [Newtonsoft.Json.JsonProperty("merchantReference", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string MerchantReference { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class WithdrawalByMerchantResponse
        {
            [Newtonsoft.Json.JsonProperty("fee", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Fee { get; set; }

            [Newtonsoft.Json.JsonProperty("toAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string ToAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Status { get; set; }

            [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Currency { get; set; }

            [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string NetworkChain { get; set; }

            [Newtonsoft.Json.JsonProperty("amountRequested", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string AmountRequested { get; set; }

            [Newtonsoft.Json.JsonProperty("amountWithdrawn", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string AmountWithdrawn { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionExplorerURL", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string TransactionExplorerURL { get; set; }

            [Newtonsoft.Json.JsonProperty("failureReason", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string FailureReason { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionTimeStamp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public long TransactionTimeStamp { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class WithdrawalByMerchantResponseAPIResponse
        {
            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public WithdrawalByMerchantResponse Data { get; set; }

            [Newtonsoft.Json.JsonProperty("isSuccessful", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool IsSuccessful { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("statusCode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public HttpStatusCode StatusCode { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class WithdrawalByMerchantResponseAPIResponsePaginatedResult
        {
            [Newtonsoft.Json.JsonProperty("records", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<WithdrawalByMerchantResponseAPIResponse> Records { get; set; }

            [Newtonsoft.Json.JsonProperty("pageSize", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int PageSize { get; set; }

            [Newtonsoft.Json.JsonProperty("currentPage", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int CurrentPage { get; set; }

            [Newtonsoft.Json.JsonProperty("totalPages", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int TotalPages { get; set; }

            [Newtonsoft.Json.JsonProperty("totalRecords", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int TotalRecords { get; set; }

        }

        /// <summary>
        /// 
        /// <br/>
        /// <br/>1 = MerchantBearsCost
        /// <br/>
        /// <br/>2 = ClientBearsCost
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public enum WithdrawalCostEnum
        {

            _1 = 1,

            _2 = 2,

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class WithdrawalPaginatedResult
        {
            [Newtonsoft.Json.JsonProperty("records", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<Withdrawal> Records { get; set; }

            [Newtonsoft.Json.JsonProperty("pageSize", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int PageSize { get; set; }

            [Newtonsoft.Json.JsonProperty("currentPage", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int CurrentPage { get; set; }

            [Newtonsoft.Json.JsonProperty("totalPages", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int TotalPages { get; set; }

            [Newtonsoft.Json.JsonProperty("totalRecords", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int TotalRecords { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class WithdrawalPaginatedResultApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public WithdrawalPaginatedResult Data { get; set; }

        }

        /// <summary>
        /// 
        /// <br/>
        /// <br/>1 = NotFound
        /// <br/>
        /// <br/>2 = Pending
        /// <br/>
        /// <br/>3 = Completed
        /// <br/>
        /// <br/>4 = Failed
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public enum WithdrawalStatus
        {

            _1 = 1,

            _2 = 2,

            _3 = 3,

            _4 = 4,

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class WithdrawalStatusCheck
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public TransactionStatus Status { get; set; }

            [Newtonsoft.Json.JsonProperty("swithcWalletTransactionReference", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string SwithcWalletTransactionReference { get; set; }

            [Newtonsoft.Json.JsonProperty("merchantReference", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string MerchantReference { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionHash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string TransactionHash { get; set; }

            [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double Amount { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionCharge", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double TransactionCharge { get; set; }

            [Newtonsoft.Json.JsonProperty("currencySymbol", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public CurrencySymbol CurrencySymbol { get; set; }

            [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public NetworkChain NetworkChain { get; set; }

            [Newtonsoft.Json.JsonProperty("destinationAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string DestinationAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("failureReason", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string FailureReason { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionDate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset TransactionDate { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class WithdrawalStatusCheckApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public WithdrawalStatusCheck Data { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class WithdrawalStatusResponse
        {
            [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double Amount { get; set; }

            [Newtonsoft.Json.JsonProperty("destinationAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string DestinationAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionHash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string TransactionHash { get; set; }

            [Newtonsoft.Json.JsonProperty("merchantReference", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string MerchantReference { get; set; }

            [Newtonsoft.Json.JsonProperty("withdrawalStatus", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public WithdrawalStatus WithdrawalStatus { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class WithdrawalStatusResponseApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public WithdrawalStatusResponse Data { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class WithdrawalTransaction
        {
            [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Currency { get; set; }

            [Newtonsoft.Json.JsonProperty("currencyLogoUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string CurrencyLogoUrl { get; set; }

            [Newtonsoft.Json.JsonProperty("to", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string To { get; set; }

            [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double Amount { get; set; }

            [Newtonsoft.Json.JsonProperty("requestedWithdrawalAmount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double RequestedWithdrawalAmount { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionCharge", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double TransactionCharge { get; set; }

            [Newtonsoft.Json.JsonProperty("hasHookMessageBeenSent", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool HasHookMessageBeenSent { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionHash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string TransactionHash { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionTimeStamp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public long TransactionTimeStamp { get; set; }

            [Newtonsoft.Json.JsonProperty("merchantReference", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string MerchantReference { get; set; }

            [Newtonsoft.Json.JsonProperty("switchWalletReference", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string SwitchWalletReference { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class WithdrawalTransactionPaginatedResult
        {
            [Newtonsoft.Json.JsonProperty("records", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<WithdrawalTransaction> Records { get; set; }

            [Newtonsoft.Json.JsonProperty("pageSize", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int PageSize { get; set; }

            [Newtonsoft.Json.JsonProperty("currentPage", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int CurrentPage { get; set; }

            [Newtonsoft.Json.JsonProperty("totalPages", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int TotalPages { get; set; }

            [Newtonsoft.Json.JsonProperty("totalRecords", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int TotalRecords { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class WithdrawalTransactionPaginatedResultApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public WithdrawalTransactionPaginatedResult Data { get; set; }

        }



        [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class ApiException : System.Exception
        {
            public int StatusCode { get; private set; }

            public string Response { get; private set; }

            public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

            public ApiException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException)
                : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + ((response == null) ? "(null)" : response.Substring(0, response.Length >= 512 ? 512 : response.Length)), innerException)
            {
                StatusCode = statusCode;
                Response = response;
                Headers = headers;
            }

            public override string ToString()
            {
                return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class ApiException<TResult> : ApiException
        {
            public TResult Result { get; private set; }

            public ApiException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, TResult result, System.Exception innerException)
                : base(message, statusCode, response, headers, innerException)
            {
                Result = result;
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class BaseTimeSeriesData
        {
            [Newtonsoft.Json.JsonProperty("xAxis", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string XAxis { get; set; }

            [Newtonsoft.Json.JsonProperty("yAxis", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string YAxis { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class ChainBalancesDto
        {
            [Newtonsoft.Json.JsonProperty("networkType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public NetworkType NetworkType { get; set; }

            [Newtonsoft.Json.JsonProperty("publicKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string PublicKey { get; set; }

            [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public NetworkChain NetworkChain { get; set; }

        }



        /// <summary>
        /// 
        /// <br/>
        /// <br/>1 = COIN
        /// <br/>
        /// <br/>2 = TOKEN
        /// </summary>


        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class CurrencyCategoryData
        {
            [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Currency { get; set; }

            [Newtonsoft.Json.JsonProperty("network", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Network { get; set; }

        }

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


        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class RemitanceDepositDetailDtos
        {
            [Newtonsoft.Json.JsonProperty("walletAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string WalletAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionHash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string TransactionHash { get; set; }

            [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double Amount { get; set; }

            [Newtonsoft.Json.JsonProperty("blockTimeStamp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public long BlockTimeStamp { get; set; }

            [Newtonsoft.Json.JsonProperty("gasPrice", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double GasPrice { get; set; }

            [Newtonsoft.Json.JsonProperty("blockNumber", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public long BlockNumber { get; set; }

            [Newtonsoft.Json.JsonProperty("createdAt", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset CreatedAt { get; set; }

            [Newtonsoft.Json.JsonProperty("gasLimit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double GasLimit { get; set; }

            [Newtonsoft.Json.JsonProperty("gasUsed", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double GasUsed { get; set; }

            [Newtonsoft.Json.JsonProperty("currencySymbol", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public CurrencySymbol CurrencySymbol { get; set; }

            [Newtonsoft.Json.JsonProperty("currencyId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string CurrencyId { get; set; }

            [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public NetworkChain NetworkChain { get; set; }

            [Newtonsoft.Json.JsonProperty("networkType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public NetworkType NetworkType { get; set; }

            [Newtonsoft.Json.JsonProperty("currencyName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string CurrencyName { get; set; }

            [Newtonsoft.Json.JsonProperty("transactionType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string TransactionType { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class RemitanceDepositDetailDtosPaginatedResult
        {
            [Newtonsoft.Json.JsonProperty("records", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<RemitanceDepositDetailDtos> Records { get; set; }

            [Newtonsoft.Json.JsonProperty("pageSize", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int PageSize { get; set; }

            [Newtonsoft.Json.JsonProperty("currentPage", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int CurrentPage { get; set; }

            [Newtonsoft.Json.JsonProperty("totalPages", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int TotalPages { get; set; }

            [Newtonsoft.Json.JsonProperty("totalRecords", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int TotalRecords { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class RemitanceDepositDetailResponse
        {
            [Newtonsoft.Json.JsonProperty("remitanceDetail", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public RemitanceDepositDetailDtosPaginatedResult RemitanceDetail { get; set; }

            [Newtonsoft.Json.JsonProperty("isSuccessful", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool IsSuccessful { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("httpStatusCode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public HttpStatusCode HttpStatusCode { get; set; }

            [Newtonsoft.Json.JsonProperty("kyC_Status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public KYC_Status KyC_Status { get; set; }

        }


        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class RemittanceMetricsData
        {
            [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Currency { get; set; }

            [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string NetworkChain { get; set; }

            [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Amount { get; set; }

            [Newtonsoft.Json.JsonProperty("volume", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Volume { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class RemittanceMetricsPayload
        {
            [Newtonsoft.Json.JsonProperty("remittances", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<RemittanceMetricsData> Remittances { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class RemittanceMetricsResponse
        {
            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public RemittanceMetricsPayload Data { get; set; }

            [Newtonsoft.Json.JsonProperty("isSuccessful", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool IsSuccessful { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("httpStatusCode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public HttpStatusCode HttpStatusCode { get; set; }

            [Newtonsoft.Json.JsonProperty("kyC_Status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public KYC_Status KyC_Status { get; set; }

        }



        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class RemittanceRecordResponse
        {
            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public RemittanceByMerchantResponsePaginatedResult Data { get; set; }

            [Newtonsoft.Json.JsonProperty("isSuccessful", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool IsSuccessful { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("httpStatusCode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public HttpStatusCode HttpStatusCode { get; set; }

            [Newtonsoft.Json.JsonProperty("kyC_Status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public KYC_Status KyC_Status { get; set; }

        }

        /// <summary>
        /// 
        /// <br/>
        /// <br/>1 = OK
        /// <br/>
        /// <br/>2 = APP_ERROR
        /// <br/>
        /// <br/>3 = FATAL_ERROR
        /// </summary>


        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class SetUp_2FA_ResponseModel
        {
            [Newtonsoft.Json.JsonProperty("barcodeImageUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string BarcodeImageUrl { get; set; }

            [Newtonsoft.Json.JsonProperty("setupCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string SetupCode { get; set; }

        }

        /// <summary>
        /// 
        /// <br/>
        /// <br/>0 = Sandbox
        /// <br/>
        /// <br/>1 = Server
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public enum SignUpRequest_SentFrom
        {

            _0 = 0,

            _1 = 1,

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class SingleRemittanceRecordResponse
        {
            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public RemittanceByMerchantResponse Data { get; set; }

            [Newtonsoft.Json.JsonProperty("isSuccessful", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool IsSuccessful { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("httpStatusCode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public HttpStatusCode HttpStatusCode { get; set; }

            [Newtonsoft.Json.JsonProperty("kyC_Status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public KYC_Status KyC_Status { get; set; }

        }

        /// <summary>
        /// 
        /// <br/>
        /// <br/>1 = ACTIVE
        /// <br/>
        /// <br/>2 = INACTIVE
        /// </summary>



        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class TimeSeriesData
        {
            [Newtonsoft.Json.JsonProperty("zAxis", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string ZAxis { get; set; }

            [Newtonsoft.Json.JsonProperty("ticker", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Ticker { get; set; }

            [Newtonsoft.Json.JsonProperty("xAxis", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string XAxis { get; set; }

            [Newtonsoft.Json.JsonProperty("yAxis", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string YAxis { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class TransactionCurrencyMetricsData
        {
            [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string NetworkChain { get; set; }

            [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Currency { get; set; }

            [Newtonsoft.Json.JsonProperty("volume", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Volume { get; set; }

            [Newtonsoft.Json.JsonProperty("volumeInUsd", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string VolumeInUsd { get; set; }

            [Newtonsoft.Json.JsonProperty("count", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Count { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
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

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class TransactionFeeMetricsPayload
        {
            [Newtonsoft.Json.JsonProperty("fees", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<TransactionFeeMetricsData> Fees { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
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

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class TransactionMetricsData
        {
            [Newtonsoft.Json.JsonProperty("volume", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Volume { get; set; }

            [Newtonsoft.Json.JsonProperty("count", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Count { get; set; }

            [Newtonsoft.Json.JsonProperty("currencies", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<TransactionCurrencyMetricsData> Currencies { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class TransactionMetricsPayload
        {
            [Newtonsoft.Json.JsonProperty("deposits", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public TransactionMetricsData Deposits { get; set; }

            [Newtonsoft.Json.JsonProperty("withdrawals", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public TransactionMetricsData Withdrawals { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
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

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
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

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
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

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
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

        /// <summary>
        /// 
        /// <br/>
        /// <br/>1 = Deposit
        /// <br/>
        /// <br/>2 = Withdrawal
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public enum TransactionType
        {

            Deposit = 1,

            Withdrawal = 2,

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class UnremittedBalance
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("balance", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public double Balance { get; set; }

            [Newtonsoft.Json.JsonProperty("merchantWalletCurrencyAddressPoolId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid MerchantWalletCurrencyAddressPoolId { get; set; }

            [Newtonsoft.Json.JsonProperty("currencyId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid CurrencyId { get; set; }

            [Newtonsoft.Json.JsonProperty("walletAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string WalletAddress { get; set; }

            [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Currency Currency { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class VmCheckResponse
        {
            [Newtonsoft.Json.JsonProperty("vmType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public NetworkType VmType { get; set; }

            [Newtonsoft.Json.JsonProperty("isSupported", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool IsSupported { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class VmCheckResponseApiResponseModel
        {
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Status { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public VmCheckResponse Data { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
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

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
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

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
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

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class WalletBalanceTimeSeriesMetricsPayload
        {
            [Newtonsoft.Json.JsonProperty("chartData", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<TimeSeriesData> ChartData { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class WalletBalanceTimeSeriesMetricsResponse
        {
            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public WalletBalanceTimeSeriesMetricsPayload Data { get; set; }

            [Newtonsoft.Json.JsonProperty("isSuccessful", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool IsSuccessful { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("httpStatusCode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public HttpStatusCode HttpStatusCode { get; set; }

            [Newtonsoft.Json.JsonProperty("kyC_Status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public KYC_Status KyC_Status { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class WalletGenerationTimeSeriesMetricsPayload
        {
            [Newtonsoft.Json.JsonProperty("count", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Count { get; set; }

            [Newtonsoft.Json.JsonProperty("chartData", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.ICollection<BaseTimeSeriesData> ChartData { get; set; }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class WalletGenerationTimeSeriesMetricsResponse
        {
            [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public WalletGenerationTimeSeriesMetricsPayload Data { get; set; }

            [Newtonsoft.Json.JsonProperty("isSuccessful", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool IsSuccessful { get; set; }

            [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Message { get; set; }

            [Newtonsoft.Json.JsonProperty("httpStatusCode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public HttpStatusCode HttpStatusCode { get; set; }

            [Newtonsoft.Json.JsonProperty("kyC_Status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public KYC_Status KyC_Status { get; set; }

        }
        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class AddSupportedNetworkDto
        {
            [Newtonsoft.Json.JsonProperty("publicKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string PublicKey { get; set; }

            [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public NetworkChain NetworkChain { get; set; }

        }
        /// <summary>
        /// 
        /// <br/>
        /// <br/>1 = MerchantBearsCost
        /// <br/>
        /// <br/>2 = ClientBearsCost


    }

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore 472
#pragma warning restore 114
#pragma warning restore 108
#pragma warning restore 3016
#pragma warning restore 8603

