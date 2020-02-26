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
    public class TeacherController : ControllerBase
    {
        private IUserManager _manager;
        [HttpGet]
        public string Get(int teacherId)
        {
            _manager = StorageToken.GetManager(Request.Headers["Authorization"]);
            string json = "";
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                json += JsonSerializer.Serialize<OutputTeacherModel>(TeacherMappingBusinessToOutput.Map((TeacherBusinessModel)_manager.GetTacher(teacherId)));
            }
            else
            {
                return "You do not have access to this page :(";
            }
            return json;
        }
        [Authorize(Roles = "HeadTeacher, HeadHR")]
        [Route("SetTaskWork")]
        [HttpPost]
        public int? SetTaskWork([FromBody] InputTaskModel model)
        {
            int? taskWorkId = null;
            _manager = StorageToken.GetManager(Request.Headers["Authorization"]);
            if(StorageToken.GetRole(Request.Headers["Authorization"]) == "HeadTeacher")
            {
                MaxHeadTeacherManager manager = (MaxHeadTeacherManager)_manager;
                taskWorkId = manager.SetTasksForSlaves(model.Task, model.DeadLine, model.TasksStatusId, model.loginExecuter);
            }
            else if(StorageToken.GetRole(Request.Headers["Authorization"]) == "HeadHR")
            {
                HeadHR manager = (HeadHR)_manager;
                taskWorkId = manager.SetTasksForSlaves(model.Task, model.DeadLine, model.TasksStatusId, model.loginExecuter);
            }
            return taskWorkId;
        }
        [Authorize(Roles = "HeadTeacher")]
        [Route("AssignForGroup")]
        [HttpPut]
        public HttpResponseMessage AssignTeacherForGroup(int teacherId, int groupeId)
        {
            MaxHeadTeacherManager manager = (MaxHeadTeacherManager)StorageToken.GetManager(Request.Headers["Authorization"]);
            if (manager.AssignTeacherForGroup(teacherId: teacherId,groupeId: groupeId))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
        [Authorize(Roles = "HeadTeacher")]
        [Route("AssignForCourse")]
        [HttpPut]
        public HttpResponseMessage AssignTeacherForCourse(int teacherId, int courseId)
        {
            MaxHeadTeacherManager manager = (MaxHeadTeacherManager)StorageToken.GetManager(Request.Headers["Authorization"]);
            if (manager.AssignTeacherForCourse(teacherId: teacherId, courseId: courseId))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }


    }
}