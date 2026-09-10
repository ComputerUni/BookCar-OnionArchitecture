using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Write
{
    public class UpdateBlogCommandHandler(IRepository<Blog> _repository) : IRequestHandler<UpdateBlogCommand>
    {
        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BlogId);
            value.Title = request.Title;
            value.CoverImageUrl = request.CoverImageUrl;
            request.CreatedDate = DateTime.Now;
            await _repository.UpdateAsync(value);

        }
    }
}
