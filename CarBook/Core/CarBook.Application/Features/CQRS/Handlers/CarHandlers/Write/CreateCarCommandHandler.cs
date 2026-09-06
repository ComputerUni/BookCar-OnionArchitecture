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
    public class CreateCarCommandHandler(IRepository<Car> _repository)
    {
        public async Task Handle(CreateCarCommand command)
        {
            await _repository.CreateAsync(new Car
            {
                BrandId = command.BrandId,
                Model = command.Model,
                CoverImageUrl = command.CoverImageUrl,
                Km = command.Km,
                Transmission = command.Transmission,
                Seat = command.Seat,
                Luggage = command.Luggage,
                Fuel = command.Fuel,
                BigImageUrl = command.BigImageUrl,
            });
        }
    }
}
