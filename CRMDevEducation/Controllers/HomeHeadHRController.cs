using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using business;
using business.Models;
using business.WSHR;
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
    public class HomeHeadHRController : ControllerBase
    {
        HeadHR manager;
        public HomeHeadHRController(){ }

        [HttpGet]
        public string Get()
        {
            manager = (HeadHR)StorageToken.GetManager(Request.Headers["Authorization"]);
            if (StorageToken.Check(Request.Headers["Authorization"]) && manager != null)
            {
                string json = "";
                foreach (HRBusinessModel model in manager.GetHR())
                {
                    json += JsonSerializer.Serialize<OutputHRModel>(HRMappingBusinessToOutput.Map(model));

                }
                foreach (TaskWorkBusinessModel model in manager.GetTasksMyself())
                {
                    TasksStatusBusinessModel tasksStatus = manager.Cache.TasksStatus.TasksStatus.FirstOrDefault(p => p.Id == model.TasksStatusId);
                    json += JsonSerializer.Serialize<OutputTaskWorkModel>(TaskWorkMappingBusinessToOutput.Map(model, tasksStatus));
                }

                return json;
            }
            else
            {
                return "You do not have access to this page :(";
            }
        }

        [Route("CreateLead")]
        [HttpPost]
        public string CreateLead([FromBody]InputLeadModel model)
        {
            manager = (HeadHR)StorageToken.GetManager(Request.Headers["Authorization"]);
            if (StorageToken.Check(Request.Headers["Authorization"]) && manager != null)
            {
                int? id = manager.CreateLead(LeadMappingInputToBusness.Map(model));
                if (id != null)
                    return $"{id}" ;                
                else                
                    return "false";               
            }
            else            
                return "Bad Login";            
        }

        [Route("MyTasks/InTheTimeRange")]
        [HttpGet]        
        public string GetMyTask(DateTime startDate)
        {
            manager = (HeadHR)StorageToken.GetManager(Request.Headers["Autorization"]);
            if (StorageToken.Check(Request.Headers["Authorization"]) && manager != null)
            {
                string json = "";                
                foreach (TaskWorkBusinessModel model in manager.GetTasksMyself(startDate))
                {
                    TasksStatusBusinessModel tasksStatus = manager.Cache.TasksStatus.TasksStatus.FirstOrDefault(p => p.Id == model.TasksStatusId);
                    json += JsonSerializer.Serialize<OutputTaskWorkModel>(TaskWorkMappingBusinessToOutput.Map(model, tasksStatus));
                }

                return json;
            }
            else
            {
                return "You do not have access to this page :(";
            }
        }

        [Route("TasksOfExecutors")]
        [HttpGet]        
        public string GetTasksForExecutors() 
        {
            manager = (HeadHR)StorageToken.GetManager(Request.Headers["Autorization"]);
            if (StorageToken.Check(Request.Headers["Authorization"]) && manager != null)
            {
                string json = "";
                foreach (TaskWorkBusinessModel model in manager.GetTaskWorkForSlaves())
                {
                    TasksStatusBusinessModel tasksStatus = manager.Cache.TasksStatus.TasksStatus.FirstOrDefault(p => p.Id == model.TasksStatusId);
                    json += JsonSerializer.Serialize<OutputTaskWorkModel>(TaskWorkMappingBusinessToOutput.Map(model, tasksStatus));
                }

                return json;
            }
            else
            {
                return "You do not have access to this page :(";
            }
        }

        [Route("MyTasks/{nameTaskStatus}")]
        [HttpGet]        
        public string GetMyTask(string nameTaskStatus)
        {
            manager = (HeadHR)StorageToken.GetManager(Request.Headers["Autorization"]);
            if (StorageToken.Check(Request.Headers["Authorization"]) && manager != null)
            {
                string json = "";
                int statusId = manager.GetIdStatusTasks(nameTaskStatus);
                foreach (TaskWorkBusinessModel model in manager.GetTasksMyself(statusId))
                {
                    TasksStatusBusinessModel tasksStatus = manager.Cache.TasksStatus.TasksStatus.FirstOrDefault(p => p.Id == model.TasksStatusId);
                    json += JsonSerializer.Serialize<OutputTaskWorkModel>(TaskWorkMappingBusinessToOutput.Map(model, tasksStatus));
                }

                return json;
            }
            else
            {
                return "You do not have access to this page :(";
            }
        }
        
        [Route("CreateGroup")]
        [HttpPost]
        public string CreateGroup([FromBody]InputGroupModel model)
        {
            manager = (HeadHR)StorageToken.GetManager(Request.Headers["Autorization"]);
            if (StorageToken.Check(Request.Headers["Authorization"]) && manager != null)
            {
                int? id = manager.CreateGroup(GroupMappingInputToBusiness.Map(model));
                if (id != null)                
                    return $"{id}";                
                else                
                    return "false";                
            }
            else            
                return "Bad Login";            
        }

        

        [Route("SetMyTask")]
        [HttpPost]
        public string SetMyTask([FromBody]InputTaskModel task)
        {
            manager = (HeadHR)StorageToken.GetManager(Request.Headers["Autorization"]);
            if (StorageToken.Check(Request.Headers["Authorization"]) && manager != null)
            {
                if (manager.SetTaskMyself(task.Task, task.DeadLine, task.TasksStatusId) != 0)
                    return manager.SetTaskMyself(task.Task, task.DeadLine, task.TasksStatusId).ToString();
                else
                    return "false";
            }
            else
                return "You do not have access to this page :(";

        }

        [Route("SetTaskToExecutor")]
        [HttpPost]
        public string SetTaskToExecutor([FromBody]InputTaskModel task)
        {
            manager = (HeadHR)StorageToken.GetManager(Request.Headers["Autorization"]);
            if (StorageToken.Check(Request.Headers["Authorization"]) && manager != null)
            {
                if (manager.SetTasksForSlaves(task.Task, task.DeadLine, task.TasksStatusId, task.loginExecuter) != 0)
                    return manager.SetTasksForSlaves(task.Task, task.DeadLine, task.TasksStatusId, task.loginExecuter).ToString();
                else
                    return "false";
            }
            else
                return "You do not have access to this page :(";

        }

        [Route("LeadsGroupByStatus")]
        [HttpGet]
        public string GetLeadsByStatus([FromBody]InputStatusModel status)
        {
            manager = (HeadHR)StorageToken.GetManager(Request.Headers["Autorization"]);
            if (StorageToken.Check(Request.Headers["Authorization"]) && manager != null)
            {
                string json = "";
                int idStatus = manager.GetStatusId(status.Name);
                foreach (LeadBusinessModel model in manager.GetLeadsByStatus(idStatus))
                {                    
                    json += JsonSerializer.Serialize<OutputLeadModel>(LeadMappingBusinessToOutput.Map(model));
                }

                return json;
            }
            else
            {
                return "You do not have access to this page :(";
            }
        }

        [Route("Groups")]
        [HttpGet]
        public string GetGroups()
        {
            manager = (HeadHR)StorageToken.GetManager(Request.Headers["Authorization"]);
            if (StorageToken.Check(Request.Headers["Authorization"]) && manager != null)
            {
                string json = "";                
                foreach (GroupBusinessModel model in manager.GetGroups())
                {
                    json += JsonSerializer.Serialize<OutputGroupModel>(GroupMappingBusinessToOutput.Map(model));
                }

                return json;
            }
            else
            {
                return "You do not have access to this page :(";
            }
        }

        [Route("Teachers")]
        [HttpGet]
        public string GetTeachers()
        {
            manager = (HeadHR)StorageToken.GetManager(Request.Headers["Autorization"]);
            if (StorageToken.Check(Request.Headers["Authorization"]) && manager != null)
            {
                string json = "";
                foreach (TeacherBusinessModel model in manager.GetTeacher())
                {
                    json += JsonSerializer.Serialize<OutputTeacherModel>(TeacherMappingBusinessToOutput.Map(model));
                }

                return json;
            }
            else
            {
                return "You do not have access to this page :(";
            }
        }

    }
}