﻿using System.Collections.Generic;

namespace WebClient.Models
{

    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Geometry
    {
        public Location location { get; set; }
    }

    public class Result
    {
        public Geometry geometry { get; set; }
    }

    public class GeoCoding
    {
        public List<Result> results { get; set; }
    }
}