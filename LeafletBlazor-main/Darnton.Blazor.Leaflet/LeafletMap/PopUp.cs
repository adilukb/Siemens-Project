using Microsoft.JSInterop;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Components;

namespace Blazor.Leaflet.OpenStreetMap.LeafletMap
{
    public class PopUp : InteractiveLayer
    {
        private DotNetObjectReference<PopUp> objectReference;

        protected override async Task<IJSObjectReference> CreateJsObjectRef()
        {
            return await JSBinder.JSRuntime.InvokeAsync<IJSObjectReference>("L.popup");
        }


        public async Task SetContent(Marker marker, string content)
        {
            if (JSBinder is null)
            {
                await BindJsObjectReference(marker.JSBinder);
            }
            objectReference = objectReference ?? DotNetObjectReference.Create(this);
            var module = await JSBinder.GetLeafletMapModule();
            await module.InvokeVoidAsync("LeafletMap.Popup.setContent", JSObjectReference, objectReference, content);
        }
    }
}
