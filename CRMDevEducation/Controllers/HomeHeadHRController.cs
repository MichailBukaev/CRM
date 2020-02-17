using System;
using System.Collections.Generic;
using System.Linq;
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
    [Authorize (Roles = "HeadHR")]
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
        [HttpGet]
        public string Get()
        {
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                //List<IModelOutput> models = new List<IModelOutput>();
                string json = "";
                foreach (TeacherBusinessModel model in manager.GetTeacher())
                {
                    json += JsonSerializer.Serialize<OutputTeacherModel>(TeacherMappingBusinessToOutput.Map(model));
                    //models.Add(TeacherMappingBusinessToOutput.Map(model));
                }
                foreach (LeadBusinessModel model in manager.GetLead())
                {
                    json += JsonSerializer.Serialize<OutputLeadModel>(LeadMappingBusinessToOutput.Map(model));
                    //models.Add(LeadMappingBusinessToOutput.Map(model));
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

        [Route("UpdateLead")]
        [HttpPut]
        public string UpdateLead(InputLeadModel model)
        {
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                if (manager.UpdateLead(LeadMappingInputToBusness.Map((model))))
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
        [Route("DeleteLead")]
        [HttpDelete]
        public string DeleteLead(InputLeadModel model)
        {
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                if (manager.DeleteLead(LeadMappingInputToBusness.Map((model))))
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