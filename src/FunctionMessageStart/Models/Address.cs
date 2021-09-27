using System;
using System.Collections.Generic;

#nullable disable

namespace FunctionMessageStart.Models
{
    public partial class Address
    {
        public string Street { get; set; }
        public int? Number { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public long Id { get; set; }
        public long LocationId { get; set; }
    }
}
