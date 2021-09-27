using System;
using System.Collections.Generic;
using System.Text;

namespace Evaluation.Services.GeoCode.Infrastructure.Entities
{
    public class Coordinates
    {
        public long Id { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
