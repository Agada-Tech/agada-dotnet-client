using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agada.Contracts;
using Agada.Helpers;
using Agada.Models;
using Agada.Services.Targeting.Responses;

namespace Agada.Services.Targeting
{
    public class TargetingService : ITargetingService
    {
        private readonly AgadaOptions _options;

        public TargetingService(AgadaOptions options)
        {
            _options = options;
        }


        public List<UserSegmentsResponse> GetUserSegments(string userId)
        {
            var httpRequest = new HttpRequestModel($"/segment/v1/user/{userId}/segment", _options);
            return RestClient.Get<List<UserSegmentsResponse>>(httpRequest);
        }

        public async Task<List<UserSegmentsResponse>> GetUserSegmentsAsync(string userId, CancellationToken cancellationToken = default)
        {
            var httpRequest = new HttpRequestModel($"/segment/v1/user/{userId}/segment", _options);
            return await RestClient.GetAsync<List<UserSegmentsResponse>>(httpRequest, cancellationToken);
        }

        public void AddUserAttributes(string userId, Dictionary<string, object> attributes)
        {
            var httpRequest = new HttpRequestModel($"/segment/v1/user/{userId}/attribute", _options, attributes);
            RestClient.Put(httpRequest);
        }

        public async Task AddUserAttributesAsync(string userId, Dictionary<string, object> attributes, CancellationToken cancellationToken = default)
        {
            var httpRequest = new HttpRequestModel($"/segment/v1/user/{userId}/attribute", _options, attributes);
            await RestClient.PutAsync(httpRequest, cancellationToken);
        }

        public void DeleteUserAttributes(string userId, List<string> attributes)
        {
            var httpRequest = new HttpRequestModel($"/segment/v1/user/{userId}/attribute", _options, attributes);
            RestClient.Delete(httpRequest);
        }

        public async Task DeleteUserAttributesAsync(string userId, List<string> attributes, CancellationToken cancellationToken = default)
        {
            var httpRequest = new HttpRequestModel($"/segment/v1/user/{userId}/attribute", _options, attributes);
            await RestClient.DeleteAsync(httpRequest, cancellationToken);
        }
    }
}