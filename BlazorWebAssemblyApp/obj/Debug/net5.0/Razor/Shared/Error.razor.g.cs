#pragma checksum "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Shared\Error.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e5a06c8c30758b4b69ff0a006e568cb8b428a21b"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorWebAssemblyApp.Shared
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
#line 1 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Shared\Error.razor"
using Microsoft.Extensions.Logging;

#line default
#line hidden
#nullable disable
    public partial class Error : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __Blazor.BlazorWebAssemblyApp.Shared.Error.TypeInference.CreateCascadingValue_0(__builder, 0, 1, 
#nullable restore
#line 5 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Shared\Error.razor"
                      this

#line default
#line hidden
#nullable disable
            , 2, (__builder2) => {
                __builder2.AddContent(3, 
#nullable restore
#line 6 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Shared\Error.razor"
     ChildContent

#line default
#line hidden
#nullable disable
                );
            }
            );
        }
        #pragma warning restore 1998
#nullable restore
#line 9 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Shared\Error.razor"
       
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    public void ProcessError(Exception ex)
    {
        ToastService.ShowError("Error happen in progress");

        Logger.LogError("Error:ProcessError - Type: {Type} Message: {Message}",
            ex.GetType(), ex.Message);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IToastService ToastService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILogger<Error> Logger { get; set; }
    }
}
namespace __Blazor.BlazorWebAssemblyApp.Shared.Error
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateCascadingValue_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, TValue __arg0, int __seq1, global::Microsoft.AspNetCore.Components.RenderFragment __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.CascadingValue<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Value", __arg0);
        __builder.AddAttribute(__seq1, "ChildContent", __arg1);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591