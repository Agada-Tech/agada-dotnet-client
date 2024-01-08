namespace Agada.Models
{
    public class AgadaOptions
    {
        public AgadaOptions(string baseUrl, string apiKey, string culture, string channelName)
        {
            BaseUrl = baseUrl;
            ApiKey = apiKey;
            Culture = culture;
            ChannelName = channelName;
        }

        public string BaseUrl { get; }
        public string ApiKey { get; }
        public string Culture { get; }
        public string ChannelName { get; }
    }
}