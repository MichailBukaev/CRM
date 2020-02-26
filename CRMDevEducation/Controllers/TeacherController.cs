using business;
using business.Models;
using business.WSHR;
using business.WSHR.Cache;
using business.WSTeacher.Cache;
using business.WSTeacher.HeadTeacher;
using business.WSUser.interfaces;
using CRMDevEducation.Models.Input;
using CRMDevEducation.Models.Mapping;
using CRMDevEducation.Models.Mapping.MappingCutModel;
using CRMDevEducation.Models.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;

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
            TeacherBusinessModel teacher = (TeacherBusinessModel)_manager.GetTacher(teacherId);
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                json += JsonSerializer.Serialize<OutputTeacherModel>(TeacherMappingBusinessToOutput.Map(teacher));
                if (StorageToken.GetRole(Request.Headers["Authorization"]) == "HeadTeacher"|| StorageToken.GetRole(Request.Headers["Authorization"]) == "Teacher")
                {
                    MaxHeadTeacherManager normalTeacher = (MaxHeadTeacherManager)_manager;
                    if (!normalTeacher.Cache.Group.FlagActual)
                        ReconstructorTeacherManagerCache.UpdateCacheGroup(normalTeacher.Cache.Group, normalTeacher.Teacher);
                    foreach (GroupBusinessModel model in normalTeacher.Cache.Group.Groups)
                    {
                        json += JsonSerializer.Serialize<CutGroupOutputModel>(GroupeMappingBusinessToCutOutput.Map(model));

                    }
                    if (!normalTeacher.Cache.Course.FlagActual)
                        ReconstructorTeacherManagerCache.UpdateCacheCourses(normalTeacher.Cache.Course, normalTeacher.Teacher);
                    foreach (CourseBusinessModel model in normalTeacher.Cache.Course.Courses)
                    {
                        json += JsonSerializer.Serialize<CutCourseOutputModel>(CourseMappingBusinessToCutOutput.Map(model));
                    }
                    List<TaskWorkBusinessModel> tasks = normalTeacher.GetAllTasksForSlaves(teacher.Login, DateTime.Now.AddDays(-30));
                    foreach (TaskWorkBusinessModel item in tasks)
                    {
                        TasksStatusBusinessModel tasksStatus = normalTeacher.Cache.TasksStatus.TasksStatus.FirstOrDefault(p => p.Id == item.TasksStatusId);
                        json += JsonSerializer.Serialize<OutputTaskWorkModel>(TaskWorkMappingBusinessToOutput.Map(item, tasksStatus));
                    }
                    List<TasksStatusBusinessModel> tasksStatuses = normalTeacher.Cache.TasksStatus.TasksStatus;
                    foreach (TasksStatusBusinessModel item in tasksStatuses)
                    {
                        json += JsonSerializer.Serialize<OutputTaskStatusModel>(TasksStatusMappingBusinessToOutput.Map(item));
                    }
                }
                else if (StorageToken.GetRole(Request.Headers["Authorization"]) == "HeadHR"|| StorageToken.GetRole(Request.Headers["Authorization"]) == "HR")
                {
                    HeadHR hr = (HeadHR)_manager;
                    if (!hr.Cache.Groups.FlagActual)
                        ReconstructorHRManagerCache.UpdateCacheGroup(hr.Cache.Groups);
                    foreach (GroupBusinessModel model in hr.Cache.Groups.Groups)
                    {
                        json += JsonSerializer.Serialize<CutGroupOutputModel>(GroupeMappingBusinessToCutOutput.Map(model));

                    }
                    if (!hr.Cache.Courses.FlagActual)
                        ReconstructorHRManagerCache.UpdateCacheCourses(hr.Cache.Courses);
                    foreach (CourseBusinessModel model in hr.Cache.Courses.Courses)
                    {
                        json += JsonSerializer.Serialize<CutCourseOutputModel>(CourseMappingBusinessToCutOutput.Map(model));
                    }
                    List<TaskWorkBusinessModel> tasks = (List<TaskWorkBusinessModel>)hr.GetTaskWorkForSlaves(teacher.Login, DateTime.Now.AddDays(-30));
                    foreach (TaskWorkBusinessModel item in tasks)
                    {
                        TasksStatusBusinessModel tasksStatus = hr.Cache.TasksStatus.TasksStatus.FirstOrDefault(p => p.Id == item.TasksStatusId);
                        json += JsonSerializer.Serialize<OutputTaskWorkModel>(TaskWorkMappingBusinessToOutput.Map(item, tasksStatus));
                    }
                    List<TasksStatusBusinessModel> tasksStatuses = hr.Cache.TasksStatus.TasksStatus;
                    foreach (TasksStatusBusinessModel item in tasksStatuses)
                    {
                        json += JsonSerializer.Serialize<OutputTaskStatusModel>(TasksStatusMappingBusinessToOutput.Map(item));
                    }
                }
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