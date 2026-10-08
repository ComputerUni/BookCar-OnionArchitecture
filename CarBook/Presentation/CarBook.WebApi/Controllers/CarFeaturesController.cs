using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("{carId}")]
        public async Task<IActionResult> GetCarFeaturesByCarId(int carId)
        {
            var value = await _mediator.Send(new GetCarFeatureByCarIdQuery(carId));
            return Ok(value);
        }
    }
}
