using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using business;
using business.Models;
using business.WSTeacher;
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
        public HomeMaxTeacherController()
        {
            
        }

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
            foreach (TaskWorkBusinessModel item in teacher.GetMyselfTask())
            {
                TasksStatusBusinessModel tasksStatus = teacher.Cache.TasksStatus.TasksStatus.FirstOrDefault(p => p.Id == item.TasksStatusId);
                json += JsonSerializer.Serialize<OutputTaskWorkModel>(TaskWorkMappingBusinessToOutput.Map(item, tasksStatus));
            }
            return json;
        }

       /* [HttpPost]
        public IActionResult CreateLog([FromBody] InputDayInLogModel model)
        {
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                bool flag = teacher.SetAttendence(DayInLogMappingInputToBusiness.Map(model)); // изменить возвращаемое значение чтобы можно было вывести то что мы заполнили
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
        public IActionResult CreateNewSkill([FromBody] InputSkillModel model)
        {
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                int? flag = teacher.AddNewSkill(SkillMappingInputToBusiness.Map(model)); // изменить возвращаемое значение чтобы можно было вывести то что мы заполнили
                if (flag != null)
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
        }*/

        [HttpPost]
        public IActionResult CreateNewCourse([FromBody] InputCourseModel model)
        {
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                int? flag = teacher.AddNewCourse(CourseMappingInputToBusiness.Map(model)); // изменить возвращаемое значение чтобы можно было вывести то что мы заполнили
                if (flag != null)
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

    }
}