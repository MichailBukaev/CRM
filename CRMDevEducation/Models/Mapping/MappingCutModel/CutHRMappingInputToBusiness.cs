using business.Models.CutModel;
using CRMDevEducation.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping.MappingCutModel
{
    public class CutHRMappingInputToBusiness
    {
        public static CutHRBusinessModel Map(CutHRInputModel model)
        {
            return new CutHRBusinessModel()
            {
                Id = model.Id,
                FName = model.FName,
                SName = model.SName,
            };
        }
    }
}
