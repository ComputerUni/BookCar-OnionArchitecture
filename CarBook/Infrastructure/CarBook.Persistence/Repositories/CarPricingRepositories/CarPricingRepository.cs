using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository(CarBookContext _context) : ICarPricingRepository
    {
        public async Task<List<CarPricing>> GetCarPricingWithCars()
        {
            var values = await _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingId == 1).ToListAsync();
            return values;
        }

        public async Task<List<CarPricingViewModel>> GetCarPricingWithTimePeriod()
        {
            var values = await _context.Cars.Select(z => new CarPricingViewModel
            {
                Model = z.Model,
                BrandName = z.Brand.Name,
                CoverImageUrl = z.CoverImageUrl,
                DailyAmount = z.CarPricings.Where(p => p.PricingId == 1).Select(p => p.Amount).FirstOrDefault(),
                WeeklyAmount = z.CarPricings.Where(p => p.PricingId == 2).Select(p => p.Amount).FirstOrDefault(),
                MonthlyAmount = z.CarPricings.Where(p => p.PricingId == 3).Select(p => p.Amount).FirstOrDefault()

            }).ToListAsync();

            return values;
        }
    }
}
