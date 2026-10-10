using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Validators.ReviewValidators;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetReviewByCarId(int carId)
        {
            var value = await _mediator.Send(new GetReviewByCarIdQuery(carId));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewCommand createReviewCommand)
        {
            CreateReviewValidator validator = new CreateReviewValidator();
            var validationResult = validator.Validate(createReviewCommand);

            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _mediator.Send(createReviewCommand);
            return Ok("Yorum Kaydı Başarıyla Oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReview(UpdateReviewCommand updateReviewCommand)
        {
            await _mediator.Send(updateReviewCommand);
            return Ok("Yorum Kaydı Başarıyla Güncellendi.");
        }
    }
}
