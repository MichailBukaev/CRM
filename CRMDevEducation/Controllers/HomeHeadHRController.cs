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
        [Route("CreateGroup")]
        [HttpPost]
        public string CreateGroup(InputGroupModel model)
        {
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                if (manager.CreateGroup(GroupMappingInputToBusiness.Map(model)))
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

        [Route("DeleteGroup")]
        [HttpPost]
        public string DeleteGroup(InputGroupModel model)
        {
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                if (manager.DeleteGroup(GroupMappingInputToBusiness.Map(model)))
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