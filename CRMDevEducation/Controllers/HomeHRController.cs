using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using business;
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
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
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
            else
            {
                return "Bad Login";
            }
        }
        [Route("CreateLead")]
        [HttpPost]
        public string CreateLead(InputLeadModel model)
        {
            if (StorageToken.Check(Request.Headers["Authorization"]))
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
            else
            {
                return "Bad Login";
            }
        }

        [Authorize(Roles = "HeadHR")]
        [Route("CreateGroup")]
        [HttpPost]
        public string CreateGroup()
        {
            return "Ты ахуел?";
        }

    }
}