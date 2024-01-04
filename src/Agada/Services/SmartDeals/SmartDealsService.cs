using System.Threading;
using System.Threading.Tasks;
using Agada.Contracts;
using Agada.Helpers;
using Agada.Models;
using Agada.Services.SmartDeals.Requests;
using Agada.Services.SmartDeals.Responses;

namespace Agada.Services.SmartDeals
{
    public class SmartDealsService : ISmartDealsService
    {
        private readonly AgadaOptions _options;

        public SmartDealsService(AgadaOptions options)
        {
            _options = options;
        }

        public OfferResponseModel GetNewOffer(string userId, OfferRequestModel request)
        {
            var httpRequest = new HttpRequestModel("/cat/v1/offer", _options, request, userId);
            return RestClient.Post<OfferResponseModel>(httpRequest);
        }

        public async Task<OfferResponseModel> GetNewOfferAsync(string userId, OfferRequestModel request, CancellationToken cancellationToken = default)
        {
            var httpRequest = new HttpRequestModel("/cat/v1/offer", _options, request, userId);
            return await RestClient.PostAsync<OfferResponseModel>(httpRequest, cancellationToken);
        }

        public OfferResponseModel GetActiveOffer(string userId)
        {
            var httpRequest = new HttpRequestModel("/cat/v1/offer/current", _options, userId);
            return RestClient.Post<OfferResponseModel>(httpRequest);
        }

        public async Task<OfferResponseModel> GetActiveOfferAsync(string userId, CancellationToken cancellationToken = default)
        {
            var httpRequest = new HttpRequestModel("/cat/v1/offer/current", _options, userId);
            return await RestClient.PostAsync<OfferResponseModel>(httpRequest, cancellationToken);
        }
    }
}