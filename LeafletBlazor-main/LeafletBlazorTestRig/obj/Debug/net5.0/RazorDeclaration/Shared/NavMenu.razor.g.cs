// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace LeafletBlazorTestRig.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
#nullable restore
#line 1 "C:\Users\adiluk\Desktop\dupli\Siemens-Project\LeafletBlazor-main\LeafletBlazorTestRig\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\adiluk\Desktop\dupli\Siemens-Project\LeafletBlazor-main\LeafletBlazorTestRig\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\adiluk\Desktop\dupli\Siemens-Project\LeafletBlazor-main\LeafletBlazorTestRig\_Imports.razor"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\adiluk\Desktop\dupli\Siemens-Project\LeafletBlazor-main\LeafletBlazorTestRig\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\adiluk\Desktop\dupli\Siemens-Project\LeafletBlazor-main\LeafletBlazorTestRig\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\adiluk\Desktop\dupli\Siemens-Project\LeafletBlazor-main\LeafletBlazorTestRig\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\adiluk\Desktop\dupli\Siemens-Project\LeafletBlazor-main\LeafletBlazorTestRig\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\adiluk\Desktop\dupli\Siemens-Project\LeafletBlazor-main\LeafletBlazorTestRig\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\adiluk\Desktop\dupli\Siemens-Project\LeafletBlazor-main\LeafletBlazorTestRig\_Imports.razor"
using Blazor.Leaflet.OpenStreetMap.LeafletMap;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\adiluk\Desktop\dupli\Siemens-Project\LeafletBlazor-main\LeafletBlazorTestRig\_Imports.razor"
using LeafletBlazorTestRig;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\adiluk\Desktop\dupli\Siemens-Project\LeafletBlazor-main\LeafletBlazorTestRig\_Imports.razor"
using LeafletBlazorTestRig.Shared;

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 18 "C:\Users\adiluk\Desktop\dupli\Siemens-Project\LeafletBlazor-main\LeafletBlazorTestRig\Shared\NavMenu.razor"
       
    private bool collapseNavMenu = true;

    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
