using GalaxySoftwareCRM.Shared.Models;
using System.Net.Http;
using System.Text.Json;

namespace GalaxySoftwareCRM.Client.Services
{
    public class AuthService 
    {
     public AuthenticateResponse CurrentUser { get; set; }
    }
}
