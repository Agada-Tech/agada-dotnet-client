using System.Collections.Generic;
using Agada.Services.Promotion.Requests.Shared;

namespace Agada.Services.Promotion.Requests
{
    public class AvailableCampaignsRequestModel
    {
        public PromotionCartContextModel CartContext { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
    }
}