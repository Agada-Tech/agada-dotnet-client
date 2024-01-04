using System;
using Agada;
using Agada.Constants;
using Agada.Models;

namespace SampleConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Agada Sample Console App");
            
            var client = new AgadaClient(new AgadaOptions(AgadaEnvironment.Sandbox, "04e8b133-296e-44d3-bdb8-6d1a70ff1431", "en-US", "desktop-web"));
            var playerId = "95ceacfd-4fa0-4db0-950b-a5f7939ef5d2";
            var playerInfo = client.Game.GetPlayerInfo(playerId);
            Console.WriteLine($"Player Info: {playerInfo.DisplayName}");
            var playerAchievements = client.Game.GetPlayerAchievements(playerId);
            Console.WriteLine($"Player Achievements: {playerAchievements.Count}");
            Console.ReadLine();
        }
    }
}