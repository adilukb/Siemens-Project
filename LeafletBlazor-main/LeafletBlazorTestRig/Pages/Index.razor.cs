using Blazor.Leaflet.OpenStreetMap.LeafletMap;
using LeafletBlazorTestRig.Actions;
using LeafletBlazorTestRig.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace LeafletBlazorTestRig.Pages
{
    public class IndexBase : ComponentBase, IAsyncDisposable
    {
        protected Map PositionMap;
        protected TileLayer OpenStreetMapsTileLayer;
        protected MapStateViewModel MapStateViewModel;
        protected MarkerViewModel MarkerViewModel;


        public IndexBase() : base()
        {
            var mapCentre = new LatLng(46, 25); // Centered on Romania
            MapStateViewModel = new MapStateViewModel
            {
                MapCentreLatitude = mapCentre.Lat,
                MapCentreLongitude = mapCentre.Lng,
                Zoom = 7
            };
            PositionMap = new Map("testMap", new MapOptions
            {
                Center = mapCentre,
                Zoom = MapStateViewModel.Zoom
            });
            OpenStreetMapsTileLayer = new TileLayer(
                "https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
                new TileLayerOptions
                {
                    Attribution = @"Map data &copy; <a href=""https://www.openstreetmap.org/"">OpenStreetMap</a> contributors, " +
                        @"<a href=""https://creativecommons.org/licenses/by-sa/2.0/"">CC-BY-SA</a>"
                }
            );

            MarkerViewModel = new MarkerViewModel();
            

            PositionMap.OnMoveEnd += PositionMap_OnMoveEnd;
            PositionMap.OnClick += PositionMap_OnClick;
            PositionMap.OnContextMenu += PositionMap_OnContextMenu;

        }

        protected async void GetMapState()
        {
            var mapCentre = await PositionMap.GetCenter();
            MapStateViewModel.MapCentreLatitude = mapCentre.Lat;
            MapStateViewModel.MapCentreLongitude = mapCentre.Lng;
            MapStateViewModel.Zoom = await PositionMap.GetZoom();
            MapStateViewModel.MapContainerSize = await PositionMap.GetSize();
            MapStateViewModel.MapViewPixelBounds = await PositionMap.GetPixelBounds();
            MapStateViewModel.MapLayerPixelOrigin = await PositionMap.GetPixelOrigin();
            StateHasChanged();
        }

        protected async void SetMapState()
        {
            var mapCentre = new LatLng(MapStateViewModel.MapCentreLatitude, MapStateViewModel.MapCentreLongitude);
            await PositionMap.SetView(mapCentre, MapStateViewModel.Zoom);
        }
        protected async void AddMarkerAtMapCenter()
        {

            LatLng latLng = null;
            
            var action = new MarkersAction();
            var markers = await action.GetMarkers();

            for(int i = 1; i < markers.Length; i++)
            {
                latLng = new LatLng(markers[i].Latitude, markers[i].Longitude);
                MarkerViewModel = markers[i];
                var marker = new Marker(latLng, new MarkerOptions
                {
                    Keyboard = MarkerViewModel.Keyboard,
                    Title = MarkerViewModel.Title,
                    Alt = MarkerViewModel.Alt,
                    ZIndexOffset = MarkerViewModel.ZIndexOffset,
                    Opacity = MarkerViewModel.Opacity,
                    RiseOnHover = MarkerViewModel.RiseOnHover,
                    RiseOffset = MarkerViewModel.RiseOffset,
                });
                await marker.AddTo(PositionMap);
                var popupContent = $"{MarkerViewModel.Title}";
                await marker.BindPopup(popupContent);
                await marker.DisposeAsync();
            }
      
        }
        private static string serviceUrl = "http://localhost:5000";
        protected async void PositionMap_OnContextMenu(object sender, LeafletMouseEventArgs e)
        {

            var mapCentre = e.LatLng;
            await PositionMap.SetView(mapCentre, 12);
            var action = new MarkersAction();
            var newmarker = new Marker(e.LatLng, new MarkerOptions
            {
                Keyboard = MarkerViewModel.Keyboard,
                Title = MarkerViewModel.Title,
                Alt = MarkerViewModel.Alt,
                ZIndexOffset = MarkerViewModel.ZIndexOffset,
                Opacity = MarkerViewModel.Opacity,
                RiseOnHover = MarkerViewModel.RiseOnHover,
                RiseOffset = MarkerViewModel.RiseOffset,
            });
            var http = new HttpClient();
            http.BaseAddress = new Uri("https://localhost:5000");
            http.DefaultRequestHeaders.Accept.Clear();
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            await newmarker.AddTo(PositionMap);

            string tasksUrl = $"{serviceUrl}/markers";
            var contactJson = JsonConvert.SerializeObject(e.LatLng);
            var stringContent = new StringContent(contactJson, UnicodeEncoding.UTF8, "application/json");
            var response = await http.PostAsJsonAsync(tasksUrl, newmarker);
            var popupContent = $"{e.LatLng}";
            await newmarker.BindPopup(popupContent);
            await newmarker.DisposeAsync();
        }  
        private void PositionMap_OnMoveEnd(object sender, EventArgs e)
        {
            Console.WriteLine("Map_OnMoveEnd");
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            AddMarkerAtMapCenter();
            return Task.CompletedTask;
        }

        private void PositionMap_OnClick(object sender, LeafletMouseEventArgs e)
        {
            Console.WriteLine("Map_OnClick");
        }

        private void PositionMap_OnDoubleClick(object sender, LeafletMouseEventArgs e)
        {
            Console.WriteLine("Map_OnDoubleClick");
        }

        public async ValueTask DisposeAsync()
        {
            await OpenStreetMapsTileLayer.DisposeAsync();
            await PositionMap.DisposeAsync();
        }

    }
}
