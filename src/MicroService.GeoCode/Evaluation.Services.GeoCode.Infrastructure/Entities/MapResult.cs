using System;
using System.Collections.Generic;
using System.Text;

namespace Evaluation.Services.GeoCode.Infrastructure.Entities
{
    public class MapResult
    {
        public string Type { get; set; }
        public string Licence { get; set; }
        public List<Feature> Features { get; set; }
    }
    
    public class Feature
    {
        public string Type { get; set; }
        public dynamic Properties { get; set; }
        public List<double> Bbox { get; set; }
        public List<Geometry> Geometry { get; set; }
    }

    public class Geometry
    {
        public string Type { get; set; }
        public List<double> Coordinates { get;set;}
    }
   
}
    
