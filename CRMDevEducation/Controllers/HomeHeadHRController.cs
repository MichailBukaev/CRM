using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using business;
using business.WSHR;
using CRMDevEducation.Models.Input;
using CRMDevEducation.Models.Mapping;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CRMDevEducation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeHeadHRController : ControllerBase
    {
        DefaultHR hr; 
        HeadHR manager;
        public HomeHeadHRController()
        {
            hr = new HRManager();
            manager = new HeadHR(hr);
        }

        [Route("CreateGroup")]
        [HttpPost]
        public string CreateGroup(InputGroupModel model)
        {
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                if (manager.CreateGroup(GroupMappingInputToBusiness.Map(model)))
                {
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            else
            {
                return "Bad Login";
            }
        }

        [Route("DeleteGroup")]
        [HttpPost]
        public string DeleteGroup(InputGroupModel model)
        {
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                if (manager.DeleteGroup(GroupMappingInputToBusiness.Map(model)))
                {
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            else
            {
                return "Bad Login";
            }
        }
    }
}