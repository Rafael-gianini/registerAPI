using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using registerAPI.Commands.City;
using registerAPI.Query.GetCity;
using registerAPI.Query.GetPerson;
using System.Net;

namespace registerAPI.Controllers.v1
{
    [Authorize]
    [ApiController]
    [Route("api/v1/city")]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediatR;
        private readonly ILogger<CityController> _logger;
        public CityController(IMediator mediator, ILogger<CityController> logger)
        {
            _mediatR = mediator;
            _logger = logger;

        }

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] GetCityQuery query) =>
          Ok(await _mediatR.Send(query));

        [HttpDelete()]
        public async Task<IActionResult> Delete([FromQuery] GetPeopleQuery query) =>
            Ok(await _mediatR.Send(query));


        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post(CreateOrUpdateCityCommand command) =>
            Ok(await _mediatR.Send(command));
    }
}
