using business.Models;
using business.Models.CutModel;
using CRMDevEducation.Models.Input;
using CRMDevEducation.Models.Mapping.MappingCutModel;
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
            List<CutLeadBusinessModel> leads = new List<CutLeadBusinessModel>();
            foreach (CutLeadInputModel item in model.Leads)
            {
                leads.Add(CutLeadMappingInputToBusiness.Map(item));
            }
            List<string> history = new List<string>();
            history.Add(model.History);
            return new GroupBusinessModel()
            {
                Id = model.Id,
                Name = model.NameGroup,
                Course = new CutCourseBusinessModel() { Id = model.CourseId },
                Teacher = new CutTeacherBusinessModel() { Id = model.TeacherId },
                Leads = leads,
                StartDate = model.StartDate,
                HistoryGroup = history
                
            };
        }        
    }
}
