using CarBook.Application.Interfaces.CarPricingInterfaces;
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
            var values = await _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingId == 4).ToListAsync();
            return values;
        }
    }
}
