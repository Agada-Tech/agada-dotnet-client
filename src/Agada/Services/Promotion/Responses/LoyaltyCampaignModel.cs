using Agada.Services.Promotion.Responses.Shared;

namespace Agada.Services.Promotion.Responses
{
    public class LoyaltyCampaignModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public AwardModel Award { get; set; }
        public Config LoyaltyConfig { get; set; }

        public class Config
        {
            public int Point { get; set; }
        }
    }
}