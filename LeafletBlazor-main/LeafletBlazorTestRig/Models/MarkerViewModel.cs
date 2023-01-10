using System.ComponentModel.DataAnnotations;

namespace LeafletBlazorTestRig.Models
{
    public class MarkerViewModel
    {
        public bool Keyboard { get; set; } = true;
        public string Title { get; set; }
        public string Alt { get; set; }
        public int ZIndexOffset { get; set; }
        public double Opacity { get; set; } = 1.0f;
        public bool RiseOnHover { get; set; }
        public int RiseOffset { get; set; } = 250;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Slope1 { get; set; }
        public string Slope2 { get; set; }
        public string Slope3 { get; set; }
        public string Slope4 { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }


    }

}
