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
            PositionMap.OnContextMenu += PostMarkerOnRightClick;

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

            foreach(var variablemarker in markers) 
            {
                latLng = new LatLng(variablemarker.Latitude, variablemarker.Longitude);
                /*MarkerViewModel = markers[i];*/
                var marker = new Marker(latLng, new MarkerOptions
                {
                    Keyboard = variablemarker.Keyboard,
                    Title = variablemarker.Title,
                    Alt = variablemarker.Alt,
                    ZIndexOffset = variablemarker.ZIndexOffset,
                    Opacity = variablemarker.Opacity,
                    RiseOnHover = variablemarker.RiseOnHover,
                    RiseOffset = variablemarker.RiseOffset                   
                });
                await marker.AddTo(PositionMap);

                var popupContent = (@"
                <body>
                <strong><center>" + variablemarker.Title + @"<center></strong>
                <p>Partii:<br>
                <strong>" + variablemarker.Slope1 + @"<br></strong>
                <strong>" + variablemarker.Slope2 + @"<br></strong>
                <strong>" + variablemarker.Slope3 + @"<br></strong>
                <strong>" + variablemarker.Slope4 + @"<br></strong>
                <button class=""btn btn-success"" onclick=""window.open('" + variablemarker.Link + @"','_blank')"">Cazare</button>
                <img src=""" + variablemarker.Image + @""" alt=""Image"" width=""200"" height=""120"">
                </body>");
                
                await marker.BindPopup(popupContent);
                await marker.DisposeAsync();
            }
            
        }
        protected async void PostMarkerOnRightClick(object sender, LeafletMouseEventArgs e)
        {
            var url = "http://localhost:5000/markers";
            var jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            LatLng latLng = null;
            
            var mapCentre = e.LatLng;
            latLng = new LatLng(mapCentre.Lat, mapCentre.Lng);
            await PositionMap.SetView(mapCentre, 12);
            
            var httpClient = new HttpClient();        
            var markerOn = new Marker(mapCentre, new MarkerOptions
            {
                Keyboard = MarkerViewModel.Keyboard,
                Title = MarkerViewModel.Title,
                Alt = MarkerViewModel.Alt,
                ZIndexOffset = MarkerViewModel.ZIndexOffset,
                Opacity = MarkerViewModel.Opacity,
                RiseOnHover = MarkerViewModel.RiseOnHover,
                RiseOffset = MarkerViewModel.RiseOffset,
                
            });

            var newmarker = new MarkerViewModel
            {
                Title = MarkerViewModel.Title,
                Latitude = mapCentre.Lat,
                Longitude = mapCentre.Lng,
                Slope1 = MarkerViewModel.Slope1,
                Slope2 = MarkerViewModel.Slope2,
                Slope3 = MarkerViewModel.Slope3,
                Slope4 = MarkerViewModel.Slope4,
                Link = MarkerViewModel.Link,
                Image = MarkerViewModel.Image
            };
            
            var contactJson = JsonConvert.SerializeObject(newmarker);
            var response = await httpClient.PostAsJsonAsync(url, newmarker);
                if (response.IsSuccessStatusCode)
                {
                    var id = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(id);
                }
            var marker = JsonSerializer.Deserialize<List<MarkerViewModel>>(
                    await httpClient.GetStringAsync(url),
                    jsonSerializerOptions);

            await markerOn.AddTo(PositionMap);
            var popupContent = (@"
                <body>
                <strong><center>" + MarkerViewModel.Title + @"<center></strong>
                <p>Partii:<br>
                <strong>" + MarkerViewModel.Slope1 + @"<br></strong>
                <strong>" + MarkerViewModel.Slope2 + @"<br></strong>
                <strong>" + MarkerViewModel.Slope3 + @"<br></strong>
                <strong>" + MarkerViewModel.Slope4 + @"<br></strong>
                <button class=""btn btn-success"" onclick=""window.open('" + MarkerViewModel.Link + @"','_blank')"">Cazare</button>
                <img src=""" + MarkerViewModel.Image + @""" alt=""Image"" width=""200"" height=""120"">
                </body>");
            MarkerViewModel.Title = String.Empty;
            await markerOn.BindPopup(popupContent);
            await markerOn.DisposeAsync();

        }

        protected async void GetMarkerById()
        {
            LatLng latLng = null;
            var action = new MarkersAction();
            var markers = await action.GetMarkersById(7);
            latLng = new LatLng(markers.Latitude, markers.Longitude);
            await PositionMap.SetView(latLng, 12);
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
