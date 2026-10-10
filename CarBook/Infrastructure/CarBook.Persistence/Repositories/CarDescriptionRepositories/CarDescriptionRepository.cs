using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarDescriptionRepositories
{
    public class CarDescriptionRepository(CarBookContext _context) : ICarDescriptionRepository
    {
        public Task<CarDescription> GetCarDescription(int carId)
        {
            var value = _context.CarDescriptions.Where(x => x.CarId == carId).FirstOrDefaultAsync();
            return value;
        }
    }
}
