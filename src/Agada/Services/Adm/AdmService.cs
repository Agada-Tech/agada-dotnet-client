using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agada.Contracts;
using Agada.Helpers;
using Agada.Models;
using Agada.Services.Adm.Responses;

namespace Agada.Services.Adm
{
    internal class AdmService : IAdmService
    {
        private readonly AgadaOptions _options;

        public AdmService(AgadaOptions options)
        {
            _options = options;
        }

        public Zone GetZoneContent(string zoneKey, Dictionary<string, object> metadata)
        {
            var response = RestClient.Post<Zone>($"/adm/v1/zone?key={zoneKey}", _options, new {metadata});
            return response;
        }

        public async Task<Zone> GetZoneContentAsync(string zoneKey, Dictionary<string, object> metadata, CancellationToken cancellationToken)
        {
            var response = await RestClient.PostAsync<Zone>($"/adm/v1/zone?key={zoneKey}", _options, new {metadata}, cancellationToken);
            return response;
        }
    }
}