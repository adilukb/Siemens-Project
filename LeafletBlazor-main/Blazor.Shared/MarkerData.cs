using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared
{
    public class MarkerData
    {
        public int MarkerId { get; set; }
        [Required]
        public int MarkerLatitude { get; set; }
        [Required]
        public int MarkerLongitude { get; set; }
        public bool MarkerKeyboard { get; set; }
        public string MarkerAlt { get; set; }
        public int MarkerZIndexOffset { get; set; }
        public double MarkerOpacity { get; set; }
        public bool MarkerRiseOnHover { get; set; } = true;
        public int MarkerRiseOffset { get; set; }
    };

}
