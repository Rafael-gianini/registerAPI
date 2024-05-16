using MediatR;
using Microsoft.AspNetCore.Mvc;
using registerAPI.Commands.Person.CreateOrUpdatePerson;
using registerAPI.Commands.RentedMotorcycle.CreateLocation;
using registerAPI.Commands.RentedMotorcycle.DeleteLease;
using registerAPI.Commands.RentedMotorcycle.UpdateLease;
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

        [HttpGet("plansRent")]
        public async Task<IActionResult> GetPlansRent([FromQuery] GetPlansForRentQuery query) =>
            Ok(await _mediator.Send(query));

        [HttpPut("closeRent")]
        public async Task<IActionResult> UdateRent(UpdateRentalCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpDelete()]
        public async Task<IActionResult> Delete([FromQuery] DeleteLeaseCommand query) =>
            Ok(await _mediator.Send(query));

        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post(CreateRentalCommand command) =>
            Ok(await _mediator.Send(command));
    }
}
