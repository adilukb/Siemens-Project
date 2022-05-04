using Darnton.Blazor.Leaflet.LeafletMap;
using LeafletBlazorTestRig.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using System.IO;
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
            var mapCentre = new LatLng(46, 25); // Centred on Romania
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



            /*        var path = @"C:\Users\adiluk\Desktop\project\csvTestMark.csv";
                    using (TextFieldParser csvParser = new TextFieldParser(path))
                    {

                        csvParser.SetDelimiters(new string[] { "," });
                        csvParser.HasFieldsEnclosedInQuotes = true;

                        // Skip the row with the column names
                        csvParser.ReadLine();

                    while (!csvParser.EndOfData)
                           {
                            // Read current line fields, pointer moves to the next line
                            string[] values = csvParser.ReadFields();
                            var mapIndex= new LatLng(Convert.ToDouble(values[0]), Convert.ToDouble(values[1]));
                                 var markerIndex = new Marker(mapIndex, new MarkerOptions
                                 {
                                     Keyboard = Convert.ToBoolean(values[2]),
                                     Title  = values[3],
                                     Alt = values[4],
                                     ZIndexOffset = Convert.ToInt16(values[5]),
                                     Opacity = Convert.ToDouble(values[6]),
                                     RiseOnHover = Convert.ToBoolean(values[7]),
                                     RiseOffset = Convert.ToInt16(values[8]),
                                 });        
                                 markerIndex.AddTo(PositionMap);
                             }
                        }
            */

            /*   using (var readCSV = new StreamReader(@"C:\Users\adiluk\Desktop\project\csvTestMark.csv"))
                {

                    while (!readCSV.EndOfStream)
                    {
                        var line = readCSV.ReadLine();
                        var values = line.Split(',');
                        var mapIndex= new LatLng(Convert.ToDouble(values[0]), Convert.ToDouble(values[1]));
                        var markerIndex = new Marker(mapIndex, new MarkerOptions
                        {
                            Keyboard = Convert.ToBoolean(values[2]),
                            Title  = values[3],
                            Alt = values[4],
                            ZIndexOffset = Convert.ToInt16(values[5]),
                            Opacity = Convert.ToDouble(values[6]),
                            RiseOnHover = Convert.ToBoolean(values[7]),
                            RiseOffset = Convert.ToInt16(values[8]),
                        });        
                        markerIndex.AddTo(PositionMap);
                    }
                }*/

            List<int> LatitudeList = new List<int>() { 44, 42, 43, 45, 46, 67 }; 
            List<int> LongitudeList = new List<int>() { 22, 2, 23, 45, 36, 27 }; 
            
            for(int i = 0; i < LatitudeList.Count; i++)
            {
                
                    var Test = new LatLng(LatitudeList[i], LongitudeList[i]);
                    var marktest1 = new Marker(Test, new MarkerOptions
                    {
                        Keyboard = MarkerViewModel.Keyboard,
                        Title = MarkerViewModel.Title,
                        Alt = MarkerViewModel.Alt,
                        ZIndexOffset = MarkerViewModel.ZIndexOffset,
                        Opacity = MarkerViewModel.Opacity,
                        RiseOnHover = MarkerViewModel.RiseOnHover,
                        RiseOffset = MarkerViewModel.RiseOffset,
                    });
                    await marktest1.AddTo(PositionMap);
                
            }


                /*var mapCentre = new LatLng(46, 22);
                var mapTest = new LatLng(45, 23);
                var marker1 = new Marker(mapCentre, new MarkerOptions
                {
                    Keyboard = MarkerViewModel.Keyboard,
                    Title = MarkerViewModel.Title,
                    Alt = MarkerViewModel.Alt,
                    ZIndexOffset = MarkerViewModel.ZIndexOffset,
                    Opacity = MarkerViewModel.Opacity,
                    RiseOnHover = MarkerViewModel.RiseOnHover,
                    RiseOffset = MarkerViewModel.RiseOffset,
                });
                var marker2 = new Marker(mapTest, new MarkerOptions
                {
                    Keyboard = MarkerViewModel.Keyboard,
                    Title = MarkerViewModel.Title,
                    Alt = MarkerViewModel.Alt,
                    ZIndexOffset = MarkerViewModel.ZIndexOffset,
                    Opacity = MarkerViewModel.Opacity,
                    RiseOnHover = MarkerViewModel.RiseOnHover,
                    RiseOffset = MarkerViewModel.RiseOffset,
                });
                await marker1.AddTo(PositionMap);
                await marker2.AddTo(PositionMap);*/
            

        }
        

        public async ValueTask DisposeAsync()
        {
            await OpenStreetMapsTileLayer.DisposeAsync();
            await PositionMap.DisposeAsync();
        }
    }
}
