using business.Models;
using CRMDevEducation.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping.MappingCutModel
{
    public class CutTeacherMappingBusinessToOutput
    {
        public static CutTeacherOutputModel Map(CutTeacherBusinessModel model)
        {
            return new CutTeacherOutputModel()
            {
                Id = Convert.ToInt32(model.Id),
                FName = model.FName,
                SName = model.SName,
                Login = model.Login
            };
        }
    }
}
