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
    public class CreateFooterAddressCommandHandler(IRepository<FooterAddress> _repository) : IRequestHandler<CreateFooterAddressCommand>
    {
        public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new FooterAddress
            {
                Description = request.Description,
                Address = request.Address,
                Phone = request.Phone,
                Email = request.Email
            });
        }
    }
}
