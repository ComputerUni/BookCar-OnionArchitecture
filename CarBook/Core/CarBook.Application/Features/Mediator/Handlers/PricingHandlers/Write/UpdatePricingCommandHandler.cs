using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers.Write
{
    public class UpdatePricingCommandHandler(IRepository<Pricing> _repository) : IRequestHandler<UpdatePricingCommand>
    {
        public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.PricingId);
            value.Name = request.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
