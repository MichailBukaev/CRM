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

namespace CRMDevEducation.Controllers
{
    [Route("[controller]")]
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