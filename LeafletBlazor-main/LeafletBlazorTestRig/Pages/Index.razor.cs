using Blazor.Leaflet.OpenStreetMap.LeafletMap;
using LeafletBlazorTestRig.Actions;
using LeafletBlazorTestRig.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Threading.Tasks;

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
            var mapCentre = new LatLng(-42, 175); // Centred on New Zealand
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

            //var div = @"
            //<div style=""background-color: #00000088; border-radius: 10px; padding: 16px;width: 80px"">
            //    <img src=""leaf-red.png""/>
            //</div>
            //";

            //var divIcon = new DivIcon(new DivIconOptions() { Html = div });

            // var icon = new Icon(new IconOptions()
            // {
            //     IconUrl = "leaf-orange.png",
            //     IconSize = new Point(64, 64)
            // });

            //var marker = new Marker(mapCentre, new MarkerOptions
            //{
            //    Keyboard = MarkerViewModel.Keyboard,
            //    Title = MarkerViewModel.Title,
            //    Alt = MarkerViewModel.Alt,
            //    ZIndexOffset = MarkerViewModel.ZIndexOffset,
            //    Opacity = MarkerViewModel.Opacity,
            //    RiseOnHover = MarkerViewModel.RiseOnHover,
            //    RiseOffset = MarkerViewModel.RiseOffset,
            //});

            //await marker.AddTo(PositionMap);
            ////await icon.AddTo(marker);
            //await divIcon.AddTo(marker);


            LatLng latLng = null;
            
            var action = new MarkersAction();
            var markers = await action.GetMarkers();


            
                        //var mapCentre = await PositionMap.GetCenter();
            for(int i = 0; i < markers.Length; i++)
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
                var popupContent = $"<strong>Hello - {MarkerViewModel.Title}!</strong><br />I am a popup.";
                await marker.BindPopup(popupContent);
            }


            //var action = new MarkersAction();
            //var str = await action.GetMarkers();
            //if (str.Length > 0)
            //{
            //    this.InputValue = str[0].Title;
            //}




            //TODO: implement popup object
            //var popup = new PopUp();
            //await popup.SetContent(marker, "sfdsgds");

        }


        private void PositionMap_OnMoveEnd(object sender, EventArgs e)
        {
            Console.WriteLine("Map_OnMoveEnd");
        }


        private void PositionMap_OnClick(object sender, LeafletMouseEventArgs e)
        {
            Console.WriteLine("Map_OnClick");

        }

        public async ValueTask DisposeAsync()
        {
            await OpenStreetMapsTileLayer.DisposeAsync();
            await PositionMap.DisposeAsync();
        }

    }
}
