using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers.Write
{
    public class UpdateSocialMediaCommandHandler(IRepository<SocialMedia> _repository) : IRequestHandler<UpdateSocialMediaCommand>
    {
        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.SocialMediaId);
            value.Name = request.Name;
            value.Url = request.Url;
            value.Icon = request.Icon;

            await _repository.UpdateAsync(value);
        }
    }
}
