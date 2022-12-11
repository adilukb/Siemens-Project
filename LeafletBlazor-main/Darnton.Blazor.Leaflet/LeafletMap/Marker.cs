using Microsoft.JSInterop;
using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blazor.Leaflet.OpenStreetMap.LeafletMap
{
    /// <summary>
    /// A clickable, draggable icon that can be added to a <see cref="Map"/>
    /// <see href="https://leafletjs.com/reference-1.7.1.html#marker"/>
    /// </summary>
    public class Marker : InteractiveLayer
    {

        private DotNetObjectReference<Marker> objectReference;

        /// <summary>
        /// The initial position of the marker.
        /// </summary>
        public LatLng LatLng { get; }
        /// <summary>
        /// The <see cref="MarkerOptions"/> used to create the marker.
        /// </summary>
        public MarkerOptions Options { get; }

        /// <summary>
        /// Constructs a marker
        /// </summary>
        /// <param name="latlng">The initial position of the marker.</param>
        /// <param name="options">The <see cref="MarkerOptions"/> used to create the marker.</param>
        public Marker(LatLng latlng, MarkerOptions options)
        {
            LatLng = latlng;
            Options = options;
        }
        

        /// <inheritdoc/>
        protected override async Task<IJSObjectReference> CreateJsObjectRef()
        {
            return await JSBinder.JSRuntime.InvokeAsync<IJSObjectReference>("L.marker", LatLng, Options);
        }


        public async Task BindPopup(string content)
        {
            objectReference = objectReference ?? DotNetObjectReference.Create(this);
            var module = await JSBinder.GetLeafletMapModule();
            await module.InvokeVoidAsync("LeafletMap.Marker.bindPopup", JSObjectReference, content);
        }

        public object Select(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}
