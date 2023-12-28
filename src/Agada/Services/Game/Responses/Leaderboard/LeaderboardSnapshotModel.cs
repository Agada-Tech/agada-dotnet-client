using System;
using System.Collections.Generic;
using Agada.Services.Game.Responses.Shared;

namespace Agada.Services.Game.Responses.Leaderboard
{
    public class LeaderboardSnapshotModel
    {
        public string Id { get; set; }
        public PeriodType Period { get; set; }
        public string Name { get; set; }
        public DateTime StartDateUtc { get; set; }
        public DateTime EndDateUtc { get; set; }
        public List<StandingModel> Standings { get; set; }
    }
}