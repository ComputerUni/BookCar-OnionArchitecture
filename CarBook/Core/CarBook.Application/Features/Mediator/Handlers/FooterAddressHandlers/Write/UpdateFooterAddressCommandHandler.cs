using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers.Write
{
    public class UpdateFooterAddressCommandHandler(IRepository<FooterAddress> _repository) : IRequestHandler<UpdateFooterAddressCommand>
    {
        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.FooterAddressId);
            value.Description = request.Description;
            value.Address = request.Address;
            value.Phone = request.Phone;
            value.Email = request.Email;

            await _repository.UpdateAsync(value);
        }
    }
}
