using System.Collections.Generic;
using Agada.Services.Promotion.Responses.Shared;

namespace Agada.Services.Promotion.Responses
{
    public class CheckPromotionAreValidModel
    {
        public List<PromotionInfo> Promotions { get; set; }

        public class PromotionInfo
        {
            public string Id { get; set; }
            public string Code { get; set; }
            public int Rank { get; set; }
            public bool IsValid { get; set; }
            public AwardModel Award { get; set; }
            public List<string> ErrorMessages { get; set; }
        }
    }
}