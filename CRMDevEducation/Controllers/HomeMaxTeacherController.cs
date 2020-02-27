using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using business;
using business.Cache;
using business.Models;
using business.WSTeacher;
using business.WSTeacher.Cache;
using business.WSTeacher.HeadTeacher;
using CRMDevEducation.Models.Input;
using CRMDevEducation.Models.Mapping;
using CRMDevEducation.Models.Mapping.MappingCutModel;
using CRMDevEducation.Models.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRMDevEducation.Controllers
{
    [Authorize(Roles = "HeadTeacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeMaxTeacherController : ControllerBase
    {
        MaxHeadTeacherManager teacher;
       
        [HttpGet]
        public string Get()
        {
            teacher = (MaxHeadTeacherManager)StorageToken.GetManager(Request.Headers["Authorization"]);
            string json = "";
           
            foreach (GroupBusinessModel item in teacher.GetAllGroupe())
            {
                json += JsonSerializer.Serialize<OutputGroupModel>(GroupMappingBusinessToOutput.Map(item));
            }
            foreach (CourseBusinessModel item in teacher.GetAllCourse())
            {
                json += JsonSerializer.Serialize<CutCourseOutputModel>(CourseMappingBusinessToCutOutput.Map(item));
            }
            if (!teacher.Cache.Teachers.FlagActual)
                ReconstructorTeacherManagerCache.UpdateCacheTeachers(teacher.Cache.Teachers, teacher.Teacher);
            foreach (TeacherBusinessModel item in teacher.Cache.Teachers.Teachers.Where(p => p.Id != teacher.Teacher.Id))
            {
                json += JsonSerializer.Serialize<CutTeacherOutputModel>(TeacherMappingBusinessToCutOutput.Map(item));
            }
            List<string> tasksStatusesName = new List<string>() 
            {
                Settings.StatusTask.ToDo.ToString(),
                Settings.StatusTask.InProgress.ToString(),
                Settings.StatusTask.Urgently.ToString()
            };
            foreach(string itemStatus in tasksStatusesName)
            {
                foreach (TaskWorkBusinessModel item in teacher.GetAllMyTask(itemStatus))
                {
                    TasksStatusBusinessModel tasksStatus = teacher.Cache.TasksStatus.TasksStatus.FirstOrDefault(p => p.Id == item.TasksStatusId);
                    json += JsonSerializer.Serialize<OutputTaskWorkModel>(TaskWorkMappingBusinessToOutput.Map(item, tasksStatus));
                }
            }
            foreach (TaskWorkBusinessModel item in teacher.GetAllTasksForSlaves(DateTime.Now.AddDays(-7)))
            {
                TasksStatusBusinessModel tasksStatus = teacher.Cache.TasksStatus.TasksStatus.FirstOrDefault(p => p.Id == item.TasksStatusId);
                json += JsonSerializer.Serialize<OutputTaskWorkModel>(TaskWorkMappingBusinessToOutput.Map(item, tasksStatus));
            }

            if (!teacher.Cache.Status.FlagActual)
                ReconstructorTeacherManagerCache.UpdateCacheStatus(teacher.Cache.Status);
            foreach (TasksStatusBusinessModel item in teacher.Cache.TasksStatus.TasksStatus)
            {
                json += JsonSerializer.Serialize<OutputTaskStatusModel>(TasksStatusMappingBusinessToOutput.Map(item));
            }
            return json;
        }
           
        [Route("AddNewSkill")]
        [HttpPost]
        public int? CreateNewSkill([FromBody] InputSkillModel model)
        {
            teacher = (MaxHeadTeacherManager)StorageToken.GetManager(Request.Headers["Authorization"]);
            int? idNewskill = teacher.AddNewSkill(SkillMappingInputToBusiness.Map(model)); 
            return idNewskill;
        }


        [Route("AddNewCourse")]
        [HttpPost]
        public int? CreateNewCourse([FromBody] InputCourseModel model)
        {
            teacher = (MaxHeadTeacherManager)StorageToken.GetManager(Request.Headers["Authorization"]);
            int? courseId = teacher.AddNewCourse(CourseMappingInputToBusiness.Map(model)); 
            return courseId;
        }

        [Route("SetSelfTask")]
        [HttpPost]
        public int? SetSelfTaskWork([FromBody] InputSelfTaskModel model)
        {
            teacher = (MaxHeadTeacherManager)StorageToken.GetManager(Request.Headers["Authorization"]);
            int? taskId = teacher.SetSelfTask(task: model.Task, deadLine: model.DeadLine, tasksStatusId: model.TasksStatusId);
            return taskId;
        }

        [Route("SetTaskForTeacher")]
        [HttpPost]
        public int? SetTaskWork([FromBody] InputTaskModel model)
        {
            teacher = (MaxHeadTeacherManager)StorageToken.GetManager(Request.Headers["Authorization"]);
            int? taskWorkId = teacher.SetTasksForSlaves(model.Task, model.DeadLine, model.TasksStatusId, model.loginExecuter);
            return taskWorkId;
        }

    }
}