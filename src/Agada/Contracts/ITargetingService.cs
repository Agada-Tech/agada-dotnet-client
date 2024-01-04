using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agada.Services.Targeting.Responses;

namespace Agada.Contracts
{
    public interface ITargetingService
    {
        List<UserSegmentsResponse> GetUserSegments(string userId);

        Task<List<UserSegmentsResponse>> GetUserSegmentsAsync(string userId, CancellationToken cancellationToken = default);

        void AddUserAttributes(string userId, Dictionary<string, object> attributes);

        Task AddUserAttributesAsync(string userId, Dictionary<string, object> attributes, CancellationToken cancellationToken = default);

        void DeleteUserAttributes(string userId, List<string> attributes);

        Task DeleteUserAttributesAsync(string userId, List<string> attributes, CancellationToken cancellationToken = default);
    }
}