using Evaluation.Services.Domain.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evaluation.Services.Domain.Request
{
    public class SaveGeocodingRequest : Models.Coordinates, IRequest
    {
    }
}
