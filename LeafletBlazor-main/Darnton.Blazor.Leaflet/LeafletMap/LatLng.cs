﻿using Microsoft.JSInterop;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blazor.Leaflet.OpenStreetMap.LeafletMap
{
    /// <summary>
    /// A point with a latitude and longitude.
    /// <see href="https://leafletjs.com/reference-1.7.1.html#latlng"/>
    /// </summary>
    public class LatLng : InteropObject
    {
        /// <summary>
        /// Latitude in degrees.
        /// </summary>
        [JsonPropertyName("lat")]
        public double Lat { get; set; }
        /// <summary>
        /// Longitude in degrees.
        /// </summary>
        [JsonPropertyName("lng")]
        public double Lng { get; set; }

        /// <summary>
        /// Constructs a LatLng
        /// </summary>
        /// <param name="lat">Latitude in degrees.</param>
        /// <param name="lng">Longitude in degrees.</param>
        public LatLng(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }

        /// <inheritdoc/>
        protected override async Task<IJSObjectReference> CreateJsObjectRef()
        {
            return await JSBinder.JSRuntime.InvokeAsync<IJSObjectReference>("L.latLng", Lat, Lng);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"({Lat}, {Lng})";
        }
    }
}
