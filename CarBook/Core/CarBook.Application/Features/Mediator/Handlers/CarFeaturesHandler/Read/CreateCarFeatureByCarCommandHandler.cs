using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeaturesHandler.Read
{
    public class CreateCarFeatureByCarCommandHandler(ICarFeatureRepository _repository) : IRequestHandler<CreateCarFeatureByCarCommand>
    {
        public async Task Handle(CreateCarFeatureByCarCommand request, CancellationToken cancellationToken)
        {
            _repository.CreateCarFeatureByCar(new CarFeature
            {
                Available = false,
                CarId = request.CarId,
                FeatureId = request.FeatureId
            });
        }
    }
}
