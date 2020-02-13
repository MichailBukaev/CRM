using business.Models;
using CRMDevEducation.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping
{
    public class TeacherMappingBusinessToOutput
    {
        public static OutputTeacherModel Map(TeacherBusinessModel model)
        {
            return new OutputTeacherModel()
            {
                Id = model.Id,
                FName = model.FName,
                SName = model.SName,
                PhoneNumber = model.PhoneNumber
            };
        }
    }
}
