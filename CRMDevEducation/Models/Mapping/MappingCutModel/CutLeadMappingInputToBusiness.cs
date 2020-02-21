using business.Models.CutModel;
using CRMDevEducation.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping.MappingCutModel
{
    public class CutLeadMappingInputToBusiness
    {
        public static CutLeadBusinessModel Map(CutLeadInputModel model)
        {
            return new CutLeadBusinessModel()
            {
                Id = model.Id,
                FName = model.FName,
                SName = model.SName,
            };
        }
    }
}
