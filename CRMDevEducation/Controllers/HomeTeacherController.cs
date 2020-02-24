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
using business.WSTeacher;
using business.WSTeacher.HeadTeacher;
using CRMDevEducation.Models.Input;
using CRMDevEducation.Models.Mapping;
using CRMDevEducation.Models.Mapping.MappingCutModel;
using CRMDevEducation.Models.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace CRMDevEducation.Controllers
{
    [Authorize(Roles = "Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeTeacherController : ControllerBase
    {
        NormalTeacherManager teacherManager = null;

        public HomeTeacherController()
        {
            
        }
        [HttpGet]
        public string Get()
        {
            teacherManager = (NormalTeacherManager)StorageToken.GetManager(Request.Headers["Authorization"]);
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                string json = "";
                foreach (GroupBusinessModel item in teacherManager.GetAllGroupe())
                {
                    json += JsonSerializer.Serialize<OutputGroupModel>(GroupMappingBusinessToOutput.Map(item));
                }
                foreach (CourseBusinessModel item in teacherManager.GetAllCourse())
                {
                    json += JsonSerializer.Serialize<CutCourseOutputModel>(CourseMappingBusinessToCutOutput.Map(item));
                }
                foreach(TaskWorkBusinessModel item in teacherManager.GetMyselfTask())
                {
                    TasksStatusBusinessModel tasksStatus = teacherManager.Cache.TasksStatus.TasksStatus.FirstOrDefault(p => p.Id == item.TasksStatusId);
                    json += JsonSerializer.Serialize<OutputTaskWorkModel>(TaskWorkMappingBusinessToOutput.Map(item, tasksStatus));
                }
                return json;
            }
            else
            {
                return "You do not have access to this page :(";
            }
        }
        //этот метод доджен быть в контроллере лида
        [Route("AddSkillsForLead")]
        [HttpPost]
        public HttpResponseMessage AddSkillsForLead(int leadId, int skillId)
        {
            if (teacherManager==null)
                teacherManager = (NormalTeacherManager)StorageToken.GetManager(Request.Headers["Authorization"]);
            if (teacherManager.AddSkillsForLead(skillId, leadId))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }




    }
}