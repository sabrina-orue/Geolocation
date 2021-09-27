using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Evaluation.Services.GeoCode.Infrastructure.Configuration;
using Evaluation.Services.GeoCode.Infrastructure.Entities;
using Evaluation.Services.GeoCode.Infrastructure.Services.Interface;
using Newtonsoft.Json;

namespace Evaluation.Services.GeoCode.Infrastructure.Services
{
    public class MapService : IMapService
    {
        private readonly ConfigurationService _config;
        private readonly HttpClient _client;

        public MapService(ConfigurationService config, HttpClient client)
            {
                _config = config;
                _client = client;
            }

        public async Task<Coordinates> GetCoordenates(Address address, CancellationToken cancellationToken)
        {
            var uri = _config.UrlMaps + $"{address.Street}+{address.Number}+{address.City}+{address.Province}+{address.Country}";
            var data = await _client.GetAsync(uri);
            var stringSerialized = await data.Content.ReadAsStringAsync().ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<MapResult>(stringSerialized);

            return new Coordinates() { Id = address.Id, Latitude = result.Features[0].Geometry[0].Coordinates[0], Longitude = result.Features[0].Geometry[0].Coordinates[1] };
        }

    }
}
