using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository(CarBookContext _context) : ICarRepository
    {
        public async Task<List<Car>> GetCarsListWithBrands()
        {
            var values = await _context.Cars.Include(x => x.Brand).ToListAsync();
            return values;
        }
    }
}
