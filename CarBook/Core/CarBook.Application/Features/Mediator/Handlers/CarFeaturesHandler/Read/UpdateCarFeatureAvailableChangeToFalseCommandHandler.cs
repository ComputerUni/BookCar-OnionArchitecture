using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeaturesHandler.Read
{
    public class UpdateCarFeatureAvailableChangeToFalseCommandHandler(ICarFeatureRepository _repository) : IRequestHandler<UpdateCarFeatureAvailableChangeToFalseCommand>
    {
        public async Task Handle(UpdateCarFeatureAvailableChangeToFalseCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeCarFeatureAvailableToFalse(request.Id); 
        }
    }
}
