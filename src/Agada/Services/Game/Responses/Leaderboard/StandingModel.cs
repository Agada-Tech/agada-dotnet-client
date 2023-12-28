using Agada.Services.Game.Responses.Shared;

namespace Agada.Services.Game.Responses.Leaderboard
{
    public class StandingModel
    {
        public string PlayerId { get; set; }
        public ImageModel Avatar { get; set; }
        public string DisplayName { get; set; }
        public long Rank { get; set; }
        public decimal Point { get; set; }
    }
}