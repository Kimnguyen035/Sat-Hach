using BlazorWebAssemblyApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels;

namespace BlazorWebAssemblyApp.Pages
{
    public partial class Loginn
    {
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IAuthService AuthService { get; set; }

        private bool ShowErrors;
        private string Error = "";
        private LoginRequest LoginModel = new LoginRequest();

        private async Task HandleLogin()
        {
            ShowErrors = false;

            var result = await AuthService.Login(LoginModel);
            if (result.Successful)
            {
                NavigationManager.NavigateTo("/productList");
            }
            else
            {
                ShowErrors = true;
                Error = result.Error;
            }
        }
    }
}
