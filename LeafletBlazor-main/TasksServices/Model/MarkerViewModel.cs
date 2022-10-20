using System.ComponentModel.DataAnnotations;

namespace TasksServices.Model
{
    public class MarkerViewModel
    {
        [Key]
        public int Id { get; set; }
        public bool Keyboard { get; set; } = true;
        [Required]
        public string Title { get; set; }
        public string Alt { get; set; }
        public int ZIndexOffset { get; set; }
        public double Opacity { get; set; } = 1.0f;
        public bool RiseOnHover { get; set; }
        public int RiseOffset { get; set; } = 250;
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }

    }
}



