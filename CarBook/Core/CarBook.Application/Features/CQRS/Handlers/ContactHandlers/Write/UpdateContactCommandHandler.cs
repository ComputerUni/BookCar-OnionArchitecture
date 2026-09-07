using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers.Write
{
    public class UpdateContactCommandHandler(IRepository<Contact> _repository)
    {
        public async Task Handle(UpdateContactCommand command)
        {
            var value = await _repository.GetByIdAsync(command.ContactId);
            value.Email = command.Email;
            value.Name = command.Name;
            value.Subject = command.Subject;
            value.Message = command.Message;
            value.SendDate = command.SendDate;
            await _repository.UpdateAsync(value);
        }
    }
}
