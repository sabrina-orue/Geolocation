using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Evaluation.Services.Domain.Controllers
{

        public class BaseController<T> : ControllerBase
        {
            protected internal readonly ILogger<T> _logger;

            protected internal readonly IMediator _mediator;


            public BaseController(ILogger<T> logger, IMediator mediator)
            {
                _logger = logger;

                _mediator = mediator;
            }
        }
    }

