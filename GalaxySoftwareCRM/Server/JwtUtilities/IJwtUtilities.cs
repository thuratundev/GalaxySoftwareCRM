using GalaxySoftwareCRM.Shared.Models;

namespace GalaxySoftwareCRM.Server.JwtUtilities
{
    public interface IJwtUtilities
    {
        public string GenerateToken(User user);
        public int? ValidateToken(string token);
    }
}
