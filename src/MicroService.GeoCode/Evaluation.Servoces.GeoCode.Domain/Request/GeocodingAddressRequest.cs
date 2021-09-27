using MediatR;

namespace Evaluation.Services.GeoCode.Domain.Request
{
    public class GeocodingAddressRequest : Models.Address, IRequest
    {
    }
}
