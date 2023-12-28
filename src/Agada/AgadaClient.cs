using Agada.Contracts;
using Agada.Models;
using Agada.Services.Adm;
using Agada.Services.Game;

namespace Agada
{
    public class AgadaClient : IAgadaClient
    {
        public IAdmService Adm { get; }
        public IGameService Game { get; }

        public AgadaClient()
        {
        }

        public AgadaClient(AgadaOptions options)
        {
            Adm = new AdmService(options);
            Game = new GameService(options);
        }
    }
}