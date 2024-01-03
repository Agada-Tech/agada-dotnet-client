using System;
using Agada.Services.Promotion.Responses.Shared;

namespace Agada.Services.Promotion.Responses
{
    public class CouponModel
    {
        public string Id { get; set; } 
        public string Code { get; set; } 
        public string Description { get; set; } 
        public string CampaignId { get; set; }
        public int UsageLimit { get; set; }
        public int UsageCount { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public AwardModel Award { get; set; } 
    }
}