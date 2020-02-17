using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
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
        public HomeMaxTeacherController()
        {
            teacher = new MaxHeadTeacherManager(new NormalTeacherManager(Convert.ToInt32(User.Identity.Name)));
        }

        [HttpGet]
        public string Get()
        {
            string q = Request.Headers["Authorization"];
            string json = "";
            foreach (GroupBusinessModel item in teacher.GetAllGroupe())
            {
                json += JsonSerializer.Serialize<OutputGroupModel>(GroupMappingBusinessToOutput.Map(item));
            }
            return json;
        }

        [HttpPost]
        [Route("AddSkillForLead")]
        public string AddSkillForLead([FromBody] InputSkillsForLeadModel model)
        {
            LeadBusinessModel lead = teacher.AddSkillsForLead(SkillsForLeadMappingInputToBusiness.Map(model));

            return JsonSerializer.Serialize<OutputLeadModel>(LeadMappingBusinessToOutput.Map(lead));

        }

    }
}