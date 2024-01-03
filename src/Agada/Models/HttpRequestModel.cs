namespace Agada.Models
{
    internal class HttpRequestModel
    {
        public HttpRequestModel(string route, AgadaOptions options)
        {
            Route = route;
            Options = options;
        }

        public HttpRequestModel(string route, AgadaOptions options, object body)
        {
            Route = route;
            Options = options;
            Body = body;
        }

        public HttpRequestModel(string route, AgadaOptions options, string userId)
        {
            Route = route;
            Options = options;
            UserId = userId;
        }

        public HttpRequestModel(string route, AgadaOptions options, object body, string userId)
        {
            Route = route;
            Options = options;
            Body = body;
            UserId = userId;
        }

        public string Route { get; set; }
        public AgadaOptions Options { get; set; }
        public object Body { get; set; }
        public string UserId { get; set; }
    }
}