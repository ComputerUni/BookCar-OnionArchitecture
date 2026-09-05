using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers.Read;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers.Write;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(CreateAboutCommandHandler _createAboutCommandHandler, GetAboutByIdQueryHandler _getAboutByIdQueryHandler, GetAboutQueryHandler _getAboutQueryHandler, UpdateAboutCommandHandler _updateAboutCommandHandler, RemoveAboutCommandHandler _removeAboutCommandHandler) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _getAboutQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var value = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand createAboutCommand)
        {
            await _createAboutCommandHandler.Handle(createAboutCommand);
            return Ok("Hakkımda Bilgisi Başarıyla Eklendi");
        }

        [HttpDelete] 
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
            return Ok("Hakkımda Bilgisi Başarıyla Silindi");
        }

        [HttpPut] 
        public async Task<IActionResult> UpdateAsync(UpdateAboutCommand updateAboutCommand)
        {
            await _updateAboutCommandHandler.Handle(updateAboutCommand);
            return Ok("Hakkımda Bilgisi Başarıyla Güncellendi");
        }
    }
}
