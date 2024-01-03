using System.Collections.Generic;
using Agada.Services.Promotion.Requests.Shared;

namespace Agada.Services.Promotion.Requests
{
    public class CheckPromotionAreValidRequestModel
    {
        public List<PromotionInfo> Promotions { get; set; }

        public PromotionCartContextModel CartContext { get; set; }
        public Dictionary<string, string> Metadata { get; set; }

        public class PromotionInfo
        {
            public string Id { get; set; }
            public string Code { get; set; }
            public int Rank { get; set; }
        }
    }
}