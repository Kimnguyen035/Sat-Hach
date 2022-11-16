using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebModels;

namespace BlazorWebAssemblyApp.Services
{
    public class UserRepository : IUserRepository
    {
        public HttpClient _httpClient;

        public UserRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Usered>> GetListUser()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Usered>>("/api/user");

            return result;
        }
    }
}
