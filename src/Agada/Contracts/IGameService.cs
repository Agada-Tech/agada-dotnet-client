using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agada.Services.Game.Responses.Leaderboard;
using Agada.Services.Game.Responses.Player;

namespace Agada.Contracts
{
    public interface IGameService
    {
        PlayerInfoModel GetPlayerInfo(string playerId);
        Task<PlayerInfoModel> GetPlayerInfoAsync(string playerId, CancellationToken cancellationToken = default);

        List<PlayerAchievementModel> GetPlayerAchievements(string playerId);
        Task<List<PlayerAchievementModel>> GetPlayerAchievementsAsync(string playerId, CancellationToken cancellationToken = default);

        void SetPlayerAvatar(string playerId, string avatarId);
        Task SetPlayerAvatarAsync(string playerId, string avatarId, CancellationToken cancellationToken = default);

        List<StandingModel> GetLeaderboard(string leaderboardId, string type = null, string playerId = null);
        Task<List<StandingModel>> GetLeaderboardAsync(string leaderboardId, string type = null, string playerId = null, CancellationToken cancellationToken = default);

        LeaderboardSnapshotModel GetLeaderboardSnapshot(string leaderboardId, DateTime date);
        Task<LeaderboardSnapshotModel> GetLeaderboardSnapshotAsync(string leaderboardId, DateTime date, CancellationToken cancellationToken = default);
    }
}