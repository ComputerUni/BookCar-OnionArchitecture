using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBook.Application.Features.Mediator.Results.TagCloudResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers.Read
{
    public class GetTagCloudByIdQueryHandler(IRepository<TagCloud> _repository) : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
    {
        public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetTagCloudByIdQueryResult
            {
                TagCloudId = value.TagCloudId,
                Title = value.Title,
                BlogId = value.BlogId,
            };
        }
    }
}
