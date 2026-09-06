using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers.Write
{
    public class CreateBrandCommandHandler(IRepository<Brand> _repository)
    {
        public async Task Handle(CreateBrandCommand command)
        {
            await _repository.CreateAsync(new Brand
            {
                Name = command.Name
            });
        }
    }
}
