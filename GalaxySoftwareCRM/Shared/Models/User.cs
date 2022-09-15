using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySoftwareCRM.Shared.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string?  AuthToken{ get; set; }
    }
}
