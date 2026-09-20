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
    public class GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository _repository) : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
    {
        public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarPricingWithTimePeriod();
            return values.Select(x => new GetCarPricingWithTimePeriodQueryResult
            {
                Model = x.Model,
                Brand = x.BrandName,
                Transmission = x.Transmission,
                Fuel = x.Fuel,
                CoverImageUrl = x.CoverImageUrl,
                DailyAmount = x.DailyAmount,
                WeeklyAmount = x.WeeklyAmount,
                MonthlyAmount = x.MonthlyAmount,
            }).ToList();
        }
    }
}
