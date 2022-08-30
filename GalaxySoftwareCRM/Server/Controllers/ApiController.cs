using GalaxySoftwareCRM.Server.DataAccess;
using GalaxySoftwareCRM.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace GalaxySoftwareCRM.Server.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        [Route("demo")]
        public  IActionResult GetDemo(int param)
        {
            if(param == 0)
            {
                var json = new
                {
                    starttime = DateTimeOffset.Now,
                    duration = TimeSpan.FromMilliseconds(10000)
                };
                return new JsonResult(value: json);
            }
            else
            {
                return RedirectToPage("/Error");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> PostData([FromBody] JsonElement request)
        {
            dynamic? result = null;

            ApiHelper requestHelper = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiHelper?>(request.ToString()) ?? new();

            if (requestHelper.IsStoredProcedure)
            {
                if (requestHelper.SqlExecutionType == SqlExecutionTypes.ExecuteOnly)
                {
                    result =  await DbHelper.SetDataByProcedure(requestHelper.StoredProcedureName, requestHelper.Parameters);
                  
                }
                else if (requestHelper.SqlExecutionType == SqlExecutionTypes.ExecuteResult)
                {
                    result = await DbHelper.GetDataByProcedure(requestHelper.StoredProcedureName, requestHelper.Parameters);
                }
            }          
            return Ok(result);
        }
    }
}
