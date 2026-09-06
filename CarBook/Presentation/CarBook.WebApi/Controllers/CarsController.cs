using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers.Read;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers.Write;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController(CreateCarCommandHandler _createCarCommandHandler, UpdateCarCommandHandler _updateCarCommandHandler, RemoveCarCommandHandler _removeCarCommandHandler, GetCarByIdQueryHandler _getCarByIdQueryHandler, GetCarQueryHandler _getCarQueryHandler) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _getCarQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand createCarCommand)
        {
            await _createCarCommandHandler.Handle(createCarCommand);
            return Ok("Araba Bilgisi Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Araba Bilgisi Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateCarCommand updateCarCommand)
        {
            await _updateCarCommandHandler.Handle(updateCarCommand);
            return Ok("Araba Bilgisi Başarıyla Güncellendi.");
        }
    }
}
