using Evaluation.Services.GeoCode.Domain.Controllers;
using Evaluation.Services.GeoCode.Domain.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluation.Services.Api.GeoCode.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeocodingController : BaseController<GeocodingController>
    {
        public GeocodingController(ILogger<GeocodingController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

 
        [HttpPost("geocodificar")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GeocodingAddress([FromBody] GeocodingAddressRequest request) => Ok(await _mediator.Send(request));

    }
}
