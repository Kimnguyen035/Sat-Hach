using Blazored.Toast.Services;
using BlazorWebAssemblyApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels;

namespace BlazorWebAssemblyApp.Pages
{
    public partial class ProductCreate
    {
        [Inject] IProductApiClient productApiClient { get; set; }
        [Inject] NavigationManager navigationManager { get; set; }
        [Inject] IToastService ToastService { get; set; }

        private CreateProduct product = new CreateProduct();

        [CascadingParameter]
        Task<AuthenticationState> authenticationState { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (!(await authenticationState).User.Identity.IsAuthenticated)
            {
                navigationManager.NavigateTo("/login");
            }
        }

        private async Task SubmitTask()
        {
            var result = await productApiClient.CreateProduct(product);
            if (result)
            {
                ToastService.ShowSuccess($"{product.Name} has been created successfully.", "Success");
                navigationManager.NavigateTo("/productList");
            }
            else
            {
                ToastService.ShowError($"An error occurred in progress. Please contact to administrator.", "Error");
            }
        }
    }
}
