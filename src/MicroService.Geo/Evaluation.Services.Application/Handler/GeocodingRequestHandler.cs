using AutoMapper;
using Evaluation.Services.Domain.Request;
using Evaluation.Services.Domain.Response;
using Evaluation.Services.Infrastructure.Repository.Interface;
using Evaluation.Services.Infrastructure.Services.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evaluation.Services.Application.Handler
{
        public class GeocodingRequestHandler : IRequestHandler<GeocodingRequest, GeocodingResponse>
        {
            private readonly ILocationRepository _repository;

            private readonly IMapper _mapper;

            public GeocodingRequestHandler(ILocationRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GeocodingResponse> Handle(GeocodingRequest request, CancellationToken cancellationToken)
            {
                var location = await _repository.GetByIdAddress(request.Id, cancellationToken);
                return _mapper.Map<GeocodingResponse>(location);
            
        }
        }
}
