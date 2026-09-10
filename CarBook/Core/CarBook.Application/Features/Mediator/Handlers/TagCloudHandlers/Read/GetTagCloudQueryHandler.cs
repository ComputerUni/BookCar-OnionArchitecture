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
    public class GetTagCloudQueryHandler(IRepository<TagCloud> _repository) : IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
    {
        public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTagCloudQueryResult
            {
                TagCloudId = x.TagCloudId,
                Title = x.Title,
                BlogId = x.BlogId,
            }).ToList();
        }
    }
}
