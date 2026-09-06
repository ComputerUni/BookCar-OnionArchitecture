using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Read;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Write;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(CreateBannerCommandHandler _createBannerCommandHandler, UpdateBannerCommandHandler _updateBannerCommandHandler, RemoveBannerCommandHandler _removeBannerCommandHandler, GetBannerQueryHandler _getBannerQueryHandler, GetBannerByIdQueryHandler _getBannerByIdQueryHandler) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var values = await _getBannerQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var value = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand createBannerCommand)
        {
            await _createBannerCommandHandler.Handle(createBannerCommand);
            return Ok("Banner Bilgisi Başarıyla Eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
            return Ok("Banner Bilgisi Başarıyla Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateBannerCommand updateBannerCommand)
        {
            await _updateBannerCommandHandler.Handle(updateBannerCommand);
            return Ok("Banner Bilgisi Başarıyla Güncellendi");
        }
    } 
}
