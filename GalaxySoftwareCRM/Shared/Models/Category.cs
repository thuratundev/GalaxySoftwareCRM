using GalaxySoftwareCRM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySoftwareCRM.Shared
{
    public class Category : BaseModel
    {
        public int categoryid { get; set; }

        public string? name { get; set; }

        public string? shortdesc { get; set; }
    }
}
