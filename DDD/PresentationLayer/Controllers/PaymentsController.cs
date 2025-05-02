using ApplicationLayer.Services.Bills.Commands;
using ApplicationLayer.Services.Bills.Queries;
using Contracts.Bills;
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
        public async Task<IActionResult> Bill([FromRoute] string guestid, [FromBody] CreateBillRequest data)
        {
            var command = mapper.Map<CreateBillCommand>((data, guestid));
            var createResult = await mediator.Send(command);
            return Ok(createResult);
        }

        [HttpGet("{guestid/billid}")]
        public async Task<IActionResult> GetBill([FromRoute] string guestid, [FromRoute] string billid)
        {
            var query = new GetBillQuery(guestid, billid);
            var queryResult = await mediator.Send(query);
            return Ok(queryResult);
        } 
    }
}
