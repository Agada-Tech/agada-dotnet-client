using System;
using System.Collections.Generic;
using Agada.Services.Game.Responses.Shared;

namespace Agada.Services.Game.Responses.Player
{
    public class PlayerAchievementModel
    {
        public string PlayerId { get; set; }
        public PlayerType PlayerType { get; set; }
        public List<AchievementModel> Achievements { get; set; }
    }

    public class AchievementModel
    {
        public string ChallengeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ImageModel Badge { get; set; }
        public bool IsRepeatable { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CompletedAtUtc { get; set; }
        public int Percentage { get; set; }
        public int ProgressCount { get; set; }
        public int TotalRuleCount { get; set; }
        public AchievementModel NextAchievement { get; set; }
    }
}