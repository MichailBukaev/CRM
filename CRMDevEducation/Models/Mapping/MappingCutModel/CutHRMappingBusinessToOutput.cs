using business.Models.CutModel;
using CRMDevEducation.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping.MappingCutModel
{
    public class CutHRMappingBusinessToOutput
    {
        public static CutHROutputModel Map(CutHRBusinessModel model)
        {
            return new CutHROutputModel()
            {
                Id = model.Id,
                FName = model.FName,
                SName = model.SName,
            };
        }
    }
}
