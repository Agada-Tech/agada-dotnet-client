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

        public static Task<T> GetAsync<T>(string route, AgadaOptions options, CancellationToken cancellationToken)
        {
            return SendAsync<T>(route, HttpMethod.Get, options, cancellationToken);
        }

        public static Task<T> PostAsync<T>(string route, AgadaOptions options, object request, CancellationToken cancellationToken)
        {
            return SendAsync<T>(route, HttpMethod.Post, options, cancellationToken, request);
        }

        public static Task PostAsync(string route, AgadaOptions options, object request, CancellationToken cancellationToken)
        {
            return SendAsync(route, HttpMethod.Post, options, cancellationToken, request);
        }

        public static Task<T> PutAsync<T>(string route, AgadaOptions options, object request, CancellationToken cancellationToken)
        {
            return SendAsync<T>(route, HttpMethod.Put, options, cancellationToken, request);
        }

        public static Task DeleteAsync<T>(string route, AgadaOptions options, CancellationToken cancellationToken)
        {
            return SendAsync<T>(route, HttpMethod.Delete, options, cancellationToken);
        }

        public static T Get<T>(string route, AgadaOptions options, Dictionary<string, string> headers = null)
        {
            return Send<T>(route, HttpMethod.Get, options, null);
        }

        public static T Post<T>(string route, AgadaOptions options, object request)
        {
            return Send<T>(route, HttpMethod.Post, options, request);
        }

        public static void Post(string route, AgadaOptions options, object request)
        {
            Send(route, HttpMethod.Post, options, request);
        }

        public static T Put<T>(string route, AgadaOptions options, object request)
        {
            return Send<T>(route, HttpMethod.Put, options, request);
        }

        public static T Delete<T>(string route, AgadaOptions options)
        {
            return Send<T>(route, HttpMethod.Delete, options, null);
        }


        #region Private Methods

        private static HttpRequestMessage BuildRequestMessage(string route, HttpMethod httpMethod, AgadaOptions options, object request)
        {
            var requestMessage = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = new Uri($"{options.BaseUrl}{route}"),
            };
            if (request != null)
                requestMessage.Content = PrepareContent(request);
            requestMessage.Headers.TryAddWithoutValidation("Authorization", options.ApiKey);
            requestMessage.Headers.TryAddWithoutValidation(AgadaRequestHeaders.Culture, options.Culture);
            requestMessage.Headers.TryAddWithoutValidation(AgadaRequestHeaders.ChannelName, options.ChannelName);
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

        private static T Send<T>(string route, HttpMethod httpMethod, AgadaOptions options, object request)
        {
            try
            {
                var requestMessage = BuildRequestMessage(route, httpMethod, options, request);
                var httpResponseMessage = _httpClient.SendAsync(requestMessage).Result;
                var content = httpResponseMessage.Content.ReadAsByteArrayAsync().Result;
                return HandleResponse<T>(httpResponseMessage, content);
            }
            catch (Exception e)
            {
                throw new AgadaException(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        private static async Task<T> SendAsync<T>(string route, HttpMethod httpMethod, AgadaOptions options, CancellationToken cancellationToken, object request = null)
        {
            try
            {
                var requestMessage = BuildRequestMessage(route, httpMethod, options, request);
                var httpResponseMessage = await _httpClient.SendAsync(requestMessage, cancellationToken);
                var content = await httpResponseMessage.Content.ReadAsByteArrayAsync();
                return HandleResponse<T>(httpResponseMessage, content);
            }
            catch (Exception e)
            {
                throw new AgadaException(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        private static void Send(string route, HttpMethod httpMethod, AgadaOptions options, object request)
        {
            try
            {
                var requestMessage = BuildRequestMessage(route, httpMethod, options, request);
                _ = _httpClient.SendAsync(requestMessage).Result;
            }
            catch (Exception e)
            {
                throw new AgadaException(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        private static async Task SendAsync(string route, HttpMethod httpMethod, AgadaOptions options, CancellationToken cancellationToken, object request = null)
        {
            try
            {
                var requestMessage = BuildRequestMessage(route, httpMethod, options, request);
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