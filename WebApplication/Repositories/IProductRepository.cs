using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Entities;
using WebModels.Pagination;

namespace WebApplication.Repositories
{
    public interface IProductRepository
    {
        Task<PageList<Product>> GetAllProduct(PagingParameter paging);

        Task<Product> GetProductDetail(long id);

        Task<Product> CreateProduct(Product product);

        Task<Product> UpdatedProduct(Product product);

        Task<Product> DeleteProduct(Product product);
    }
}
