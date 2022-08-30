using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySoftwareCRM.Shared
{
    public class Customer
    {     
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string? ShortDesc { get; set; }
        public string? Contact { get; set; }
        public string? Address { get; set; }
        public int? TownshipId { get; set; }
    }
}
