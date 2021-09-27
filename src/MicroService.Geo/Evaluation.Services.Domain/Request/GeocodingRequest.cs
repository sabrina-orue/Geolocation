using Evaluation.Services.Domain.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evaluation.Services.Domain.Request
{
    public class GeocodingRequest : IRequest<GeocodingResponse>
    {
        public long Id { get; set; }
        public GeocodingRequest(long id)
        {
            Id = id;
        }
    }
}
