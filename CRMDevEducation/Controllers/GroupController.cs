using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using business;
using business.Models;
using business.WSHR;
using business.WSTeacher;
using business.WSTeacher.HeadTeacher;
using business.WSUser.interfaces;
using CRMDevEducation.Models.Input;
using CRMDevEducation.Models.Mapping;
using CRMDevEducation.Models.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;


namespace CRMDevEducation.Controllers
{
    [Authorize(Roles = "Teacher, HeadTeacher, HR, HeadHR")]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        IUserManager _manager;

        [HttpGet]
        public string GetGroup(int groupId)
        {
            string json = "";
            _manager = StorageToken.GetManager(Request.Headers["Authorization"]);
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                GroupBusinessModel item = (GroupBusinessModel)_manager.GetGroup(groupId);
                json += JsonSerializer.Serialize<OutputGroupModel>(GroupMappingBusinessToOutput.Map(item));
            }
            else
            {
                return "You do not have access to this page :(";
            }

            return json;
        }

        //добавить препода в группу
        [Authorize(Roles ="Teacher, HeadTeacher")]
        [HttpPost]
        public HttpResponseMessage AddLog([FromBody] InputDayInLogModel log)
        {
            NormalTeacherManager manager = (NormalTeacherManager)StorageToken.GetManager(Request.Headers["Authorization"]);
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                if (manager.SetAttendence(DayInLogMappingInputToBusiness.Map(log)))
                    return new HttpResponseMessage(HttpStatusCode.OK);
                else
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            else
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

       
    }
}