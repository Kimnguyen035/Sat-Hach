using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Entities;
using WebModels.Pagination;

namespace WebApplication.Repositories
{
    public interface IRecycleBinRepository
    {
        public Task<IEnumerable<Product>> GetAllRecycleBin();

        public Task<Product> Restore(Product product);
    }
}
