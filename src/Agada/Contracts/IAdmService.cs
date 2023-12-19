using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agada.Services.Adm.Responses;

namespace Agada.Contracts
{
    public interface IAdmService
    {
        Zone GetZoneContent(string zoneKey, Dictionary<string, object> metadata);
        Task<Zone> GetZoneContentAsync(string zoneKey, Dictionary<string, object> metadata, CancellationToken cancellationToken);
    }
}