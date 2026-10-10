using CarBook.Application.Interfaces.AppUserInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.AppUserRepositoriess
{
    public class AppUserRepository(CarBookContext _context) : IAppUserRepository
    {
        public async Task<AppUser> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
        {
            var value = await _context.AppUsers.Where(filter).Include(x => x.AppRole).FirstOrDefaultAsync();
            return value;
        }
    }
}
