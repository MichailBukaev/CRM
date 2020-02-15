using business.Models;
using CRMDevEducation.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping
{
    public class GroupMappingBusinessToOutput
    {
        public static OutputGroupModel Map(GroupBusinessModel model)
        {
            List<OutputLeadModel> leads = new List<OutputLeadModel>();
            foreach(LeadBusinessModel item in model.Leads)
            {
                leads.Add(LeadMappingBusinessToOutput.Map(item));
            }
            return new OutputGroupModel()
            {
                NameGroup = model.Name,
                CourseId = model.CourseId,
                TeacherId = model.TeacherId,
                CourseName = model.CourseName,
                LeadsInGroup = leads
            };            
        }
        
    }
}
