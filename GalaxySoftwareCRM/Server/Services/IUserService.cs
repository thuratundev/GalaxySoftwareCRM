using GalaxySoftwareCRM.Shared.Models;

namespace GalaxySoftwareCRM.Server.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest user);
    }
}
