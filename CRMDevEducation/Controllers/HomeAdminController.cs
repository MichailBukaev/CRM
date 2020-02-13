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

namespace CRMDevEducation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeAdminController : ControllerBase
    {
        AdminManager manager;
        public HomeAdminController()
        {
            manager = new AdminManager();
        }
        [Authorize]
        [HttpGet]
        public string Get()
        {
            if (User.Identity.Name == "admin")
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
                return "Are u dont horoshiy chelovecheks";
            }
            
        }

        
        [HttpPost]
        [Route("CreateHR")]
        public string CreateHr([FromBody] InputHRModel model)
        {
            if (manager.CreateHR(HRMappingInputToBusiness.Map(model)))
            {
                return "true";
            } else
            {
                return "false";
            }
           
        }

        [HttpPost]
        [Route("CreateTeacher")]
        public string CreatTeacher([FromBody] InputTeacherModel model)
        {
            if (manager.CreateTeacher(TeacherMappingInputToBusiness.Map(model)))
            {
                return "true";
            }
            else
            {
                return "false";
            }
            // json = JsonSerializer.Serialize<HR>(manager.());
        }



    }
}