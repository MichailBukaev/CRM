using business.Models;
using CRMDevEducation.Models.Output;
using System;

namespace CRMDevEducation.Models.Mapping
{
    internal class TasksStatusMappingBusinessToOutput
    {
        internal static OutputTaskStatusModel Map(TasksStatusBusinessModel model)
        {
            return new OutputTaskStatusModel() { 
                Id =  model.Id,
                Name = model.Name
            };

        }
    }
}