using CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDescriptionsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCarDescriptionByCarId(int id)
        {
            var value = await _mediator.Send(new GetCarDescriptionByCarIdQuery(id));
            return Ok(value);
        }
    }
}
