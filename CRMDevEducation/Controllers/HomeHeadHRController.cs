using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using business.WSHR;
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

    }
}