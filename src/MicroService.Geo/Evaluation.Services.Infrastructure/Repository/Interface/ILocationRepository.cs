using Evaluation.Services.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evaluation.Services.Infrastructure.Repository.Interface
{
   public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetAll( CancellationToken cancellationToken);

        Task<Location> GetByIdAddress(long idAdress, CancellationToken cancellationToken);

        Task<long> Add(Location location, CancellationToken cancellationToken);

        Task Delete(Location location, CancellationToken cancellationToken);

        Task Modify(Location location, CancellationToken cancellationToken);
    }
}
