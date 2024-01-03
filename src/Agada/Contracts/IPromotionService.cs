using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agada.Services.Promotion.Requests;
using Agada.Services.Promotion.Responses;

namespace Agada.Contracts
{
    public interface IPromotionService
    {
        List<CouponModel> GetAvailableCoupons(string userId);

        Task<List<CouponModel>> GetAvailableCouponsAsync(string userId, CancellationToken cancellationToken = default);

        CouponValidationModel VerifyCoupon(string userId, CouponVerifyRequestModel request);

        Task<CouponValidationModel> VerifyCouponAsync(string userId, CouponVerifyRequestModel request, CancellationToken cancellationToken = default);

        List<LoyaltyCampaignModel> GetAvailableLoyaltyCampaigns(string userId);

        Task<List<LoyaltyCampaignModel>> GetAvailableLoyaltyCampaignsAsync(string userId, CancellationToken cancellationToken = default);

        RedeemLoyaltyCouponResponse RedeemLoyaltyCoupon(string userId, string promotionId);

        Task<RedeemLoyaltyCouponResponse> RedeemLoyaltyCouponAsync(string userId, string promotionId, CancellationToken cancellationToken = default);

        List<AvailableCampaignsModel> GetAvailableCampaigns(string userId, AvailableCampaignsRequestModel request);
        
        Task<List<AvailableCampaignsModel>> GetAvailableCampaignsAsync(string userId, AvailableCampaignsRequestModel request, CancellationToken cancellationToken = default);
        
        CheckPromotionAreValidModel CheckPromotionAreValid(string userId, CheckPromotionAreValidRequestModel request);
        
        Task<CheckPromotionAreValidModel> CheckPromotionAreValidAsync(string userId, CheckPromotionAreValidRequestModel request, CancellationToken cancellationToken = default);
    }
}