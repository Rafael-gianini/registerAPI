using MediatR;
using Microsoft.AspNetCore.Mvc;
using registerAPI.Commands.RentedMotorcycle.CreateRental;
using registerAPI.Commands.RentedMotorcycle.DeleteRental;
using registerAPI.Commands.RentedMotorcycle.UpdateRental;
using registerAPI.Query.GetDelivery.GetAllDeliveryPeople;
using registerAPI.Query.GetForRent;
using System.Net;

namespace registerAPI.Controllers.v1
{
    [ApiController]
    [Route("api/v1/rentedMotorcycle")]
    public class RentedMotorcycleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<RentedMotorcycleController> _logger;
        public RentedMotorcycleController(IMediator mediator, ILogger<RentedMotorcycleController> logger)
        {
            _mediator = mediator;
            _logger = logger;

        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllDeliveryPeopleQuery query) =>
            Ok(await _mediator.Send(query));

        [HttpGet("rentByCNH")]
        public async Task<IActionResult> GetByLicense([FromQuery] GetAllDeliveryPeopleQuery query) =>
            Ok(await _mediator.Send(query));       

        [HttpPut("closeRent")]
        public async Task<IActionResult> UpdateRent(UpdateRentalCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpDelete()]
        public async Task<IActionResult> Delete([FromQuery] DeleteRentalCommand query) =>
            Ok(await _mediator.Send(query));

        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post(CreateRentalCommand command) =>
            Ok(await _mediator.Send(command));
    }
}
