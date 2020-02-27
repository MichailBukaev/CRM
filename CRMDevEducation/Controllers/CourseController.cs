using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using business;
using business.Models;
using business.WSTeacher.HeadTeacher;
using business.WSUser.interfaces;
using CRMDevEducation.Models.Input;
using CRMDevEducation.Models.Mapping;
using CRMDevEducation.Models.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRMDevEducation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        IUserManager _manager;
        
        [Authorize(Roles = "HR, HeadHR, Teacher, HeadTeacher")]
        [HttpGet]
        public string Get(int id)
        {
            _manager = StorageToken.GetManager(Request.Headers["Authorization"]);
            string json = "";
            if (_manager != null && StorageToken.Check(Request.Headers["Authorization"]))
            {
                json += JsonSerializer.Serialize<OutputCourseModel>(CourseMappingBusinessToOutpot.Map((CourseBusinessModel)_manager.GetCourse(id)));
            }
            return json;
        }

        [Authorize(Roles = "HeadTeacher")]
        [HttpPost]
        public HttpResponseMessage PostTeacherToCourse(int _courseId, int _teacherId)
        {
            MaxHeadTeacherManager _manager = (MaxHeadTeacherManager)StorageToken.GetManager(Request.Headers["Authorization"]);
            
            if (_manager != null && StorageToken.Check(Request.Headers["Authorization"]))
            {
                bool result = _manager.AssignTeacherForCourse(_teacherId, _courseId);
                if(result)
                    return new HttpResponseMessage(HttpStatusCode.OK);
                else return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            else 
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}