using GalaxySoftwareCRM.Server.Services;
using GalaxySoftwareCRM.Shared.Models;

namespace GalaxySoftwareCRM.Server.JwtUtilities
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate requestDelegate;
        public JwtMiddleware(RequestDelegate _requestDelegate)
        {
            requestDelegate = _requestDelegate;
        }

        public async Task Invoke(HttpContext context,IJwtUtilities jwtUtilities)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtilities.ValidateToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                //  context.Items["User"] = userService.GetById(userId.Value);

                context.Items["User"] = new User { UserId = 999, Name = "thuratun@gmail.com" };
            }

            await requestDelegate(context);
        }
    }
}
