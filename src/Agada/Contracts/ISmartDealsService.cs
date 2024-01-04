using System.Threading;
using System.Threading.Tasks;
using Agada.Services.SmartDeals.Requests;
using Agada.Services.SmartDeals.Responses;

namespace Agada.Contracts
{
    public interface ISmartDealsService
    {
        OfferResponseModel GetNewOffer(string userId, OfferRequestModel request);
        Task<OfferResponseModel> GetNewOfferAsync(string userId, OfferRequestModel request, CancellationToken cancellationToken = default);

        OfferResponseModel GetActiveOffer(string userId);
        Task<OfferResponseModel> GetActiveOfferAsync(string userId, CancellationToken cancellationToken = default);
    }
}