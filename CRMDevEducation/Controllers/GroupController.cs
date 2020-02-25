using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using business;
using business.Models;
using business.WSHR;
using business.WSTeacher;
using business.WSTeacher.HeadTeacher;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRMDevEducation.Controllers
{
    [Authorize(Roles = "Teacher, HeadTeacher, HR, HeadHR")]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        HeadHR _headHR;
        HRManager _hr;
        NormalTeacherManager _teacher;
        MaxHeadTeacherManager _headTeacher;


        //показать журнал teacher, hr
        [HttpGet]
        public string GetLog()
        {
            string json = "";
            return json;
        }
        //показать группу teacher, hr
        [HttpGet]
        public string GetGroup(int groupId)
        {
            string json = "";
            _teacher = (NormalTeacherManager)StorageToken.GetManager(Request.Headers["Authorization"]);
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
                foreach (TaskWorkBusinessModel item in teacherManager.GetMyselfTask())
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
            return json;
        }
        //добавить комментарий группе ?
        [HttpPost]
        public string PostComment()
        {
            string json = "";
            return json;
        }
        //добавить дату в журнал teacher
        [HttpPost]
        public string PostLog()
        {
            string json = "";
            return json;
        }
    }
}