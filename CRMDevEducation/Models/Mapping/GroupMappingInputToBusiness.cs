using business.Models;
using CRMDevEducation.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping
{
    public class GroupMappingInputToBusiness
    {
        public static GroupBusinessModel Map(InputGroupModel model)
        {
            return new GroupBusinessModel()
            {
                Name = model.NameGroup,
                CourseId = model.CourseId,
                TeacherId = model.TeacherId,                
                StartDate = model.StartDate,
                LeadId = model.LeadId
            };
        }        
    }
}
