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
            teacher = new MaxHeadTeacherManager(new NormalTeacherManager(StorageToken.GetID(Request.Headers["Authorization"])));
            string json = "";
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                foreach (GroupBusinessModel item in teacher.GetAllGroupe())
                {
                    json += JsonSerializer.Serialize<OutputGroupModel>(GroupMappingBusinessToOutput.Map(item));
                }
                return json;
            }
            return "Bad Login";
        }

        //[HttpPost]
        //[Route("AddSkillForLead")]
        //public string AddSkillForLead([FromBody] InputSkillsForLeadModel model)
        //{
        //    teacher.AddSkillsForLead(SkillsForLeadMappingInputToBusiness.Map(model));
            
        //}

    }
}