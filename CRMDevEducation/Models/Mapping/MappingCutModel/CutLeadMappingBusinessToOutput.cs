using business.Models.CutModel;
using CRMDevEducation.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping.MappingCutModel
{
    public class CutLeadMappingBusinessToOutput
    {
        public static CutLeadOutputModel Map(CutLeadBusinessModel model)
        {
            return new CutLeadOutputModel()
            {
                Id = model.Id,
                FName = model.FName,
                SName = model.SName,
            };
        }
    }
}
