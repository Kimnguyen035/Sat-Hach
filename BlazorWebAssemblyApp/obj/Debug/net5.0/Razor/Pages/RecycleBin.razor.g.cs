#pragma checksum "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Pages\RecycleBin.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6beff7803af515a81f870cebfb06413625a10af"
// <auto-generated/>
#pragma warning disable 1591
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
#line 2 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Pages\RecycleBin.razor"
using BlazorWebAssemblyApp.Pages.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Pages\RecycleBin.razor"
using BlazorWebAssemblyApp.Components;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/recycle")]
    public partial class RecycleBin : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 5 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Pages\RecycleBin.razor"
 if (RecycleBins == null)
{

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<BlazorWebAssemblyApp.Components.LoadingIndicator>(0);
            __builder.CloseComponent();
#nullable restore
#line 8 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Pages\RecycleBin.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(1, "<h3>Recycle Bin</h3>");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "row mt-4");
            __builder.OpenElement(4, "table");
            __builder.AddAttribute(5, "class", "table");
            __builder.AddMarkupContent(6, "<thead><tr><th>Name</th>\r\n                    <th>Price</th>\r\n                    <th>Create date</th>\r\n                    <th>Edit date</th></tr></thead>\r\n            ");
            __builder.OpenElement(7, "tbody");
#nullable restore
#line 24 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Pages\RecycleBin.razor"
                 foreach (var item in RecycleBins)
                {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(8, "tr");
            __builder.OpenElement(9, "td");
            __builder.AddContent(10, 
#nullable restore
#line 27 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Pages\RecycleBin.razor"
                             item.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n                        ");
            __builder.OpenElement(12, "td");
            __builder.AddContent(13, 
#nullable restore
#line 28 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Pages\RecycleBin.razor"
                             item.Price

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n                        ");
            __builder.OpenElement(15, "td");
            __builder.AddContent(16, 
#nullable restore
#line 29 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Pages\RecycleBin.razor"
                             item.Created_at

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n                        ");
            __builder.OpenElement(18, "td");
            __builder.AddContent(19, 
#nullable restore
#line 30 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Pages\RecycleBin.razor"
                             item.Updated_at

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n                        ");
            __builder.OpenElement(21, "td");
            __builder.OpenElement(22, "button");
            __builder.AddAttribute(23, "class", "btn btn-primary");
            __builder.AddAttribute(24, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 32 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Pages\RecycleBin.razor"
                                                                      () => OnRestore(item.Id)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(25, "Restore");
            __builder.CloseElement();
            __builder.AddMarkupContent(26, " | \r\n                            ");
            __builder.OpenElement(27, "button");
            __builder.AddAttribute(28, "class", "btn btn-danger");
            __builder.AddAttribute(29, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 33 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Pages\RecycleBin.razor"
                                                                     () => OnDeleteProduct(item.Id)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(30, "Delete");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 36 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Pages\RecycleBin.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.OpenComponent<BlazorWebAssemblyApp.Components.Confirmation>(31);
            __builder.AddAttribute(32, "ConfirmationMessage", "Are you sure to delete?");
            __builder.AddAttribute(33, "ConfirmationTitle", "Delete Product");
            __builder.AddAttribute(34, "ConfirmationChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, 
#nullable restore
#line 44 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Pages\RecycleBin.razor"
                                       OnConfirmDeleteTask

#line default
#line hidden
#nullable disable
            )));
            __builder.AddComponentReferenceCapture(35, (__value) => {
#nullable restore
#line 43 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Pages\RecycleBin.razor"
                        DeleteConfirmation = (BlazorWebAssemblyApp.Components.Confirmation)__value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseComponent();
#nullable restore
#line 47 "C:\Users\ASUS\Desktop\WebApplication\BlazorWebAssemblyApp\Pages\RecycleBin.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591