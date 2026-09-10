using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers.Write
{
    public class UpdateTagCloudCommandHandler(IRepository<TagCloud> _repository) : IRequestHandler<UpdateTagCloudCommand>
    {
        public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TagCloudId);
            value.BlogId = request.BlogId;
            value.Title = request.Title;
            await _repository.UpdateAsync(value);
        }
    }
}
