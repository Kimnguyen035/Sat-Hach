using BlazorWebAssemblyApp.Components;
using BlazorWebAssemblyApp.Services;
using BlazorWebAssemblyApp.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels;

namespace BlazorWebAssemblyApp.Pages
{
    public partial class RecycleBin
    {
        [Inject] private IProductApiClient productApiClient { get; set; }
        [Inject] private IAuthService authService { get; set; }
        [Inject] NavigationManager navigationManager { get; set; }

        private List<Producted> RecycleBins { get; set; }

        protected Confirmation DeleteConfirmation { set; get; }

        private Guid DeleteId { set; get; }

        [CascadingParameter]
        private Error Error { set; get; }

        [CascadingParameter]
        Task<AuthenticationState> authenticationState { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (!(await authenticationState).User.Identity.IsAuthenticated)
            {
                navigationManager.NavigateTo("/login");
            }
            await GetRecycleBin();
        }

        private async Task GetRecycleBin()
        {
            try
            {
                RecycleBins = await productApiClient.GetListRecycleBin();
            }
            catch (Exception ex)
            {
                Error.ProcessError(ex);
            }
        }

        public async Task OnRestore(Guid Id)
        {
            DeleteId = Id;
            await productApiClient.Resrote(DeleteId);
            await GetRecycleBin();
        }

        public void OnDeleteProduct(Guid deleteId)
        {
            DeleteId = deleteId;
            DeleteConfirmation.Show();
        }

        public async Task OnConfirmDeleteTask(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await productApiClient.DeleteProductEternal(DeleteId);
                await GetRecycleBin();
            }
        }
    }
}
