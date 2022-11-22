using BlazorWebAssemblyApp.Components;
using BlazorWebAssemblyApp.Services;
using BlazorWebAssemblyApp.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels;
using WebModels.Pagination; 
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorWebAssemblyApp.Pages
{
    public partial class ProductList
    {
        [Inject] private IProductApiClient productApiClient { get; set; }
        [Inject] public IToastService ToastService { get; set; }
        [Inject] public NavigationManager navigationManager { get; set; }

        private List<Producted> Products { get; set; }
        private StatusResponse statusResponse { get; set; }

        public MetaData MetaData { get; set; } = new MetaData();

        public PagingParameter paging { get; set; } = new PagingParameter();

        [CascadingParameter]
        private Error Error { set; get; }

        // Popup Delete Product
        protected Confirmation DeleteConfirmation { set; get; }

        private Guid DeleteId { set; get; }

        // Popup Product Detail
        protected ProductDetail productDetail { get; set; }

        private Guid DetailId { get; set; }

        public Producted producted { get; set; } = new Producted();

        //Popup Product Edit
        protected ProductEdit productEdit { get; set; }
        
        private Guid EditId { get; set; }

        public UpdateProduct updateProduct { get; set; } = new UpdateProduct();

        // xac thuc nguoi dung
        [CascadingParameter]
        Task<AuthenticationState> authenticationState { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (!(await authenticationState).User.Identity.IsAuthenticated)
            {
                navigationManager.NavigateTo("/login");
            }
            await GetProducts();
        }

        private async Task GetProducts()
        {
            try
            {
                var pagingReponse = await productApiClient.GetList(paging);
                //statusResponse = pagingReponse.statusResponse;
                //if (statusResponse.StatusCode == 401)
                //{
                //    navigationManager.NavigateTo("/login");
                //}
                Products = pagingReponse.Items;
                MetaData = pagingReponse.metaData;
            }
            catch (Exception ex)
            {
                Error.ProcessError(ex);
            }
        }

        private async Task SelectedPage(int page)
        {
            paging.PageNumber = page;
            await GetProducts();
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
                await productApiClient.DeleteSoftProduct(DeleteId);
                await GetProducts();
            }
        }

        public async Task<Producted> Detail(string id)
        {
            return await productApiClient.GetDetail(id);
        }

        public async Task ShowDetail(Guid ID)
        {
            DetailId = ID;
            producted = await Detail(DetailId.ToString());
            productDetail.Show();
        }

        public async Task ShowPopupEdit(Guid ID)
        {
            EditId = ID;
            var editProduct = await Detail(EditId.ToString());
            updateProduct.Id = editProduct.Id;
            updateProduct.Name = editProduct.Name;
            updateProduct.Price = editProduct.Price;
            productEdit.Show();
        }

        public async Task OnConfirmEdit(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                var result = await productApiClient.UpdateProduct(EditId, updateProduct);
                if (result)
                {
                    ToastService.ShowSuccess($"{updateProduct.Name} has been updated successfully.", "Success");
                    await GetProducts();
                }
                else
                {
                    ToastService.ShowError($"An error occurred in progress. Please contact to administrator.", "Error");
                }
            }
        }
    }
}
