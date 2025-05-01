
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class PaymentsController(ISender mediator, IMapper mapper) : ControllerBase
    {
        [HttpPost("{guestid}")]
        public async Task<IActionResult> Bill([FromRoute] string guestid)
        {
            return Ok();

        }

        [HttpGet("{guestid/billid}")]
        public async Task<IActionResult> GetBill([FromRoute] string guestid, [FromRoute] string billid)
        {
            return Ok(); 

        }

    }
}
