using GalaxySoftwareCRM.Server.JwtUtilities;
using GalaxySoftwareCRM.Shared.Models;

namespace GalaxySoftwareCRM.Server.Services
{
    public class UserService : IUserService
    {
        IJwtUtilities jwtUtilities;
        public UserService(IJwtUtilities _jwtUtilities)
        {
            this.jwtUtilities = _jwtUtilities;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest user)
        {
            AuthenticateResponse response = new AuthenticateResponse();

            response.UserId = 999;
            response.UserName = "thuratun@gmail.com";

            User _users = new User { UserId = 999, Name = "thuratun@gmail.com" };

            response.Token = jwtUtilities.GenerateToken(_users);

            return response;
        }
    }
}
