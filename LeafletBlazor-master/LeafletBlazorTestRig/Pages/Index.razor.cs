using Darnton.Blazor.Leaflet.LeafletMap;
using LeafletBlazorTestRig.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;

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

       
        protected async void AddMarkerData()
        {

         


          /*  SQLiteConnection FileSQL;
            FileSQL = new SQLiteConnection("Data Source = ./DataBaseSQL.db");

            using var SQLConnectData = new SQLiteConnection(FileSQL);*/

            using (var SQLConnectData = new SQLiteConnection("Data Source = DataBaseSQL.db"))
            {
                SQLConnectData.Open();

        
                string statementQuery = "SELECT * FROM MarkerData";

                using var commandSQL = new SQLiteCommand(statementQuery, SQLConnectData);
                using SQLiteDataReader readerSQL = commandSQL.ExecuteReader();

                List<int> LatitudeList  = new List<int>();
                List<int> LongitudeList = new List<int>();


                while (readerSQL.Read())
                {
                    LatitudeList.Add(readerSQL.GetInt32(0));
                    LongitudeList.Add(readerSQL.GetInt32(1));
                }

                for (int i = 0; i < LatitudeList.Count; i++)
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
            }



            //List implementation
            /*   List<int> LatitudeList = new List<int>() { 44, 42, 43, 45, 46, 67 };
               List<int> LongitudeList = new List<int>() { 22, 2, 23, 45, 36, 27 };


               for (int i = 0; i < LatitudeList.Count; i++)
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

               }*/




        }
        

        public async ValueTask DisposeAsync()
        {
            await OpenStreetMapsTileLayer.DisposeAsync();
            await PositionMap.DisposeAsync();
        }
    }
}
