using Evaluation.Services.Infrastructure.Context;
using Evaluation.Services.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evaluation.Services.Infrastructure.Repository.Interface
{
    public class AddressRepository: BaseRepository, IAddressRepository
    {
        public AddressRepository(GeolocationContext context) : base(context)
    {
    }
        public async Task<long> Add(Address address, CancellationToken cancellationToken)
        {
            address.Location = new Location() { Status = "PROCESANDO" };
            await _context.Addresses.AddAsync(address, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return address.Id;
        }


        public async Task<Address> Get(int id, CancellationToken cancellationToken) => await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        

        public async Task<IEnumerable<Address>> GetAll(CancellationToken cancellationToken) => await _context.Addresses.ToListAsync(cancellationToken);
        

        public async Task Modify(Address Address, CancellationToken cancellationToken)
        {
            var AddressFound = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == Address.Id, cancellationToken);

            _context.Entry(AddressFound).CurrentValues.SetValues(Address);

            _context.Addresses.Update(AddressFound);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(Address Address, CancellationToken cancellationToken)
        {
            _context.Addresses.Remove(Address);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
