using ApplicationLayer.Services.Menus.Commands;
using Contracts.Menus; 
using MapsterMapper;
using MediatR; 
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController(ISender mediator, IMapper mapper) : ControllerBase
    {
        [HttpPost("{hostid:guid}")]
        public async Task<IActionResult> Create([FromBody] CreateMenuRequest data, [FromRoute] Guid hostid)
        {
            var command = mapper.Map<CreateMenuCommand>((data, hostid));
            var createResult = await mediator.Send(command);
            return Ok(createResult);
        }
    }
}
