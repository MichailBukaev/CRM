using business.Models;
using CRMDevEducation.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping
{
    public class TaskWorkMappingBusinessToOutput
    {
        internal static OutputTaskWorkModel Map(TaskWorkBusinessModel model, TasksStatusBusinessModel statusModel)
        {
            OutputTaskStatusModel outputTaskStatus = TasksStatusMappingBusinessToOutput.Map(statusModel);
            OutputTaskWorkModel task = new OutputTaskWorkModel()
            {
                Id = model.Id,
                LoginAuthor = model.LoginAuthor,
                LoginExecuter = model.LoginExecuter,
                DateStart = model.DateStart,
                DateEnd = model.DateEnd,
                Text = model.Text,
                TasksStatus = outputTaskStatus
            };
            return task;
        }
    }
}
