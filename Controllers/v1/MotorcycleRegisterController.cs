﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using registerAPI.Commands.BikeRegister.UpdateMotorcycle;
using registerAPI.Commands.City.CreateOrUpdateMotocycle;
using registerAPI.Commands.City.DeleteMotorcycle;
using registerAPI.Query.GetBike.GetAllBikes;
using registerAPI.Query.GetBike.GetBikeLicense;
using System.Net;

namespace registerAPI.Controllers.v1
{
    [Authorize]
    [ApiController]
    [Route("api/v1/motorcycleRegister")]
    public class MotorcycleRegisterController : ControllerBase
    {
        private readonly IMediator _mediatR;
        private readonly ILogger<MotorcycleRegisterController> _logger;
        public MotorcycleRegisterController(IMediator mediator, ILogger<MotorcycleRegisterController> logger)
        {
            _mediatR = mediator;
            _logger = logger;

        }

        [HttpGet("all")]
        public async Task<IActionResult> Get([FromQuery] GetAllMotorcycleQuery query) =>
           Ok(await _mediatR.Send(query));

        [HttpGet("byLicense")]
        public async Task<IActionResult> GetByLicense([FromQuery] GetMotorcycleLicenseQuery query) =>
           Ok(await _mediatR.Send(query));
      
        [HttpDelete()]
        public async Task<IActionResult> Delete(DeleteMotorcycleCommand command) =>
            Ok(await _mediatR.Send(command));

        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post(CreateMotorcycleCommand command) =>
            Ok(await _mediatR.Send(command));

        [HttpPut()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Upadate(UpdateMotorcycleCommand command) =>
           Ok(await _mediatR.Send(command));
    }
}
