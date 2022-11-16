using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels;

namespace BlazorWebAssemblyApp.Services
{
    public interface IAuthService
    {
        Task Initialize();
        Usered User { get; }
        public Task<LoginResponse> GetAuth();

        Task<bool> Register(RegisterUser registerUser);
        
        Task<LoginResponse> Login(LoginRequest loginRequest);

        Task Logout();
    }
}
