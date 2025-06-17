﻿using ApplicationLayer.Services.Dinners.Commands; 
using Contracts.Dinners;
using MapsterMapper;
using MediatR; 
using Microsoft.AspNetCore.Mvc;  

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/dinners")] 
    public class DinnersController(ISender mediator, IMapper mapper) : ControllerBase
    {
        [HttpPost("create/{hostid}")]
        public async Task<IActionResult> CreateDinner([FromRoute] string hostid, [FromBody] CreateDinnerRequest data)
        {
            var command = mapper.Map<CreateDinnerCommand>((data, hostid));
            var createResult = await mediator.Send(command);
            return Ok(createResult); 
        }

        [HttpPost("reserve/{guestid}/{dinnerid}")]
        public async Task<IActionResult> ReserveDinner([FromRoute] string guestid, [FromRoute] string dinnerid, [FromBody] ReserveDinnerRequest data)
        {
            var command = mapper.Map<ReservationCommand>((data, guestid, dinnerid));
            var createResult = await mediator.Send(command);
            return Ok(createResult);
        }

        [HttpPost("start/{hostid}/{dinnerid}")]
        public async Task<IActionResult> StartDinner([FromRoute] string hostid, [FromRoute] string dinnerid, [FromBody] StartDinnerRequest data)
        {
            var command = mapper.Map<StartDinnerCommand>((data, hostid, dinnerid));
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("arrived/{reservationId}/{dinnerid}")]
        public async Task<IActionResult> GuestArrivedAt([FromRoute] string reservationId, [FromRoute] string dinnerid, [FromBody] GuestArrivedAtRequest data)
        { 
            var command = mapper.Map<GuestArrivedAtCommand>((data, reservationId, dinnerid));
            var result = await mediator.Send(command);
            return Ok(result); 
        }

        [HttpPost("end/{hostid}/{dinnerid}")]
        public async Task<IActionResult> EndDinner([FromRoute] string hostid, [FromRoute] string dinnerid, [FromBody] EndDinnerRequest data)
        {
            var command = mapper.Map<EndDinnerCommand>((data, hostid, dinnerid));
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
