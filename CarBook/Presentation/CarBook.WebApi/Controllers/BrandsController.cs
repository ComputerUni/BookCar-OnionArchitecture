using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers.Read;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers.Write;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController(CreateBrandCommandHandler _createBrandCommandHandler, UpdateBrandCommandHandler _updateBrandCommandHandler, RemoveBrandCommandHandler _removeBrandCommandHandler, GetBrandQueryHandler _getBrandQueryHandler, GetBrandByIdQueryHandler _getBrandByIdQueryHandler) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values = await _getBrandQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var value = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand createBrandCommand)
        {
            await _createBrandCommandHandler.Handle(createBrandCommand);
            return Ok("Brand Bilgisi Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            return Ok("Brand Bilgisi Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateBrandCommand updateBrandCommand)
        {
            await _updateBrandCommandHandler.Handle(updateBrandCommand);
            return Ok("Brand Bilgisi Başarıyla Güncellendi");
        }


    }
}
