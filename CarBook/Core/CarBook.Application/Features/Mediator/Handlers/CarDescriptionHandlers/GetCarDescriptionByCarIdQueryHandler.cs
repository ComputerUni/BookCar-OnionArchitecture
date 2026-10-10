using CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using CarBook.Application.Features.Mediator.Results.CarDescriptionResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionByCarIdQueryHandler(ICarDescriptionRepository _repository) : IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDescriptionByCarIdQueryResult>
    {
        public async Task<GetCarDescriptionByCarIdQueryResult> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetCarDescription(request.Id);
            return new GetCarDescriptionByCarIdQueryResult
            {
                CarDescriptionId = value.CarDescriptionId,
                CarId = value.CarId,
                Details = value.Details
            };
        }
    }
}
