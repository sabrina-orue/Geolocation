using System;
using System.Collections.Generic;

#nullable disable

namespace Evaluation.Services.Infrastructure.Entities
{
    public partial class Location
    {
        public Location()
        {
            Addresses = new HashSet<Address>();
        }

        public long Id { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
