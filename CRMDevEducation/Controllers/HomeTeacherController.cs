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
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                string json = "";
                foreach (GroupBusinessModel item in teacherManager.GetAllGroupe())
                {
                    json += JsonSerializer.Serialize<OutputGroupModel>(GroupMappingBusinessToOutput.Map(item));
                }
               /* foreach (LinkTeacherCourseBusinessModel item in teacherManager.GetAllCourse())
                {
                    json += JsonSerializer.Serialize<OutputLinkTeacherCorsrModel>(LinkTeacherCourseBusinessModelToOutput.Map(item));
                }*/
                return json;
            }
            else
            {
                return "Eror Auth";
            }
        }

        /*[HttpPost]
        public IActionResult CreateLog([FromBody] InputDayInLogModel model)
        {
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                bool flag = teacherManager.SetAttendence(DayInLogMappingInputToBusiness.Map(model)); // изменить возвращаемое значение чтобы можно было вывести то что мы заполнили
                if (flag)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
                return BadRequest();
        }

        [HttpPost]
        public IActionResult SetSkillForLead([FromBody] InputSkillsForLeadModel model)
        {
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                bool flag = teacherManager.AddSkillsForLead(SkillsForLeadMappingInputToBusiness.Map(model)); //вместо флага вернуть значение?
                if (flag)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }

            }
            else
                return BadRequest();
        }
*/
    }
}