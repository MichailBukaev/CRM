using business.Models;
using CRMDevEducation.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping
{
    public class CourseMappingInputToBusiness
    {
        public static CourseBusinessModel Map(InputCourseModel model)
        {
            return new CourseBusinessModel()
            {
                Id = model.Id,
                Name = model.Name,
                CourseInfo = model.CourseInfo
            };
        }
    }
}
