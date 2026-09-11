using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBook.Application.Features.Mediator.Results.TagCloudResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers.Read
{
    public class GetTagCloudByBlogIdQueryHandler(ITagCloudRepository _repository) : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
    {
        public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetTagCloudsByBlogId(request.Id);
            return value.Select(x => new GetTagCloudByBlogIdQueryResult
            {
                TagCloudId = x.TagCloudId,
                Title = x.Title,
                BlogId = x.BlogId
            }).ToList();

        }
    }
}
