﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MarkerProperties
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
