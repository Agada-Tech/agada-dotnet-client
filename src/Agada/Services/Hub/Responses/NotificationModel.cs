using System.Collections.Generic;

namespace Agada.Services.Hub.Responses
{
    public class NotificationModel
    {
        public string Id { get; set; } 
        public string Title { get; set; } 
        public string Message { get; set; } 
        public string RedirectionUrl { get; set; }
        public ImageModel Image { get; set; }
        public Dictionary<string, string> AdditionalData { get; set; }
    }
}