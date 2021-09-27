using System;
using System.Collections.Generic;
using System.Text;

namespace Evaluation.Services.Domain.Models
{
    public class Location
    {
        public long Id { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Status { get; set; }
    }
}
