using MediatR;
using Microsoft.AspNetCore.Mvc;
using registerAPI.Query.GetForRent;

namespace registerAPI.Controllers.v1
{
    public class ChoosePlansController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ChoosePlansController> _logger;
        public ChoosePlansController(IMediator mediator, ILogger<ChoosePlansController> logger)
        {
            _mediator = mediator;
            _logger = logger;

        }

        [HttpGet("plansRent")]
        public async Task<IActionResult> GetPlansRent([FromQuery] GetPlansForRentQuery query) =>
            Ok(await _mediator.Send(query));
    }
}
