using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agada.Contracts;
using Agada.Helpers;
using Agada.Models;
using Agada.Services.Game.Responses.Leaderboard;
using Agada.Services.Game.Responses.Player;

namespace Agada.Services.Game
{
    internal class GameService : IGameService
    {
        private readonly AgadaOptions _options;

        public GameService(AgadaOptions options)
        {
            _options = options;
        }

        public PlayerInfoModel GetPlayerInfo(string playerId)
        {
            var response = RestClient.Get<PlayerInfoModel>($"/game/v1/player/{playerId}/info", _options);
            return response;
        }

        public async Task<PlayerInfoModel> GetPlayerInfoAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var response = await RestClient.GetAsync<PlayerInfoModel>($"/game/v1/player/{playerId}/info", _options, cancellationToken);
            return response;
        }

        public List<PlayerAchievementModel> GetPlayerAchievements(string playerId)
        {
            var response = RestClient.Get<List<PlayerAchievementModel>>($"/game/v1/player/{playerId}/achievement", _options);
            return response;
        }

        public async Task<List<PlayerAchievementModel>> GetPlayerAchievementsAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var response = await RestClient.GetAsync<List<PlayerAchievementModel>>($"/game/v1/player/{playerId}/achievement", _options, cancellationToken);
            return response;
        }

        public void SetPlayerAvatar(string playerId, string avatarId)
        {
            RestClient.Post($"/game/v1/player/{playerId}/avatar", _options, new {AvatarId = avatarId});
        }

        public async Task SetPlayerAvatarAsync(string playerId, string avatarId, CancellationToken cancellationToken = default)
        {
            await RestClient.PostAsync($"/game/v1/player/{playerId}/avatar", _options, new {AvatarId = avatarId}, cancellationToken);
        }


        public List<StandingModel> GetLeaderboard(string leaderboardId, string type = null, string playerId = null)
        {
            var url = $"/game/v1/leaderboard/{leaderboardId}";
            if (!string.IsNullOrEmpty(type))
            {
                url += $"?type={type}";
            }

            if (!string.IsNullOrEmpty(playerId))
            {
                if (!string.IsNullOrEmpty(type))
                    url += $"&playerId={playerId}";
                else
                    url += $"?playerId={playerId}";
            }

            var response = RestClient.Get<List<StandingModel>>(url, _options);
            return response;
        }


        public async Task<List<StandingModel>> GetLeaderboardAsync(string leaderboardId, string type = null, string playerId = null, CancellationToken cancellationToken = default)
        {
            var url = $"/game/v1/leaderboard/{leaderboardId}";
            if (!string.IsNullOrEmpty(type))
            {
                url += $"?type={type}";
            }

            if (!string.IsNullOrEmpty(playerId))
            {
                if (!string.IsNullOrEmpty(type))
                    url += $"&playerId={playerId}";
                else
                    url += $"?playerId={playerId}";
            }

            var response = await RestClient.GetAsync<List<StandingModel>>(url, _options, cancellationToken);
            return response;
        }

        public LeaderboardSnapshotModel GetLeaderboardSnapshot(string leaderboardId, DateTime date)
        {
            var response = RestClient.Get<LeaderboardSnapshotModel>($"/game/v1/leaderboard/{leaderboardId}/archive?date={date:O}", _options);
            return response;
        }

        public async Task<LeaderboardSnapshotModel> GetLeaderboardSnapshotAsync(string leaderboardId, DateTime date, CancellationToken cancellationToken = default)
        {
            var response = await RestClient.GetAsync<LeaderboardSnapshotModel>($"/game/v1/leaderboard/{leaderboardId}/archive?date={date:O}", _options, cancellationToken);
            return response;
        }
    }
}