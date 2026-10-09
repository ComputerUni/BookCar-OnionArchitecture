using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
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

        [HttpGet("CarFeatureChangeAvailableToFalse")]
        public async Task<IActionResult> CarFeatureChangeAvailableToFalse(int id)
        {
            await _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
            return Ok("Güncelleme Yapıldı.");
        }

        [HttpGet("CarFeatureChangeAvailableToTrue")]
        public async Task<IActionResult> CarFeatureChangeAvailableToTrue(int id)
        {
            await _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
            return Ok("Güncelleme Yapıldı.");
        }

        [HttpPost] 
        public async Task<IActionResult> CreateCarFeatureByCarId(CreateCarFeatureByCarCommand command)
        {
            await _mediator.Send(command);
            return Ok("Özellik Ekleme İşlemi Başarıyla Gerçekleşti.");
        }
    }
}
