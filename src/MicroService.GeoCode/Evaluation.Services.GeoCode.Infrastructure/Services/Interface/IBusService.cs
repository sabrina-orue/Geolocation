using Evaluation.Services.GeoCode.Infrastructure.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Evaluation.Services.GeoCode.Infrastructure.Services.Interface
{
   public interface IBusService
    {
        Task SendMessageQueue(Coordinates message, string label, CancellationToken cancellationToken);
    }
}
