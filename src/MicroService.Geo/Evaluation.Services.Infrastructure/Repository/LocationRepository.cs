using Evaluation.Services.Infrastructure.Context;
using Evaluation.Services.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evaluation.Services.Infrastructure.Repository.Interface
{
    public class LocationRepository: BaseRepository, ILocationRepository
    {
        public LocationRepository(GeolocationContext context) : base(context)
    {
    }
        public async Task<long> Add(Location Location, CancellationToken cancellationToken)
        {
            await _context.Locations.AddAsync(Location, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Location.Id;
        }


        public async Task<Location> GetByIdAddress(long idAddress, CancellationToken cancellationToken) => await (
                from address in _context.Addresses 
                    join location in _context.Locations 
                        on address.LocationId equals location.Id 
                        where address.Id == idAddress 
                   select location).FirstOrDefaultAsync(cancellationToken);
        
        
        public async Task<IEnumerable<Location>> GetAll(CancellationToken cancellationToken) => await _context.Locations.ToListAsync(cancellationToken);
        

        public async Task Modify(Location Location, CancellationToken cancellationToken)
        {
            var LocationFound = await _context.Locations.FirstOrDefaultAsync(a => a.Id == Location.Id, cancellationToken);

            _context.Entry(LocationFound).CurrentValues.SetValues(Location);

            _context.Locations.Update(LocationFound);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(Location Location, CancellationToken cancellationToken)
        {
            _context.Locations.Remove(Location);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
