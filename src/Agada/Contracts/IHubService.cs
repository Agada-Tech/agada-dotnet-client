using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agada.Services.Hub.Requests;
using Agada.Services.Hub.Responses;

namespace Agada.Contracts
{
    public interface IHubService
    {
        void SendEvent(SendEventRequest request);
        Task SendEventAsync(SendEventRequest request, CancellationToken cancellationToken);
        
        List<NotificationModel> GetNotifications(string nextToken);
        Task<List<NotificationModel>> GetNotificationsAsync(string nextToken, CancellationToken cancellationToken);

        List<NotificationModel> GetNewNotifications();
        Task<List<NotificationModel>> GetNewNotificationsAsync(CancellationToken cancellationToken);
    }
}