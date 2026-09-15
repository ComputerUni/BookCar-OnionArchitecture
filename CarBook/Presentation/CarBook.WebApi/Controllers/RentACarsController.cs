using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarsController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> GetRentACarListByLocation(GetRentACarQuery query)
        {
            var values = await _mediator.Send(query);
            return Ok(values);
        }
    }
}
