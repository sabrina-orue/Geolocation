using Evaluation.Services.Infrastructure.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Evaluation.Services.Infrastructure.Services.Interface
{
   public interface IBusService
    {
        Task SendMessageQueue(Address message, string label, CancellationToken cancellationToken);
    }
}
