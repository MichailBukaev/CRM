using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using business.Models;
using business.WSAdmin;
using CRMDevEducation.Models.Input;
using CRMDevEducation.Models.Mapping;
using CRMDevEducation.Models.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using business;

namespace CRMDevEducation.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeAdminController : ControllerBase
    {
        AdminManager manager;
        public HomeAdminController()
        {
            manager = new AdminManager();
        }
        
        [HttpGet]
        public string Get()
        {
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                string json = "";
                foreach (HRBusinessModel model in manager.GetHR())
                {
                    json += JsonSerializer.Serialize<OutputHRModel>(HRMappingBusinessToOutput.Map(model));
                }
                foreach (TeacherBusinessModel model in manager.GetTeacher())
                {
                    json += JsonSerializer.Serialize<OutputTeacherModel>(TeacherMappingBusinessToOutput.Map(model));
                }
                return json;
            }
            else
            {
                return "Bad Login";
            }
        }

        [HttpPost]
        [Route("CreateHR")]
        public string CreateHr([FromBody] InputHRModel model)
        {
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                if (manager.CreateHR(HRMappingInputToBusiness.Map(model)) != null)
                {
                    return (StorageToken.GetId(Request.Headers["Authorization"]).ToString());
                } else
                {
                    return "false";
                }
            }
            else
            {
                return "Bad Login";
            }

        }
       
        [HttpPost]
        [Route("CreateTeacher")]
        public string CreateTeacher([FromBody] InputTeacherModel model)
        {
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                if (manager.CreateTeacher(TeacherMappingInputToBusiness.Map(model)) != null)
                {
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            else
            {
                return "Bad Login";
            }
        }



    }
}