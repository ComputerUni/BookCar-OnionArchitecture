using CarBook.Application.Features.CQRS.Commands.CreateCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers.Write
{
    public class UpdateCategoryCommandHandler(IRepository<Category> _repository)
    {
        public async Task Handle(UpdateCategoryCommand command)
        {
            var value = await _repository.GetByIdAsync(command.CategoryId);
            value.Name = command.Name;

            await _repository.UpdateAsync(value);
        }
    }
}
