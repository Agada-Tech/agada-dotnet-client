using Agada.Contracts;
using Agada.Models;
using Agada.Services.Adm;

namespace Agada
{
    public class AgadaClient : IAgadaClient
    {
        public IAdmService Adm { get;}
        
        public AgadaClient(){}
        public AgadaClient(AgadaOptions options)
        {
            Adm = new AdmService(options);
        }
    }
}