using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers.Write
{
    public class RemoveCarCommandHandler(IRepository<Car> _repository)
    {
        public async Task Handle(RemoveCarCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);

        }
    }
}
