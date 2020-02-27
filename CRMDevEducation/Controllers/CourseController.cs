using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using business.WSUser.interfaces;
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
        public void Get()
        {
           
        }      
    }
}