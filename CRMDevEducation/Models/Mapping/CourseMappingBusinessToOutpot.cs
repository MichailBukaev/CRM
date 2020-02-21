using business.Models;
using CRMDevEducation.Models.Mapping.MappingCutModel;
using CRMDevEducation.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping
{
    public class CourseMappingBusinessToOutpot
    {
        public static OutputCourseModel Map(CourseBusinessModel model)
        {
            List<CutTeacherOutputModel> teahers = new List<CutTeacherOutputModel>();
            foreach (CutTeacherBusinessModel item in model.Teachers)
            {
                teahers.Add(CutTeacherMappingBusinessToOutput.Map(item));
            };

            return new OutputCourseModel()
            {
                Id = model.Id,
                Name = model.Name,
                CourseInfo = model.CourseInfo,
                Teachers = teahers
            };
        }
    }
}
