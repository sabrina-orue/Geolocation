using Evaluation.Services.GeoCode.Infrastructure.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Evaluation.Services.GeoCode.Infrastructure.Services.Interface
{
   public interface IMapService
    {
        Task<Coordinates> GetCoordenates(Address message,CancellationToken cancellationToken);
    }
}
