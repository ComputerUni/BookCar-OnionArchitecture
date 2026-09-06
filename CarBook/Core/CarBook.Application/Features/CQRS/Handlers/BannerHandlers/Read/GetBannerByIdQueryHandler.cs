using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Read
{
    public class GetBannerByIdQueryHandler(IRepository<Banner> _repository)
    {
        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetBannerByIdQueryResult
            {
                 BannerId = values.BannerId,
                Description = values.Description,
                Title = values.Title,
                VideoDescription = values.VideoDescription,
                VideoUrl = values.VideoUrl
            };
        }
    }
}
