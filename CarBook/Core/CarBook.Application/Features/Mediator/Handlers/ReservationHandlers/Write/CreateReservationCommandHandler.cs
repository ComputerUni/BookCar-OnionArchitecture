using CarBook.Application.Features.Mediator.Commands.ReservationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReservationHandlers.Write
{
    public class CreateReservationCommandHandler(IRepository<Reservation> _repository) : IRequestHandler<CreateReservationCommand>
    {
        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Reservation
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Phone = request.Phone,
                PickUpLocationId = request.PickUpLocationId,
                DropOffLocationId = request.DropOffLocationId,
                CarId = request.CarId,
                Age = request.Age,
                DriverLicenceYear = request.DriverLicenceYear,
                Description = request.Description,
                Status = "Rezervasyon Alındı"
            });
        }
    }
}
