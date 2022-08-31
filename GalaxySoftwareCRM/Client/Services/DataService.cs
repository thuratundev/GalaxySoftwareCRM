
using GalaxySoftwareCRM.Shared;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace GalaxySoftwareCRM.Client.Services
{
    public class DataService : IDataService
    {

        private readonly HttpClient _httpclient;
        public DataService(HttpClient httpclient)
        {
            _httpclient = httpclient;
        }
        public async Task<IEnumerable<T>> GetDataByProcedure<T>(ApiHelper apiHelper) where T : class
        {
            string stringapihelper = Newtonsoft.Json.JsonConvert.SerializeObject(apiHelper);

            HttpContent content = new StringContent(stringapihelper, System.Text.Encoding.UTF8, "application/json");
            var httpResponseMessage = await _httpclient.PostAsync("api", content);

            // string resultstring = await httpResponseMessage.Content.ReadAsStringAsync();

            var resultstream = await httpResponseMessage.Content.ReadAsStreamAsync();


            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            /*Here, we use System.Text.Json For Only Reason for Non-blocking Async 
             */
            var resultlist = await System.Text.Json.JsonSerializer.DeserializeAsync<List<T>>(resultstream,jsonSerializerOptions) ?? new List<T>();
            return resultlist;
        }
    }
}
