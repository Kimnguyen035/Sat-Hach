// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorWebAssemblyApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\_Imports.razor"
using BlazorWebAssemblyApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\_Imports.razor"
using BlazorWebAssemblyApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\_Imports.razor"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Pages\ProductDetail.razor"
using BlazorWebAssemblyApp.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Pages\ProductDetail.razor"
using WebModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Pages\ProductDetail.razor"
using BlazorWebAssemblyApp.Services;

#line default
#line hidden
#nullable disable
    public partial class ProductDetail : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 103 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Pages\ProductDetail.razor"
       
    [Parameter]
    public string Id { set; get; }

    private Producted detail { set; get; }

    protected bool ShowConfirmation { get; set; }

    [Parameter]
    public EventCallback<bool> ConfirmationChanged { get; set; }

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

    //protected async override Task OnInitializedAsync()
    //{
    //    detail = await productApiClient.GetDetail(Id);
    //}

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IProductApiClient productApiClient { get; set; }
    }
}
#pragma warning restore 1591
