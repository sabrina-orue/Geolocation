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
        public class GeolocationRequestHandler : IRequestHandler<GeolocationRequest, GeolocationResponse>
        {
            private readonly IAddressRepository _repository;
            private readonly IBusService _service;

            private readonly IMapper _mapper;

            public GeolocationRequestHandler(IBusService service, IAddressRepository repository, IMapper mapper)
            {
                _service = service;
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GeolocationResponse> Handle(GeolocationRequest request, CancellationToken cancellationToken)
            {
                var address = _mapper.Map<Infrastructure.Entities.Address>(request);
                var IdAddress = await _repository.Add(address, cancellationToken);
                await _service.SendMessageQueue(address,"START",cancellationToken);

                return new GeolocationResponse(){ Id= IdAddress};
            }
        }
}
