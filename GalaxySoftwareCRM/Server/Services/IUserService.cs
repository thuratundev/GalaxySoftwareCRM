using GalaxySoftwareCRM.Shared.Models;

namespace GalaxySoftwareCRM.Server.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse?> Authenticate(AuthenticateRequest user);
    }
}
