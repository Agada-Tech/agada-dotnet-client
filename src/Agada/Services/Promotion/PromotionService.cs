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
            return RestClient.Get<List<CouponModel>>("/promotion/v1/coupons/available", _options);
        }

        public Task<List<CouponModel>> GetAvailableCouponsAsync(string userId, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public CouponValidationModel VerifyCoupon(string userId, CouponVerifyRequestModel request)
        {
            throw new System.NotImplementedException();
        }

        public Task<CouponValidationModel> VerifyCouponAsync(string userId, CouponVerifyRequestModel request, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public List<LoyaltyCampaignModel> GetAvailableLoyaltyCampaigns(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<LoyaltyCampaignModel>> GetAvailableLoyaltyCampaignsAsync(string userId, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public RedeemLoyaltyCouponResponse RedeemLoyaltyCoupon(string userId, string promotionId)
        {
            throw new System.NotImplementedException();
        }

        public Task<RedeemLoyaltyCouponResponse> RedeemLoyaltyCouponAsync(string userId, string promotionId, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public List<AvailableCampaignsModel> GetAvailableCampaigns(string userId, AvailableCampaignsRequestModel request)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<AvailableCampaignsModel>> GetAvailableCampaignsAsync(string userId, AvailableCampaignsRequestModel request, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public CheckPromotionAreValidModel CheckPromotionAreValid(string userId, CheckPromotionAreValidRequestModel request)
        {
            throw new System.NotImplementedException();
        }

        public Task<CheckPromotionAreValidModel> CheckPromotionAreValidAsync(string userId, CheckPromotionAreValidRequestModel request, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}