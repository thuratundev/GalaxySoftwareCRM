using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySoftwareCRM.Shared.Models
{
    public class Township : BaseModel
    {
        public Int16 TownshipId { get; set; }

        public string? ShortDesc { get; set; }

        public string? Name { get; set; }
    }
}
