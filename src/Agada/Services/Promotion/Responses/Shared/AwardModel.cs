using System.Collections.Generic;

namespace Agada.Services.Promotion.Responses.Shared
{
    public class AwardModel
    {
        public AwardType AwardType { get; set; }
        public DiscountType DiscountType { get; set; }
        public decimal DiscountValue { get; set; }
        public string TargetId { get; set; }
        public List<string> VendorIds { get; set; }
        public int? MaxUsageLimit { get; set; }
        public decimal? MaxDiscountValue { get; set; }
    }
}