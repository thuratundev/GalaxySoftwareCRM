using GalaxySoftwareCRM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySoftwareCRM.Shared
{
    public class Customer : BaseModel
    {     
        public int customerid { get; set; }
        public string? name { get; set; }
        public string? shortdesc { get; set; }
        public string? contact { get; set; }
        public string? address { get; set; }
        public string? companyname { get; set; }
        public string? phone { get; set; }


        public bool iscredit { get; set; }
        public bool isinactive { get; set; }
        public bool isdeleted { get; set; }
        public bool isupdated { get; set; }

        public Guid sr { get; set; }



        public Int16? townshipid { get; set; }
        public Int16? custgroupid { get; set; }
        public Int16? userid { get; set; }




    }
}
