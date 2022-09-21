using GalaxySoftwareCRM.Shared.Models;

namespace GalaxySoftwareCRM.Server.JwtUtilities
{
    public interface IJwtUtilities
    {
        public string GenerateToken(AuthenticateResponse user);
        public int? ValidateToken(string token);
    }
}
