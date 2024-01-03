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
            var request = new HttpRequestModel($"/game/v1/player/{playerId}/info", _options);
            var response = RestClient.Get<PlayerInfoModel>(request);
            return response;
        }

        public async Task<PlayerInfoModel> GetPlayerInfoAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestModel($"/game/v1/player/{playerId}/info", _options);
            var response = await RestClient.GetAsync<PlayerInfoModel>(request, cancellationToken);
            return response;
        }

        public List<PlayerAchievementModel> GetPlayerAchievements(string playerId)
        {
            var request = new HttpRequestModel($"/game/v1/player/{playerId}/achievement", _options);
            var response = RestClient.Get<List<PlayerAchievementModel>>(request);
            return response;
        }

        public async Task<List<PlayerAchievementModel>> GetPlayerAchievementsAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestModel($"/game/v1/player/{playerId}/achievement", _options);
            var response = await RestClient.GetAsync<List<PlayerAchievementModel>>(request, cancellationToken);
            return response;
        }

        public void SetPlayerAvatar(string playerId, string avatarId)
        {
            var request = new HttpRequestModel($"/game/v1/player/{playerId}/avatar", _options, new {AvatarId = avatarId});
            RestClient.Post(request);
        }

        public async Task SetPlayerAvatarAsync(string playerId, string avatarId, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestModel($"/game/v1/player/{playerId}/avatar", _options, new {AvatarId = avatarId});
            await RestClient.PostAsync(request, cancellationToken);
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

            var request = new HttpRequestModel(url, _options);
            var response = RestClient.Get<List<StandingModel>>(request);
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

            var request = new HttpRequestModel(url, _options);
            var response = await RestClient.GetAsync<List<StandingModel>>(request, cancellationToken);
            return response;
        }

        public LeaderboardSnapshotModel GetLeaderboardSnapshot(string leaderboardId, DateTime date)
        {
            var request = new HttpRequestModel($"/game/v1/leaderboard/{leaderboardId}/archive?date={date:O}", _options);
            var response = RestClient.Get<LeaderboardSnapshotModel>(request);
            return response;
        }

        public async Task<LeaderboardSnapshotModel> GetLeaderboardSnapshotAsync(string leaderboardId, DateTime date, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestModel($"/game/v1/leaderboard/{leaderboardId}/archive?date={date:O}", _options);
            var response = await RestClient.GetAsync<LeaderboardSnapshotModel>(request, cancellationToken);
            return response;
        }
    }
}