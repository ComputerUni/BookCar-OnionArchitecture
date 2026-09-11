using CarBook.Application.Interfaces.TagCloudInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.TagCloudRepositories
{
    public class TagCloudRepository(CarBookContext _context) : ITagCloudRepository
    {
        public async Task<List<TagCloud>> GetTagCloudsByBlogId(int id)
        {
            var values = await _context.TagClouds.Where(x => x.BlogId == id).ToListAsync();
            return values;
        }
    }
}
