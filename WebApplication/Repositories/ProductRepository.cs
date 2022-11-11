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
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext _context;

        public ProductRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<PageList<Product>> GetAllProduct(PagingParameter paging)
        {
            var query = _context.Products.AsQueryable();

            var count = await query.CountAsync();

            var data = await query.OrderByDescending(item => item.Created_at)
                .Skip((paging.PageNumber - 1) * paging.PageSize)
                .Take(paging.PageSize)
                .ToListAsync();

            return new PageList<Product>(data, count, paging.PageNumber, paging.PageSize);
        }

        public async Task<Product> GetProductDetail(long id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdatedProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
