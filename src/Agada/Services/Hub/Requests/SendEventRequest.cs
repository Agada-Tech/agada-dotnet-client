using System.Collections.Generic;

namespace Agada.Services.Hub.Requests
{
    public class SendEventRequest
    {
        public string Event { get; set; }
        public string UserId { get; set; }
        public string SessionId { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
    }
}