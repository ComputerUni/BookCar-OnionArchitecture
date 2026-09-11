using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Read
{
    public class GetAllBlogsWithAuthorQueryHandler(IBlogRepository _repository) : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
    {
        public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllBlogsWithAuthors();
            return values.Select(x => new GetAllBlogsWithAuthorQueryResult
            {
                BlogId = x.BlogId,
                Title = x.Title,
                AuthorName = x.Author.Name,
                AuthorImageUrl = x.Author.ImageUrl,
                AuthorDescription = x.Author.Description,
                CategoryName = x.Category.Name,
                AuthorId = x.AuthorId,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                CategoryId = x.CategoryId,
                Description = x.Description
            }).ToList();
        }
    }
}
