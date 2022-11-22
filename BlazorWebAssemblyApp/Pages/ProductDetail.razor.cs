using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels;

namespace BlazorWebAssemblyApp.Pages
{
    public partial class ProductDetail
    {
        [Parameter]
        public Producted detail { set; get; }

        protected bool ShowConfirmation { get; set; }

        public void Show()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }

        public void Hiden()
        {
            ShowConfirmation = false;
            StateHasChanged();
        }
    }
}
