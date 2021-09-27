using Evaluation.Services.Domain.Controllers;
using Evaluation.Services.Domain.Request;
using Evaluation.Services.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Evaluation.Services.Api.Geo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeolocationController : BaseController<GeolocationController>
    {
        public GeolocationController(ILogger<GeolocationController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpPost("geolocalizacion")]
        [ProducesResponseType(typeof(GeolocationResponse), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Geolocation([FromBody] GeolocationRequest request) => Ok(await _mediator.Send(request));

        [HttpGet("geocodificar/{id}")]
        [ProducesResponseType(typeof(GeocodingResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Geocoding([FromRoute] long id) => Ok(await _mediator.Send(new GeocodingRequest(id)));
    }
}
