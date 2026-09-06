using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using CarBook.Application.Features.CQRS.Results.CategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers.Read
{
    public class GetCategoryByIdQueryHandler(IRepository<Category> _repository)
    {
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query) 
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetCategoryByIdQueryResult
            {
                CategoryId = values.CategoryId,
                Name = values.Name
            };
        }
    }
}
