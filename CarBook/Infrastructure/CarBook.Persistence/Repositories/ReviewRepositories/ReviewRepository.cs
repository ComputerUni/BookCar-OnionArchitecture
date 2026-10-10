using CarBook.Application.Interfaces.ReviewInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.ReviewRepositories
{
    public class ReviewRepository(CarBookContext _context) : IReviewRepository
    {
        public async Task<List<Review>> GetReviewByCarId(int carId)
        {
            var values = await _context.Reviews.Where(x => x.CarId == carId).ToListAsync();
            return values;
        }
    }
}
