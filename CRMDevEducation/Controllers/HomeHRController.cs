using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using business.Models;
using business.WSHR;
using CRMDevEducation.Models.Input;
using CRMDevEducation.Models.Mapping;
using CRMDevEducation.Models.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRMDevEducation.Controllers
{
    [Authorize(Roles = "HR, HeadHR")]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeHRController : ControllerBase
    {
        DefaultHR manager;
        DefaultHR Hmanager;

        public HomeHRController()
        {
            manager = new HRManager();
            Hmanager = new HeadHR(manager);
        }

        [HttpGet]
        public string Get()
        {
           

           
            //string q = Request.Headers["1"];

            
            List<IModelOutput> models = new List<IModelOutput>();
            string json = "";
            foreach (TeacherBusinessModel model in manager.GetTeacher())
            {
                json += JsonSerializer.Serialize<OutputTeacherModel>(TeacherMappingBusinessToOutput.Map(model));
                models.Add(TeacherMappingBusinessToOutput.Map(model));
            }
            foreach (LeadBusinessModel model in manager.GetLead())
            {
                json += JsonSerializer.Serialize<OutputLeadModel>(LeadMappingBusinessToOutput.Map(model));
                models.Add(LeadMappingBusinessToOutput.Map(model));
            }
            return json;
        }
        [Route("CreateLead")]
        [HttpPost]
        public string CreateLead(InputLeadModel model)
        {
            if (manager.CreateLead(LeadMappingInputToBusness.Map((model))))
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }


    }
}