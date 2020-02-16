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
using CRMDevEducation.Models.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRMDevEducation.Controllers
{
    [Authorize(Roles = "Teacher, HeadTeacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeTeacherController : ControllerBase
    {
        TeacherManager teacherManager;

        public HomeTeacherController()
        {
            teacherManager = new NormalTeacherManager(1);
            if (teacherManager.Teacher.Head)
            {
                teacherManager = new MaxHeadTeacherManager(teacherManager);
            }
        }
        [HttpGet]
        public string Get()
        {
            string q = Request.Headers["Authorization"];
            string json = "";
            foreach(GroupBusinessModel item in teacherManager.GetAllGroupe())
            {
                json += JsonSerializer.Serialize<OutputGroupModel>(GroupMappingBusinessToOutput.Map(item));
            }
            return json;
        }
    }
}