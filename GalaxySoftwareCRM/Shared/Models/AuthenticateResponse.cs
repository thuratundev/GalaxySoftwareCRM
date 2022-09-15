using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySoftwareCRM.Shared.Models
{
    public class AuthenticateResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
