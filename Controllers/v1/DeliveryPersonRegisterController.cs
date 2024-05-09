using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using registerAPI.Commands.Person.CreateOrUpdatePerson;
using registerAPI.Entity;
using registerAPI.Query.GetDelivery.GetAllDeliveryPeople;
using registerAPI.Services;
using System.Net;
using System.Text.RegularExpressions;

namespace registerAPI.Controllers.v1
{
    //[Authorize]
    [ApiController]
    [Route("api/v1/deliveryPerson")]
    public class DeliveryPersonRegisterController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DeliveryPersonRegisterController> _logger;
       
        public DeliveryPersonRegisterController(ILogger<DeliveryPersonRegisterController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] GetAllDeliveryPeopleQuery query) =>
           Ok(await _mediator.Send(query));

        [HttpDelete()]
        public async Task<IActionResult> Delete([FromQuery] GetAllDeliveryPeopleQuery query) =>
            Ok(await _mediator.Send(query));


        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post(CreateOrUpdateDeliveryPersonCommand command) =>
            Ok(await _mediator.Send(command));
       
    }
}
