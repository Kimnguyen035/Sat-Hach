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
using Microsoft.AspNetCore.Authorization;


namespace BlazorWebAssemblyApp.Pages
{
    public partial class ProductList
    {
        [Inject] private IProductApiClient productApiClient { get; set; }

        private List<Producted> Products { get; set; }

        protected Confirmation DeleteConfirmation { set; get; }

        protected ProductDetail productDetail { get; set; }

        private Guid DeleteId { set; get; }

        public PagingParameter paging { get; set; } = new PagingParameter();

        public MetaData MetaData { get; set; } = new MetaData();

        [CascadingParameter]
        private Error Error { set; get; }

        private Guid DetailId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetProducts();
        }

        private async Task GetProducts()
        {
            try
            {
                var pagingReponse = await productApiClient.GetList(paging);
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

        public async Task ShowDetail(Guid ID)
        {
            DetailId = ID;
            await productApiClient.GetDetail(DetailId.ToString());
            productDetail.Show();
        }

        public async Task OnConfirmDeleteTask(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await productApiClient.DeleteSoftProduct(DeleteId);
                await GetProducts();
            }
        }

        public async Task OnConfirmDetail(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {

            }
        }
    }
}
