using GalaxySoftwareCRM.Server.DataAccess;
using GalaxySoftwareCRM.Server.JwtUtilities;
using GalaxySoftwareCRM.Shared;
using GalaxySoftwareCRM.Shared.Models;
using NpgsqlTypes;
using System.Text.Json;

namespace GalaxySoftwareCRM.Server.Services
{
    public class UserService : IUserService
    {
        IJwtUtilities jwtUtilities;
        public UserService(IJwtUtilities _jwtUtilities)
        {
            this.jwtUtilities = _jwtUtilities;
        }
        public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest user)
        {


            List<ParameterHelper>? parameters = new()
        {
            new ParameterHelper{ PsqlDbTypes = NpgsqlDbType.Varchar, PsqlParameterName = "_usermail", PsqlParameterValue =  user.UserMail, PsqlParameterDirection = System.Data.ParameterDirection.Input},
            new ParameterHelper { PsqlDbTypes = NpgsqlDbType.Varchar, PsqlParameterName = "_userpassword", PsqlParameterValue = user.Password, PsqlParameterDirection = System.Data.ParameterDirection.Input }
        };

           var result = await  DbHelper.GetDataByProcedure("usp_checkuserinfo", parameters);

            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            /*Here, we use System.Text.Json For Only Reason for Non-blocking Async 
             */
            AuthenticateResponse? response = System.Text.Json.JsonSerializer.Deserialize<List<AuthenticateResponse>>(result, jsonSerializerOptions).FirstOrDefault()?? new();

            if (response != null)
            {
                response.Token = jwtUtilities.GenerateToken(response);
            }
         
            return response;
        }
    }
}
