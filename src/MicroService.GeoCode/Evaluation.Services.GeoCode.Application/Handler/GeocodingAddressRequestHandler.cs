using AutoMapper;
using Evaluation.Services.GeoCode.Domain.Request;
using Evaluation.Services.GeoCode.Infrastructure.Services.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evaluation.Services.GeoCode.Application.Handler
{
        public class GeocodingAddressRequestHandler : IRequestHandler<GeocodingAddressRequest>
        {
            private readonly IMapService _mapServices;
            private readonly IBusService _busService;


        private readonly IMapper _mapper;

            public GeocodingAddressRequestHandler(IMapService mapServices, IBusService busService, IMapper mapper)
            {
            _mapServices = mapServices;
            _busService = busService;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(GeocodingAddressRequest request, CancellationToken cancellationToken)
            {
                return Unit.Value;
            
        }
        }
}
