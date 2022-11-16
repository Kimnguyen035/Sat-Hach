using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels;
using WebModels.Pagination;

namespace BlazorWebAssemblyApp.Services
{
    public interface IProductApiClient
    {
        public Task<PageList<Producted>> GetList(PagingParameter paging);

        public Task<Producted> GetDetail(string id);
        
        public Task<bool> CreateProduct(CreateProduct product);
        
        public Task<bool> UpdateProduct(Guid id, UpdateProduct product);
        
        public Task<bool> DeleteSoftProduct(Guid id);

        public Task<bool> DeleteProductEternal(Guid id);

        //Recycle Bin
        public Task<List<Producted>> GetListRecycleBin();

        public Task<bool> Resrote(Guid id);
    }
}
