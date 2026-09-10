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
    public class CreateBlogCommandHandler(IRepository<Blog> _repository) : IRequestHandler<CreateBlogCommand>
    {
        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Blog
            {
                Title = request.Title,
                CoverImageUrl = request.CoverImageUrl,
                CreatedDate = DateTime.Now,
            });
        }
    }
}
