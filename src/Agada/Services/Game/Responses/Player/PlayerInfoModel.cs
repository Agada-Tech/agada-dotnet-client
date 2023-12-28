using System.Collections.Generic;
using Agada.Services.Game.Responses.Shared;

namespace Agada.Services.Game.Responses.Player
{
    public class PlayerInfoModel
    {
        public PlayerInfoModel()
        {
            Teams = new HashSet<string>();
        }

        public string PlayerId { get; set; }
        public AvatarModel Avatar { get; set; }
        public string DisplayName { get; set; }
        public decimal TotalPoint { get; set; }
        public decimal Balance { get; set; }
        public PlayerType PlayerType { get; set; }
        public HashSet<string> Teams { get; set; }
    }
}






