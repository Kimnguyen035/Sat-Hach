using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels;

namespace BlazorWebAssemblyApp.Services
{
    public interface IUserRepository
    {
        Task<List<Usered>> GetListUser();
    }
}
