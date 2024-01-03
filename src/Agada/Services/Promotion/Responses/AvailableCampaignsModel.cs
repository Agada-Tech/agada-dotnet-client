using System.Collections.Generic;
using Agada.Services.Promotion.Responses.Shared;

namespace Agada.Services.Promotion.Responses
{
    public class AvailableCampaignsModel
    {
        public List<CampaignModel> ValidCampaigns { get; set; }
        public List<CampaignModel> InvalidCampaigns { get; set; }
    }
}