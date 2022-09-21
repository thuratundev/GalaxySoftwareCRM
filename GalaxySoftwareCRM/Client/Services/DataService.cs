
using GalaxySoftwareCRM.Shared;
using GalaxySoftwareCRM.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;
using System.Text.Json;

namespace GalaxySoftwareCRM.Client.Services
{
    public class DataService : IDataService
    {

        private readonly HttpClient _httpclient;

        private readonly AuthService _authservice;
        public DataService(HttpClient httpclient, AuthService authservice)
        {
            _httpclient = httpclient;
            _authservice = authservice;
        }
        public async Task<IEnumerable<T>> GetDataByProcedure<T>(ApiHelper apiHelper) where T : class
        {
            string stringapihelper = Newtonsoft.Json.JsonConvert.SerializeObject(apiHelper);

            HttpContent content = new StringContent(stringapihelper, System.Text.Encoding.UTF8, "application/json");
            _httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authservice.CurrentUser.Token);

            var httpResponseMessage = await _httpclient.PostAsync("api", content);

            // string resultstring = await httpResponseMessage.Content.ReadAsStringAsync();

            var resultstream = await httpResponseMessage.Content.ReadAsStreamAsync();


            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };


            if(resultstream.Length == 0)
            {
                return new List<T>();
            }

            /*Here, we use System.Text.Json For Only Reason for Non-blocking Async 
             */
             var resultlist = await System.Text.Json.JsonSerializer.DeserializeAsync<List<T>>(resultstream,jsonSerializerOptions) ?? new List<T>();
            return resultlist;
        }

        public async Task<T?> SetDataByProcedure<T>(ApiHelper apiHelper)
        {
            string stringapihelper = Newtonsoft.Json.JsonConvert.SerializeObject(apiHelper);

            HttpContent content = new StringContent(stringapihelper, System.Text.Encoding.UTF8, "application/json");
            _httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authservice.CurrentUser.Token);

            var httpResponseMessage = await _httpclient.PostAsync("api", content);

            

            var resultstream = await httpResponseMessage.Content.ReadAsStreamAsync();


            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            if(resultstream.Length ==0)
            {
                return default;
            }

            /*Here, we use System.Text.Json For Only Reason for Non-blocking Async 
             */
            var resultlist = await System.Text.Json.JsonSerializer.DeserializeAsync<T>(resultstream, jsonSerializerOptions);
            return resultlist;
        }

        public async Task<AuthenticateResponse> GetUserAuthentication(AuthenticateRequest request)
        {

            string stringapihelper = Newtonsoft.Json.JsonConvert.SerializeObject(request);

            HttpContent content = new StringContent(stringapihelper, System.Text.Encoding.UTF8, "application/json");
            var httpResponseMessage = await _httpclient.PostAsync("api/auth", content);



            var resultstream = await httpResponseMessage.Content.ReadAsStreamAsync();


            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            if (resultstream.Length == 0)
            {
                return default;
            }

            /*Here, we use System.Text.Json For Only Reason for Non-blocking Async 
             */
            var resultlist = await System.Text.Json.JsonSerializer.DeserializeAsync<AuthenticateResponse>(resultstream, jsonSerializerOptions);
            return resultlist;

        }

    }
}
