using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Features.Mediator.Results.ReviewResults;
using CarBook.Application.Interfaces.ReviewInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers.Read
{
    public class GetReviewByCarIdQueryHandler(IReviewRepository _repository) : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
    {
        public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetReviewByCarId(request.Id);
            return values.Select(x => new GetReviewByCarIdQueryResult
            {
                ReviewId = x.ReviewId,
                CustomerName = x.CustomerName,
                CustomerImage = x.CustomerImage,
                Comment = x.Comment,
                Rating = x.Rating,
                ReviewDate = x.ReviewDate,
                CarId = x.CarId
            }).ToList();
        }
    }
}
