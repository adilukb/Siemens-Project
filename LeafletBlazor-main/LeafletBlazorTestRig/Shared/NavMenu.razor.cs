using Blazor.Leaflet.OpenStreetMap.LeafletMap;
using LeafletBlazorTestRig.Actions;
using LeafletBlazorTestRig.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace LeafletBlazorTestRig.Shared
{
    public partial class Index : ComponentBase
    {
        protected Map PositionMap;
        protected TileLayer OpenStreetMapsTileLayer;
        protected MapStateViewModel MapStateViewModel;
        protected MarkerViewModel MarkerViewModel;

        public Index() : base()
        {
            MarkerViewModel = new MarkerViewModel();
        }
        protected async void GetMarkerById()
        {
            LatLng latLng = null;
            var action = new MarkersAction();
            var markers = await action.GetMarkersById(7);
            latLng = new LatLng(markers.Latitude, markers.Longitude);
            await PositionMap.SetView(latLng, 12);
        }

    }
}
