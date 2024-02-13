using MediatR;
using Microsoft.AspNetCore.Mvc;
using registerAPI.Commands.Person;
using registerAPI.Entity;
using registerAPI.Query.GetPerson;
using registerAPI.Services;
using System.Net;
using System.Text.RegularExpressions;

namespace registerAPI.Controllers.v1
{
    [ApiController]
    [Route("api/v1/people")]
    public class PeopleController : ControllerBase
    {
        private readonly IMediator _mediatR;
        private readonly ILogger<PeopleController> _logger;
       
        public PeopleController(ILogger<PeopleController> logger, IMediator mediator)
        {
            _logger = logger;
           _mediatR = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] GetPeopleQuery query) =>
           Ok(await _mediatR.Send(query));

        //[HttpDelete()]
        //public async Task<IActionResult> Get([FromQuery] GetPeopleQuery query) =>
        //    Ok(await _mediatR.Send(query));
  

        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post(CreateOrUpdatePersonCommand command) =>
            Ok(await _mediatR.Send(command));
       
    }
}
