using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Agada.Constants;
using Agada.Models;
using Newtonsoft.Json;

namespace Agada.Helpers
{
    internal static class RestClient
    {
        private static readonly HttpClient _httpClient;

        static RestClient()
        {
#if !NETSTANDARD1_3
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
#endif
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                AllowAutoRedirect = false,
            };
            _httpClient = new HttpClient(handler);
        }

        public static Task<T> GetAsync<T>(HttpRequestModel request, CancellationToken cancellationToken)
        {
            return SendAsync<T>(request, HttpMethod.Get, cancellationToken);
        }

        public static Task<T> PostAsync<T>(HttpRequestModel request, CancellationToken cancellationToken)
        {
            return SendAsync<T>(request, HttpMethod.Post, cancellationToken);
        }

        public static Task PostAsync(HttpRequestModel request, CancellationToken cancellationToken)
        {
            return SendAsync(request, HttpMethod.Post, cancellationToken);
        }

        public static Task<T> PutAsync<T>(HttpRequestModel request, CancellationToken cancellationToken)
        {
            return SendAsync<T>(request, HttpMethod.Put, cancellationToken);
        }


        public static Task PutAsync(HttpRequestModel request, CancellationToken cancellationToken)
        {
            return SendAsync(request, HttpMethod.Put, cancellationToken);
        }

        public static Task DeleteAsync<T>(HttpRequestModel request, CancellationToken cancellationToken)
        {
            return SendAsync<T>(request, HttpMethod.Delete, cancellationToken);
        }

        public static Task DeleteAsync(HttpRequestModel request, CancellationToken cancellationToken)
        {
            return SendAsync(request, HttpMethod.Delete, cancellationToken);
        }

        public static T Get<T>(HttpRequestModel request)
        {
            return Send<T>(request, HttpMethod.Get);
        }

        public static T Post<T>(HttpRequestModel request)
        {
            return Send<T>(request, HttpMethod.Post);
        }

        public static void Post(HttpRequestModel request)
        {
            Send(request, HttpMethod.Post);
        }

        public static T Put<T>(HttpRequestModel request)
        {
            return Send<T>(request, HttpMethod.Put);
        }

        public static void Put(HttpRequestModel request)
        {
            Send(request, HttpMethod.Put);
        }

        public static T Delete<T>(HttpRequestModel request)
        {
            return Send<T>(request, HttpMethod.Delete);
        }

        public static void Delete(HttpRequestModel request)
        {
            Send(request, HttpMethod.Delete);
        }


        #region Private Methods

        private static HttpRequestMessage BuildRequestMessage(HttpRequestModel request, HttpMethod httpMethod)
        {
            var requestMessage = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = new Uri($"{request.Options.BaseUrl}{request.Route}"),
            };
            if (request.Body != null)
                requestMessage.Content = PrepareContent(request.Body);

            if (request.UserId != null)
                requestMessage.Headers.TryAddWithoutValidation(AgadaRequestHeaders.UserId, request.UserId);

            requestMessage.Headers.TryAddWithoutValidation(AgadaRequestHeaders.Authorization, request.Options.ApiKey);
            requestMessage.Headers.TryAddWithoutValidation(AgadaRequestHeaders.Culture, request.Options.Culture);
            requestMessage.Headers.TryAddWithoutValidation(AgadaRequestHeaders.ChannelName, request.Options.ChannelName);
            return requestMessage;
        }

        private static T HandleResponse<T>(HttpResponseMessage httpResponseMessage, byte[] content)
        {
            return typeof(T) == typeof(byte[])
                ? HandleByteArrayResponse<T>(httpResponseMessage, content)
                : HandleJsonResponse<T>(httpResponseMessage, content);
        }

        private static T HandleJsonResponse<T>(HttpResponseMessage httpResponseMessage, byte[] content)
        {
            if (!httpResponseMessage.IsSuccessStatusCode)
                throw new AgadaException(httpResponseMessage.StatusCode, httpResponseMessage.ReasonPhrase);

            var contentString = Encoding.UTF8.GetString(content);
            var apiResponse = JsonConvert.DeserializeObject<T>(contentString, AgadaSettings.JsonSettings);
            return apiResponse == null ? default : apiResponse;
        }

        private static T HandleByteArrayResponse<T>(HttpResponseMessage httpResponseMessage, byte[] content)
        {
            if (!httpResponseMessage.IsSuccessStatusCode)
                throw new AgadaException(httpResponseMessage.StatusCode, httpResponseMessage.ReasonPhrase);

            return (T) Convert.ChangeType(content, typeof(T));
        }

        private static StringContent PrepareContent(object request)
        {
            if (request == null) return null;
            var body = JsonConvert.SerializeObject(request, AgadaSettings.JsonSettings);
            return new StringContent(body, Encoding.UTF8, "application/json");
        }

        private static T Send<T>(HttpRequestModel request, HttpMethod httpMethod)
        {
            try
            {
                var requestMessage = BuildRequestMessage(request, httpMethod);
                var httpResponseMessage = _httpClient.SendAsync(requestMessage).Result;
                var content = httpResponseMessage.Content.ReadAsByteArrayAsync().Result;
                return HandleResponse<T>(httpResponseMessage, content);
            }
            catch (Exception e)
            {
                throw new AgadaException(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        private static async Task<T> SendAsync<T>(HttpRequestModel request, HttpMethod httpMethod, CancellationToken cancellationToken)
        {
            try
            {
                var requestMessage = BuildRequestMessage(request, httpMethod);
                var httpResponseMessage = await _httpClient.SendAsync(requestMessage, cancellationToken);
                var content = await httpResponseMessage.Content.ReadAsByteArrayAsync();
                return HandleResponse<T>(httpResponseMessage, content);
            }
            catch (Exception e)
            {
                throw new AgadaException(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        private static void Send(HttpRequestModel request, HttpMethod httpMethod)
        {
            try
            {
                var requestMessage = BuildRequestMessage(request, httpMethod);
                _ = _httpClient.SendAsync(requestMessage).Result;
            }
            catch (Exception e)
            {
                throw new AgadaException(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        private static async Task SendAsync(HttpRequestModel request, HttpMethod httpMethod, CancellationToken cancellationToken)
        {
            try
            {
                var requestMessage = BuildRequestMessage(request, httpMethod);
                await _httpClient.SendAsync(requestMessage, cancellationToken);
            }
            catch (Exception e)
            {
                throw new AgadaException(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        #endregion
    }
}