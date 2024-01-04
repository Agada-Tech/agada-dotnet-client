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
            var httpRequest = new HttpRequestModel($"/adm/v1/zone?key={zoneKey}", _options, new {metadata});
            var response = RestClient.Post<Zone>(httpRequest);
            return response;
        }

        public async Task<Zone> GetZoneContentAsync(string zoneKey, Dictionary<string, object> metadata, CancellationToken cancellationToken)
        {
            var httpRequest = new HttpRequestModel($"/adm/v1/zone?key={zoneKey}", _options, new {metadata});
            var response = await RestClient.PostAsync<Zone>(httpRequest, cancellationToken);
            return response;
        }
    }
}