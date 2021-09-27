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
        public class SaveGeocodingRequestHandler : IRequestHandler<SaveGeocodingRequest>
        {
            private readonly ILocationRepository _repository;
            private readonly IBusService _service;

            private readonly IMapper _mapper;

            public SaveGeocodingRequestHandler(ILocationRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(SaveGeocodingRequest request, CancellationToken cancellationToken)
            {
                var location = await _repository.GetByIdAddress(request.Id,cancellationToken);
                location.Latitude = request.Latitude;
                location.Longitude = request.Longitude;
                location.Status = "TERMINADO";
                await _repository.Modify(location, cancellationToken);
                return Unit.Value;
            }
        }
}
