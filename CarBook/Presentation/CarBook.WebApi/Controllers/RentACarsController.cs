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
        [HttpGet]
        public async Task<IActionResult> GetRentACarListByLocation(int locationId, bool isAvailable)
        {
            GetRentACarQuery getRentACarQuery = new GetRentACarQuery
            {
                LocationId = locationId,
                IsAvailable = isAvailable
            };
            var values = await _mediator.Send(getRentACarQuery);
            return Ok(values);
        }
    }
}
