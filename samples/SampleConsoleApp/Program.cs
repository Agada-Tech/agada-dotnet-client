using System;
using System.Collections.Generic;
using System.Threading;
using Agada;
using Agada.Constants;
using Agada.Models;
using Agada.Services.Hub.Requests;

namespace SampleConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Agada Sample Console App");

            var agadaOptions = new AgadaOptions(AgadaEnvironment.Production, "<API-KEY>", "<CULTURE>", "<CHANNEL-NAME>");
            var client = new AgadaClient(agadaOptions);
            
            var playerId = "95ceacfd-4fa0-4db0-950b-a5f7939ef5d2";
            var playerInfo = client.Game.GetPlayerInfo(playerId);
            Console.WriteLine($"Player Info: {playerInfo.DisplayName}");
            var playerAchievements = client.Game.GetPlayerAchievements(playerId);
            Console.WriteLine($"Player Achievements: {playerAchievements.Count}");
            Console.ReadLine();
        }
    }
}