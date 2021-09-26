using Evaluation.Services.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evaluation.Services.Infrastructure.Repository.Interface
{
   public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAll( CancellationToken cancellationToken);

        Task<Address> Get(int id, CancellationToken cancellationToken);

        Task<long> Add(Address Address, CancellationToken cancellationToken);

        Task Delete(Address Address, CancellationToken cancellationToken);

        Task Modify(Address Address, CancellationToken cancellationToken);
    }
}
