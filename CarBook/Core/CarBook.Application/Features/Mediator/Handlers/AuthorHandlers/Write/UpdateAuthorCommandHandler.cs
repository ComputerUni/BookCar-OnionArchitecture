using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers.Write
{
    public class UpdateAuthorCommandHandler(IRepository<Author> _repository) : IRequestHandler<UpdateAuthorCommand>
    {
        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.AuthorId);
            value.Name = request.Name;
            value.ImageUrl = request.ImageUrl;
            value.Description = request.Description;
            await _repository.UpdateAsync(value);
        }
    }
}
