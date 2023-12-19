namespace Agada.Models
{
    public class AgadaOptions
    {
        public AgadaOptions(){}
        public AgadaOptions(string baseUrl, string apiKey, string culture, string channelName)
        {
            BaseUrl = baseUrl;
            ApiKey = apiKey;
            Culture = culture;
            ChannelName = channelName;
        }
        public string BaseUrl { get; set; } 
        public string ApiKey { get; set; }
        public string Culture { get; set; }
        public string ChannelName { get; set; }
    }
}