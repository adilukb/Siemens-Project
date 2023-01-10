using Blazor.Leaflet.OpenStreetMap.LeafletMap;
using LeafletBlazorTestRig.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace LeafletBlazorTestRig.Actions
{
    public class MarkersAction
    {
        private static string serviceUrl = "http://localhost:5000";

        public async Task<MarkerViewModel[]> GetMarkers()
        {
            string tasksUrl = $"{serviceUrl}/markers";

            var http = new HttpClient();
            var str = await http.GetFromJsonAsync<MarkerViewModel[]>(tasksUrl);

            Console.WriteLine(str);

            return str;

        }
        public async Task<MarkerViewModel> GetMarker()
        {
            string tasksUrl = $"{serviceUrl}/markers";

            var http = new HttpClient();
            var str = await http.GetFromJsonAsync<MarkerViewModel>(tasksUrl);

            Console.WriteLine(str);

            return str;

        }

        public async Task<MarkerViewModel> GetMarkersById(int Id)
        {
            string tasksUrl = $"{serviceUrl}/markers/{Id}";

            var http = new HttpClient();
            var str = await http.GetFromJsonAsync<MarkerViewModel>(tasksUrl);
            Console.WriteLine(str);
            return str;
        }

    }
}
