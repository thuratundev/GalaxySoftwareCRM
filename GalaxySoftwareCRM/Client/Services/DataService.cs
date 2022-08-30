
using GalaxySoftwareCRM.Shared;
using Microsoft.AspNetCore.Components;

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

            string resultstring = await httpResponseMessage.Content.ReadAsStringAsync();

            var resultlist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(resultstring) ?? new List<T>();

            return resultlist;
        }
    }
}
