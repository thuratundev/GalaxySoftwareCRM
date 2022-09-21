using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySoftwareCRM.Shared.Models
{
    public class AuthenticateRequest
    {
      
        public string? UserName { get; set; }

        public string? UserMail { get; set; }

        public string? Password { get; set; }
    }
}
