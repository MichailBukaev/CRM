using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using business;
using business.Models;
using business.WSHR;
using CRMDevEducation.Models.Mapping;
using CRMDevEducation.Models.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRMDevEducation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeHeadHRController : ControllerBase
    {
        DefaultHR hr;
        HeadHR manager;
        public HomeHeadHRController()
        {
            hr = new HRManager();
            manager = new HeadHR(hr);
        }


        
        [Route("GetHr")]
        [HttpGet]
        public string GetHr()
        {
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
               
                string json = "";
                foreach (HRBusinessModel model in manager.GetHR())
                {
                    json += JsonSerializer.Serialize<OutputHRModel>(HRMappingBusinessToOutput.Map(model));
                    
                }
               
                return json;
            }
            else
            {
                return "Bad Login";
            }

        }
    }
}