using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.Entities;
using WebModels.Pagination;

namespace WebApplication.Repositories
{
    public class RecycleBinRepository : IRecycleBinRepository
    {
        private readonly MyDbContext _context;

        public RecycleBinRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllRecycleBin()
        {
            return await _context.Products.ToListAsync();
        }

        public Task<Product> Restore(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
