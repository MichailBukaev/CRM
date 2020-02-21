using business.Models;
using CRMDevEducation.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping.MappingCutModel
{
    public class CutTeacherMappingInputToBusiness
    {
        public static CutTeacherBusinessModel Map(CutTeacherInputModel model)
        {
            return new CutTeacherBusinessModel()
            {
                Id = model.Id,
                FName = model.FName,
                SName = model.SName,
            };
        }
    }
}
