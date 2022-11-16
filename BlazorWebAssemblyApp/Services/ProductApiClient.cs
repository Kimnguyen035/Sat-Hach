using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebModels;
using WebModels.Pagination;

namespace BlazorWebAssemblyApp.Services
{
    public class ProductApiClient : IProductApiClient
    {
        public HttpClient _httpClient;

        public ProductApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PageList<Producted>> GetList(PagingParameter paging)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = paging.PageNumber.ToString()
            };

            var url = QueryHelpers.AddQueryString("/api/product", queryStringParam);

            var result = await _httpClient.GetFromJsonAsync<PageList<Producted>>(url);

            return result;
        }

        public async Task<Producted> GetDetail(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<Producted>($"/api/product/{id}");

            return result;
        }

        public async Task<bool> CreateProduct(CreateProduct product)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/product", product);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateProduct(Guid id, UpdateProduct product)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/product/update/{id}", product);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteSoftProduct(Guid id)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/product/deleteSoft/{id}", "");

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductEternal(Guid id)
        {
            var result = await _httpClient.DeleteAsync($"/api/product/deleteEternal/{id}");

            return result.IsSuccessStatusCode;
        }

        public async Task<List<Producted>> GetListRecycleBin()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Producted>>("/api/recyclebin");

            return result;
        }

        public async Task<bool> Resrote(Guid id)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/recyclebin/{id}", "");

            return result.IsSuccessStatusCode;
        }
    }
}
