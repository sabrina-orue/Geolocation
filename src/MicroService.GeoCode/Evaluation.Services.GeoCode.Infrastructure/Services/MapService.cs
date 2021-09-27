using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Evaluation.Services.GeoCode.Infrastructure.Entities;
using Evaluation.Services.GeoCode.Infrastructure.Services.Interface;

namespace Evaluation.Services.GeoCode.Infrastructure.Services
{
    public class MapService : IMapService
    {
        public Task GetCoordenates(Address address, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
