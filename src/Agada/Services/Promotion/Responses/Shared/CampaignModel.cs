namespace Agada.Services.Promotion.Responses.Shared
{
    public class CampaignModel
    {
        public string Id { get; set; } 
        public string Name { get; set; } 
        public string Description { get; set; }
        public string ImageUrl { get; set; } 
        public AwardModel Award { get; set; } 
        public bool IsCodeRequired { get; set; }
    }
}