using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Results.AuthorResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers.Read
{
    public class GetAuthorByIdQueryHandler(IRepository<Author> _repository) : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetAuthorByIdQueryResult
            {
                AuthorId = value.AuthorId,
                Name = value.Name,
                ImageUrl = value.ImageUrl,
                Description = value.Description,
            };
        }
    }
}
