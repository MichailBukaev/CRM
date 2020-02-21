using business.Models.CutModel;
using CRMDevEducation.Models.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping.MappingCutModel
{
    public class CutCourseMappingInputToBusiness
    {
        public static CutCourseBusinessModel Map(CutCourseInputModel model)
        {            
            return new CutCourseBusinessModel()
            {
                Id = model.Id,
                Name = model.Name,                
            };
        }
    }
}
