using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace TokenAuthEmpty.Controllers
{
    [Produces("application/json")]
    [Route("api/info")]
    [Authorize(Policy = "Employee")]
    
    public class InfoController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var dict = new Dictionary<string, string>();
            HttpContext.User.Claims.ToList().ForEach(item => dict.Add(item.Type, item.Value));

            return Ok(dict);
        }


        [Authorize(Policy = "Hr")]
        public ActionResult GetSalary()
        {
            return Content("200");
        }


    }
}