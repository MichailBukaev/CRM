using business.Models;
using CRMDevEducation.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping.MappingCutModel
{
    public static class TeacherMappingBusinessToCutOutput
    {
        public static CutTeacherOutputModel Map(TeacherBusinessModel model)
        {
            return new CutTeacherOutputModel() { 
                Id = model.Id, 
                FName = model.FName, 
                SName = model.SName, 
                Login = model.Login
            };

        }
    }
}
