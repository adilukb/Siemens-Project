using Blazor.Leaflet.OpenStreetMap.LeafletMap;
using LeafletBlazorTestRig.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

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
                Zoom = 6
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

            List<double> LatitudeList = new List<double>() { 46.358, 45.443, 47.661, 45.60, 47.655, 46.968, 45.508, 45.591, 45.408, 47.574, 47.651, 46.714, 46.679, 45.349 };
            List<double> LongitudeList = new List<double>() { 22.734, 25.572, 23.696, 24.613, 24.660, 25.55, 25.357, 25.525, 25.515, 25.117, 23.830, 23.639, 25.514, 25.545 };
            List<string> PopList = new List<string> {
               (@"<strong> Arieseni!</strong><br/> I am a popup."),
               (@"<strong> Azuga!</strong><br/> I am a popup."),
               (@"<strong> Baia Sprie!</strong><br/> I am a popup."),
               (@"<strong> Balea!</strong><br/> I am a popup."),
               (@"<strong> Borsa!</strong><br/> I am a popup."),
               (@"<strong> Borsec!</strong><br/> I am a popup."),
               (@"<strong> Bran!</strong><br/> I am a popup."),
               (@"
                <body>
                <strong><center>Statiunea Poiana Brasov<center></strong>
                <p>Partii:<br>
                <strong>Bradul</strong> (lp: 500m, da: 80m)<br>
                <strong>Drumul Rosu</strong> (lp: 5330m, da: 650m)<br>
                <strong>Kanzel</strong> (lp: 310m, da: 110m)<br>
                <strong>Lupului</strong> (lp: 2620m, da: 765m)<br>
                <strong>Ruia</strong> (lp: 550m, da: 200m)<br>
                <strong>Slalom</strong> (lp: 300m, da: 30m)<br>
                <strong>Stadion</strong> (lp: 550m, da: 200m)<br>
                <strong>Subteleferic</strong> (lp: 2860m, da: 640m)<br>
                <button class=""btn btn-success"" onclick=""window.open('https://travelminit.ro/ro/cazare/partie-de-schi-poiana-brasov','_blank')"">Cazare Poiana Brasov</button>
                <img src=""https://img.directbooking.ro/getimage.ashx?f=statiuni&w=300&file=Statiune_37_Poiana%20Brasovpoiana-brasov-iarna_0.jpg.jpg"" alt=""Statiunea Poiana Brasov"">
                </body>"),

               (@"<strong> Busteni!</strong><br/> I am a popup."),
               (@"<strong> Carlibaba!</strong><br/> I am a popup."),
               (@"<strong> Cavnic!</strong><br/> I am a popup."),
               (@"<strong> Feleacu!</strong><br/> I am a popup."),
               (@"<strong> Ciumani!</strong><br/> I am a popup."),



                (@" <strong><center>Statiunea Sinaia<center></strong>
                <p>Be not afraid of greatness.<br>
                Some are born great,<br>
                some achieve greatness,<br>
                and others have greatness thrust upon them.</p>
                 <button class=""btn btn-success"" onclick=""window.open('https://travelminit.ro/ro/cazare/partie-de-schi-poiana-brasov','_blank')"">Cazare Sinaia</button>
                <img src=""https://img.directbooking.ro/getimage.ashx?f=statiuni&w=300&file=Statiune_37_Poiana%20Brasovpoiana-brasov-iarna_0.jpg.jpg""
                alt=""Statiunea Poiana Brasov"">
                ")
                
                };
            for(int i = 0; i < LatitudeList.Count; i++)
            {
                var Test = new LatLng(LatitudeList[i], LongitudeList[i]);
                var marker = new Marker(Test, new MarkerOptions
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
                var popupContent = PopList[i];
                await marker.BindPopup(popupContent);
            }
            

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
