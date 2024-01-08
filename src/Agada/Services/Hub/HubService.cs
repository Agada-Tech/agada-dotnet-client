using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agada.Contracts;
using Agada.Helpers;
using Agada.Models;
using Agada.Services.Hub.Requests;
using Agada.Services.Hub.Responses;

namespace Agada.Services.Hub
{
    public class HubService : IHubService
    {
        private readonly AgadaOptions _options;

        public HubService(AgadaOptions options)
        {
            _options = options;
        }

        public void SendEvent(SendEventRequest request)
        {
            var httpRequest = new HttpRequestModel($"/hub/v1/event", _options, request);
            RestClient.Post(httpRequest);
        }

        public async Task SendEventAsync(SendEventRequest request, CancellationToken cancellationToken)
        {
            var httpRequest = new HttpRequestModel($"/hub/v1/event", _options, request);
            await RestClient.PostAsync(httpRequest, cancellationToken);
        }

        public List<NotificationModel> GetNotifications(string nextToken)
        {
            var httpRequest = new HttpRequestModel($"/hub/v1/notification?nextToken={nextToken}", _options);
            var response = RestClient.Post<List<NotificationModel>>(httpRequest);
            return response;
        }

        public async Task<List<NotificationModel>> GetNotificationsAsync(string nextToken, CancellationToken cancellationToken)
        {
            var httpRequest = new HttpRequestModel($"/hub/v1/notification?nextToken={nextToken}", _options);
            var response = await RestClient.PostAsync<List<NotificationModel>>(httpRequest, cancellationToken);
            return response;
        }

        public List<NotificationModel> GetNewNotifications()
        {
            var httpRequest = new HttpRequestModel($"/hub/v1/notification/unread", _options);
            var response = RestClient.Post<List<NotificationModel>>(httpRequest);
            return response;
        }

        public async Task<List<NotificationModel>> GetNewNotificationsAsync(CancellationToken cancellationToken)
        {
            var httpRequest = new HttpRequestModel($"/hub/v1/notification/unread", _options);
            var response = await RestClient.PostAsync<List<NotificationModel>>(httpRequest, cancellationToken);
            return response;
        }
    }
}