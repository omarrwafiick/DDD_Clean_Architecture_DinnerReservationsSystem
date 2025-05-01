using ApplicationLayer.Services.Dinners.Commands; 
using Contracts.Dinners;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Mvc;  

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DinnersController(ISender mediator, IMapper mapper) : ControllerBase
    {
        [HttpPost("{hostid}")]
        public async Task<IActionResult> CreateDinner([FromRoute] string hostid, [FromBody] CreateDinnerRequest data)
        {
            var command = mapper.Map<CreateDinnerCommand>((data, hostid));
            var createResult = await mediator.Send(command);
            return Ok(createResult); 
        }

        [HttpPost("{guestid}")]
        public async Task<IActionResult> ReserveDinner([FromRoute] string guestid)
        {
            return Ok();

        }

        [HttpPost("{hostid}")]
        public async Task<IActionResult> StartDinner([FromRoute] string hostid)
        {
            return Ok();
             
        }

        [HttpPost("{hostid}")]
        public async Task<IActionResult> GuestArrivedAt([FromRoute] string hostid)
        {
            return Ok();

        }

        [HttpPost("{hostid}")]
        public async Task<IActionResult> EndDinner([FromRoute] string hostid)
        {
            return Ok();

        }
    }
}
