using Agada.Contracts;
using Agada.Models;
using Agada.Services.Adm;
using Agada.Services.Game;
using Agada.Services.Hub;
using Agada.Services.Promotion;
using Agada.Services.SmartDeals;

namespace Agada
{
    public class AgadaClient : IAgadaClient
    {
        public IAdmService Adm { get; }
        public IHubService Hub { get; }
        public IGameService Game { get; }
        public IPromotionService Promotion { get; }
        public ISmartDealsService SmartDeals { get; }
        
        public AgadaClient()
        {
        }

        public AgadaClient(AgadaOptions options)
        {
            Adm = new AdmService(options);
            Hub = new HubService(options);
            Game = new GameService(options);
            Promotion = new PromotionService(options);
            SmartDeals = new SmartDealsService(options);
        }
    }
}