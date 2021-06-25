using Kartrider.Api.Extensions;

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kartrider.Api.Http
{
    /// <summary>
    /// Requester base
    /// </summary>
    public abstract class RequesterBase
    {
        /// <summary>
        /// API Domain
        /// </summary>
        private const string PlatformDomain = "api.nexon.co.kr/kart/v1.0";

        /// <summary>
        /// API 호출 실패 응답 코드 (200 제외)<br/>
        /// <see href="https://developers.nexon.com/kart/faq"></see>
        /// </summary>
        private static readonly HashSet<HttpStatusCode> HttpStatusCodeResponse = new HashSet<HttpStatusCode>
        {
            HttpStatusCode.MovedPermanently, HttpStatusCode.BadRequest,
            HttpStatusCode.Unauthorized, HttpStatusCode.Forbidden,
            HttpStatusCode.NotFound, HttpStatusCode.MethodNotAllowed,
            HttpStatusCode.RequestEntityTooLarge,
            HttpStatusCode.InternalServerError, HttpStatusCode.GatewayTimeout
        };

        private readonly HttpClient _httpClient;

        /// <summary>
        ///     
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <exception cref="ArgumentNullException">apiKey</exception>
        protected RequesterBase(string apiKey) : this()
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException(nameof(apiKey));
            }

            ApiKey = apiKey;
        }

        /// <summary>
        ///    
        /// </summary>
        protected RequesterBase()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// API Key
        /// </summary>
        public string ApiKey { get; }

        #region Protected Methods

        /// <summary>
        ///     Send a <see cref="HttpRequestMessage" /> asynchronously.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Kartrider.Api.KartriderApiException">Thrown if an Http error occurs. Contains the Http error code and error message.</exception>
        protected async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                .ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                HandleRequestFailure(response); //Pass Response to get status code, Then Dispose Object.
            return response;
        }
        /// <summary>
        /// HTTP Request Url Creator
        /// </summary>
        /// <param name="relativeUrl">API 상대 주소</param>
        /// <param name="httpMethod">Http Method</param>
        /// <returns></returns>
        protected HttpRequestMessage PrepareRequest(string relativeUrl, HttpMethod httpMethod)
        {
            var url = $"https://{PlatformDomain}{relativeUrl}";

            var requestMessage = new HttpRequestMessage(httpMethod, url);
            if (!string.IsNullOrEmpty(ApiKey)) requestMessage.Headers.Add("Authorization", ApiKey);
            return requestMessage;
        }
        /// <summary>
        /// Request 실패시 핸들러
        /// </summary>
        /// <param name="response">HttpResponseMessage</param>
        protected void HandleRequestFailure(HttpResponseMessage response)
        {
            try
            {
                if (HttpStatusCodeResponse.Contains(response.StatusCode))
                {
                    string message;
                    try // try get error message from response
                    {
                        var json = response.Content.ReadAsStringAsync().Result;
                        var obj = JsonSerializerExtension.DeserializeAnonymousType(json, new
                        {
                            status = 0,
                            message = ""
                        });
                        message = obj.message;
                    }
                    catch
                    {
                        message = response.StatusCode.ToString();
                    }

                    throw new KartriderApiException(message, response.StatusCode);
                }
                else if (response.StatusCode == (HttpStatusCode)429)
                {
                    throw new KartriderApiException("Api Key의 요청 허용량(Rate Limit) 초과", (HttpStatusCode)429);
                }
                else
                {
                    throw new KartriderApiException("Unexpeced failure", response.StatusCode);
                }
            }
            finally
            {
                response.Dispose(); //Dispose Response On Error
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        protected async Task<string> GetResponseContentAsync(HttpResponseMessage response)
        {
            using (response)
            using (var content = response.Content)
            {
                return await content.ReadAsStringAsync().ConfigureAwait(false);
            }
        }

        #endregion Protected Methods
    }
}