using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository(CarBookContext _context) : ICarFeatureRepository
    {
        public Task<List<CarFeature>> GetCarFeatureByCarIdAsync(int carId)
        {
            var values = _context.CarFeatures.Include(x => x.Feature).Where(x => x.CarId == carId).ToListAsync();
            return values;
        }
    }
}
