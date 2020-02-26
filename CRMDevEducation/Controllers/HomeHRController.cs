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
    [Authorize(Roles = "HR")]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeHRController : ControllerBase
    {
        HRManager manager;

        [HttpGet]
        public string Get(int statusId)
        {
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                manager = (HRManager)StorageToken.GetManager(Request.Headers["Authorization"]);
                string json = "";
                foreach (TeacherBusinessModel model in manager.GetTeacher())
                {
                    json += JsonSerializer.Serialize<OutputTeacherModel>(TeacherMappingBusinessToOutput.Map(model));    
                }
                foreach (LeadBusinessModel model in manager.GetLeadsByStatus(statusId))
                {
                    json += JsonSerializer.Serialize<OutputLeadModel>(LeadMappingBusinessToOutput.Map(model));
                }
                return json;
            }
            else
            {
                return "Bad Login";
            }
        }

        [Route("Filtr")]
        [HttpGet]
        public string GetByFiltr(InputFiltrLeadModel lead)
        {
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                manager = (HRManager)StorageToken.GetManager(Request.Headers["Authorization"]);
                string json = "";
                foreach (LeadBusinessModel model in manager.GetByFiltr(FiltrLeadMappingInputToBusiness.Map(lead)))
                {
                    json += JsonSerializer.Serialize<OutputLeadModel>(LeadMappingBusinessToOutput.Map(model));
                }
                return json;
            }
            else
                return "Bad Login";
        }

        [Route("CreateLead")]
        [HttpPost]
        public int? CreateLead(InputLeadModel model)
        {
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                manager = (HRManager)StorageToken.GetManager(Request.Headers["Authorization"]);
                int? id = manager.CreateLead(LeadMappingInputToBusness.Map((model)));
                if (id != null)        
                    return id;
                else         
                    return null;
            }
            else
                return null;
            
        }
    }
}