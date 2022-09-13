using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySoftwareCRM.Shared.Models
{
    public class CustomerGroup : BaseModel
    {
        public Int16 CustGroupId { get; set; }

        public string? ShortDesc { get; set; }

        public string? Name { get; set; }
    }
}
