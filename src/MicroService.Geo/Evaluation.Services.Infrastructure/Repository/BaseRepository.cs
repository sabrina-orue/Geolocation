using Evaluation.Services.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evaluation.Services.Infrastructure.Repository
{
    public class BaseRepository
    {
        private protected readonly GeolocationContext _context;

        public BaseRepository(GeolocationContext context)
        {
            _context = context;
        }
    }
}
