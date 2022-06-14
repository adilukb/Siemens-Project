﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksServices.Model
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

    }
}



