using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRMDevEducation.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class ExitController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            StorageToken.Delete(Request.Headers["Authorization"]);


            return RedirectToRoute("Get", "HomeAdmin");
        }
    }
}