using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers.Write
{
    public class CreateReviewHandler(IRepository<Review> _repository) : IRequestHandler<CreateReviewCommand>
    {
        public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Review
            {
                CustomerName = request.CustomerName,
                CustomerImage = request.CustomerImage,
                Comment = request.Comment,
                Rating = request.Rating,
                ReviewDate = request.ReviewDate,
                CarId = request.CarId,
            });
        }
    }
}
