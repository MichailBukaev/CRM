using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;
using data;
using models;
using Microsoft.AspNetCore.Authorization;
using business.WSTeacher;
using business.WSUser.interfaces;
using business.WSTeacher.HeadTeacher;
using business.WSUser;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using business;
using Microsoft.AspNetCore.Mvc;
using business.Models;
using System.Text.Json;
using CRMDevEducation.Models.Output;
using CRMDevEducation.Models.Mapping;
using CRMDevEducation.Models.Input;
using System.Net.Http;
using System.Net;
using business.WSHR;

namespace CRMDevEducation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private IUserManager _manager;

        [HttpGet]
        public string Get(int id)
        {
            _manager = StorageToken.GetManager(Request.Headers["Authorization"]);
            string json = "";
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                json += JsonSerializer.Serialize<OutputLeadModel>(LeadMappingBusinessToOutput.Map((LeadBusinessModel)_manager.GetLead(id)));
            }
            else
            {
                return "You do not have access to this page :(";
            }
            return json;
        }

        [Authorize(Roles = "HeadTeacher")]
        [Route("AddSkills")]
        [HttpPut]
        public HttpResponseMessage AddSkillsForLead(int leadId, int skillId)
        {
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                NormalTeacherManager teacherManager = (NormalTeacherManager)StorageToken.GetManager(Request.Headers["Authorization"]);
                if (teacherManager.AddSkillsForLead(skillId, leadId))
                    return new HttpResponseMessage(HttpStatusCode.OK);
                else
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }else
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        [Authorize(Roles = "HR, HeadHR")]
        [Route("Change")]
        [HttpPut]
        public HttpResponseMessage Update([FromBody] InputLeadModel model)
        {
            HRManager manager = (HRManager)StorageToken.GetManager(Request.Headers["Authorization"]);
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                if (manager.UpdateLead(LeadMappingInputToBusness.Map((model))))
                    return new HttpResponseMessage(HttpStatusCode.OK);
                else
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }else
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        [Authorize(Roles = "HR, HeadHR")]
        [Route("ChangeStatus")]
        [HttpPut]
        public HttpResponseMessage ChangeStatus([FromBody] InputLeadModel model, int statusId)
        {
            HRManager manager = (HRManager)StorageToken.GetManager(Request.Headers["Authorization"]);
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                if (manager.ChangeStatus(LeadMappingInputToBusness.Map((model)), statusId))
                    return new HttpResponseMessage(HttpStatusCode.OK);
                else
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);

            }else
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    } 
}
