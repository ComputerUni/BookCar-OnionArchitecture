using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers.Read
{
    public class GetCarPricingWithCarQueryHandler(ICarPricingRepository _repository) : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarPricingWithCars();
            return values.Select(x => new GetCarPricingWithCarQueryResult
            {
                CarPricingId = x.CarPricingId,
                Brand = x.Car.Brand.Name,
                Model = x.Car.Model,
                Amount = x.Amount,
                Km = x.Car.Km,
                Transmission = x.Car.Transmission,
                Seat = x.Car.Seat,
                Luggage = x.Car.Luggage,
                Fuel = x.Car.Fuel,
                CoverImageUrl = x.Car.CoverImageUrl
            }).ToList();
        }
    }
}
