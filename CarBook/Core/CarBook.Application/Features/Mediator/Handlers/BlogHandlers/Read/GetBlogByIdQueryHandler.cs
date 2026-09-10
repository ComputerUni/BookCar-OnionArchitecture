using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Read
{
    public class GetBlogByIdQueryHandler(IRepository<Blog> _repository) : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetBlogByIdQueryResult
            {
                BlogId = value.BlogId,
                Title = value.Title,
                AuthorId = value.AuthorId,
                CoverImageUrl = value.CoverImageUrl,
                CreatedDate = value.CreatedDate,
                CategoryId = value.CategoryId,
            };
        }
    }
}
