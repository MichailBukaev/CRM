using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using business.WSHR;
using CRMDevEducation.Models.Input;
using CRMDevEducation.Models.Mapping;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRMDevEducation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        HRManager _manager;
        [Route("Auth")]
        [HttpPost]
        public int? Registration(InputLeadModel model)
        {
            _manager = new HRManager(1);
            int? id = _manager.CreateLead(LeadMappingInputToBusness.Map((model)));
            if (id != null)
                return id;
            else
                return null;
        }
    }
}