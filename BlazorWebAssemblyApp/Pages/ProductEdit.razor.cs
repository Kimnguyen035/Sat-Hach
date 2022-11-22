using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels;
using BlazorWebAssemblyApp.Services;
using Blazored.Toast.Services;
using Microsoft.JSInterop;

namespace BlazorWebAssemblyApp.Pages
{
    public partial class ProductEdit
    {
        [Inject] public IToastService ToastService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IJSRuntime jSRuntime { get; set; }

        [Parameter]
        public string Id { set; get; }

        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }

        [Parameter]
        public UpdateProduct productEdit { get; set; }

        protected bool ShowConfirmation { get; set; }

        public void Show()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }

        protected async Task OnConfirmationChange(bool value)
        {
            ShowConfirmation = false;
            await ConfirmationChanged.InvokeAsync(value);
        }

        public async Task OnValidSubmit()
        {
            var jsModule = await jSRuntime.InvokeAsync<IJSObjectReference>("import", "./Script/productEdit.js");
            await jsModule.InvokeVoidAsync("updateProduct", productEdit.Id, productEdit);
        }
    }
}
