using business.Models.CutModel;
using CRMDevEducation.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping.MappingCutModel
{
    public class CutCourseMappingBusinessToOutput
    {
        public static CutCourseOutputModel Map(CutCourseBusinessModel model)
        {
            return new CutCourseOutputModel()
            {
                Id = model.Id,
                Name = model.Name,
            };
        }
    }
}
