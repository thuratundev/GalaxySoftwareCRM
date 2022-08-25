using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GalaxySoftwareCRM.Server.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        public  IActionResult GetData(int param)
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
    }
}
