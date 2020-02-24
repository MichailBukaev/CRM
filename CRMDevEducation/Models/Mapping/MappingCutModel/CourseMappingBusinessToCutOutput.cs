
using business.Models;
using CRMDevEducation.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping.MappingCutModel
{
    public static class CourseMappingBusinessToCutOutput
    {
        public static CutCourseOutputModel Map(CourseBusinessModel model)
        {
            return new CutCourseOutputModel()
            {
                Id = model.Id,
                Name = model.Name,
            };
        }
    }
}
