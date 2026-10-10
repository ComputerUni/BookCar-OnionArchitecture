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
    public class UpdateReviewHandler(IRepository<Review> _repository) : IRequestHandler<UpdateReviewCommand>
    {
        public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ReviewId);
            value.CustomerName = request.CustomerName;
            value.CustomerImage = request.CustomerImage;
            value.Comment = request.Comment;
            value.Rating = request.Rating;
            value.ReviewDate = request.ReviewDate;
            value.CarId = request.CarId;
            await _repository.UpdateAsync(value);
        }
    }
}
