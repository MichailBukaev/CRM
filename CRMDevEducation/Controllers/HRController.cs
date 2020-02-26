using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using business;
using business.Models;
using business.WSHR;
using business.WSHR.Cache;
using business.WSUser.interfaces;
using CRMDevEducation.Models.Input;
using CRMDevEducation.Models.Mapping;
using CRMDevEducation.Models.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRMDevEducation.Controllers
{
    [Authorize(Roles = "HeadHR")]
    [Route("api/[controller]")]
    [ApiController]
    public class HRController : ControllerBase
    {
        private HeadHR _manager;

        [HttpGet]
        public string Get(int hrId)
        {
            _manager = (HeadHR)StorageToken.GetManager(Request.Headers["Authorization"]);
            string json = "";
            HRBusinessModel hr = (HRBusinessModel)_manager.GetHR(hrId);
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                json += JsonSerializer.Serialize<OutputHRModel>(HRMappingBusinessToOutput.Map(hr));

                List<TaskWorkBusinessModel> tasks = (List<TaskWorkBusinessModel>)_manager.GetTaskWorkForSlaves(hr.Login, DateTime.Now.AddDays(-30));
                foreach (TaskWorkBusinessModel item in tasks)
                {
                    TasksStatusBusinessModel tasksStatus = _manager.Cache.TasksStatus.TasksStatus.FirstOrDefault(p => p.Id == item.TasksStatusId);
                    json += JsonSerializer.Serialize<OutputTaskWorkModel>(TaskWorkMappingBusinessToOutput.Map(item, tasksStatus));
                }
                List<TasksStatusBusinessModel> tasksStatuses = _manager.Cache.TasksStatus.TasksStatus;
                foreach (TasksStatusBusinessModel item in tasksStatuses)
                {
                    json += JsonSerializer.Serialize<OutputTaskStatusModel>(TasksStatusMappingBusinessToOutput.Map(item));
                }
                return json;
            }        
            else
            {
                return "You do not have access to this page :(";
            }            
        }

        [HttpGet]
        public string Get(int hrId, string nameTaskStatus)
        {
            _manager = (HeadHR)StorageToken.GetManager(Request.Headers["Authorization"]);
            string json = "";
            HRBusinessModel hr = (HRBusinessModel)_manager.GetHR(hrId);
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                json += JsonSerializer.Serialize<OutputHRModel>(HRMappingBusinessToOutput.Map(hr));

                int statusId = _manager.GetIdStatusTasks(nameTaskStatus);
                foreach (TaskWorkBusinessModel model in _manager.GetTaskWorkForSlaves(hr.Login, statusId))
                {
                    TasksStatusBusinessModel tasksStatus = _manager.Cache.TasksStatus.TasksStatus.FirstOrDefault(p => p.Id == model.TasksStatusId);
                    json += JsonSerializer.Serialize<OutputTaskWorkModel>(TaskWorkMappingBusinessToOutput.Map(model, tasksStatus));
                }
                List<TasksStatusBusinessModel> tasksStatuses = _manager.Cache.TasksStatus.TasksStatus;
                foreach (TasksStatusBusinessModel item in tasksStatuses)
                {
                    json += JsonSerializer.Serialize<OutputTaskStatusModel>(TasksStatusMappingBusinessToOutput.Map(item));
                }
                return json;
            }
            else
            {
                return "You do not have access to this page :(";
            }
        }

        [Route("SetTaskWork")]
        [HttpPost]
        public int? SetTaskWork([FromBody] InputTaskModel model)
        {
            int? taskWorkId = null;
            _manager = (HeadHR)StorageToken.GetManager(Request.Headers["Authorization"]);
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                taskWorkId = _manager.SetTasksForSlaves(model.Task, model.DeadLine, model.TasksStatusId, model.loginExecuter);
            }
            
            return taskWorkId;
        }
    }
}