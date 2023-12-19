using System.Collections.Generic;

namespace Agada.Services.Adm.Responses
{
    public class Zone
    {
        public string Key { get; set; }
        public string AnalyticsKeyword { get; set; }
        public string ZoneType { get; set; }
        public List<Content> Contents { get; set; }
        public string AspectRatio { get; set; }

        public class Content
        {
            public string CampaignId { get; set; }
            public string MediaType { get; set; }
            public string Media { get; set; }
            public int Rank { get; set; }
            public string IconUrl { get; set; }
            public string TargetUrl { get; set; }
            public string TargetType { get; set; }
            public string AnalyticsKeyword { get; set; }
            public Dictionary<string, string> AdditionalData { get; set; }
        }
    }
}