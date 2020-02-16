using business.Models;
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
            List<OutputTeacherModel> teahers = new List<OutputTeacherModel>();
            foreach(TeacherBusinessModel item in model.Teachers)
            {
                teahers.Add(TeacherMappingBusinessToOutput.Map(item));
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
