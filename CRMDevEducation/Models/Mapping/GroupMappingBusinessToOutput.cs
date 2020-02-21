using business.Models;
using business.Models.CutModel;
using CRMDevEducation.Models.Mapping.MappingCutModel;
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
            List<CutLeadOutputModel> leads = new List<CutLeadOutputModel>();
            foreach (CutLeadBusinessModel item in model.Leads)
            {
                leads.Add(CutLeadMappingBusinessToOutput.Map(item));
            }

            CutCourseOutputModel course = CutCourseMappingBusinessToOutput.Map(model.Course);
            CutTeacherOutputModel teacher = CutTeacherMappingBusinessToOutput.Map(model.Teacher);

            return new OutputGroupModel()
            {
                Id = model.Id,
                NameGroup = model.Name,                
                Teacher = teacher,
                Course = course,
                StartData = model.StartDate,
                Leads = leads
            };
        }
    }
}
