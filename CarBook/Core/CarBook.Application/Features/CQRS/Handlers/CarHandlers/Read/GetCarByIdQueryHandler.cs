using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers.Read
{
    public class GetCarByIdQueryHandler(ICarRepository _repository)
    {
        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var value = await _repository.GetCarWithBrandById(query.Id);
            return new GetCarByIdQueryResult
            {
                CarId = value.CarId,
                BrandId = value.BrandId,
                BrandName = value.Brand.Name,
                Model = value.Model,
                CoverImageUrl = value.CoverImageUrl,
                Km = value.Km,
                Transmission = value.Transmission,
                Seat = value.Seat,
                Luggage = value.Luggage,
                Fuel = value.Fuel,
                BigImageUrl = value.BigImageUrl
            };
        } 
    }
}
