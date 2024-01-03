using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agada.Contracts;
using Agada.Helpers;
using Agada.Models;
using Agada.Services.Promotion.Requests;
using Agada.Services.Promotion.Responses;

namespace Agada.Services.Promotion
{
    public class PromotionService : IPromotionService
    {
        private readonly AgadaOptions _options;

        public PromotionService(AgadaOptions options)
        {
            _options = options;
        }

        public List<CouponModel> GetAvailableCoupons(string userId)
        {
            var request = new HttpRequestModel("/promotion/v1/coupons/available", _options, userId);
            return RestClient.Get<List<CouponModel>>(request);
        }

        public async Task<List<CouponModel>> GetAvailableCouponsAsync(string userId, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestModel("/promotion/v1/coupons/available", _options, userId);
            return await RestClient.GetAsync<List<CouponModel>>(request, cancellationToken);
        }

        public CouponValidationModel VerifyCoupon(string userId, CouponVerifyRequestModel request)
        {
            var requestModel = new HttpRequestModel("/promotion/v1/coupon/check", _options, request, userId);
            return RestClient.Post<CouponValidationModel>(requestModel);
        }

        public async Task<CouponValidationModel> VerifyCouponAsync(string userId, CouponVerifyRequestModel request, CancellationToken cancellationToken = default)
        {
            var requestModel = new HttpRequestModel("/promotion/v1/coupon/check", _options, request, userId);
            return await RestClient.PostAsync<CouponValidationModel>(requestModel, cancellationToken);
        }

        public List<LoyaltyCampaignModel> GetAvailableLoyaltyCampaigns(string userId)
        {
            var request = new HttpRequestModel("/promotion/v1/loyalty", _options, userId);
            return RestClient.Get<List<LoyaltyCampaignModel>>(request);
        }

        public async Task<List<LoyaltyCampaignModel>> GetAvailableLoyaltyCampaignsAsync(string userId, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestModel("/promotion/v1/loyalty", _options, userId);
            return await RestClient.GetAsync<List<LoyaltyCampaignModel>>(request, cancellationToken);
        }

        public RedeemLoyaltyCouponResponse RedeemLoyaltyCoupon(string userId, string promotionId)
        {
            var request = new HttpRequestModel($"/promotion/v1/loyalty/coupon", _options, new {PromotionId = promotionId}, userId);
            return RestClient.Post<RedeemLoyaltyCouponResponse>(request);
        }

        public async Task<RedeemLoyaltyCouponResponse> RedeemLoyaltyCouponAsync(string userId, string promotionId, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestModel($"/promotion/v1/loyalty/coupon", _options, new {PromotionId = promotionId}, userId);
            return await RestClient.PostAsync<RedeemLoyaltyCouponResponse>(request, cancellationToken);
        }

        public List<AvailableCampaignsModel> GetAvailableCampaigns(string userId, AvailableCampaignsRequestModel request)
        {
            var requestModel = new HttpRequestModel("/promotion/v1/available", _options, request, userId);
            return RestClient.Post<List<AvailableCampaignsModel>>(requestModel);
        }

        public async Task<List<AvailableCampaignsModel>> GetAvailableCampaignsAsync(string userId, AvailableCampaignsRequestModel request, CancellationToken cancellationToken = default)
        {
            var requestModel = new HttpRequestModel("/promotion/v1/available", _options, request, userId);
            return await RestClient.PostAsync<List<AvailableCampaignsModel>>(requestModel, cancellationToken);
        }

        public CheckPromotionAreValidModel CheckPromotionAreValid(string userId, CheckPromotionAreValidRequestModel request)
        {
            var requestModel = new HttpRequestModel("/promotion/v1/valid", _options, request, userId);
            return RestClient.Post<CheckPromotionAreValidModel>(requestModel);
        }

        public async Task<CheckPromotionAreValidModel> CheckPromotionAreValidAsync(string userId, CheckPromotionAreValidRequestModel request, CancellationToken cancellationToken = default)
        {
            var requestModel = new HttpRequestModel("/promotion/v1/valid", _options, request, userId);
            return await RestClient.PostAsync<CheckPromotionAreValidModel>(requestModel, cancellationToken);
        }
    }
}