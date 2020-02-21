using business.Models.CutModel;
using CRMDevEducation.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping.MappingCutModel
{
    public class CutGroupMappingInputToBusiness
    {
        public static CutGroupBusinessModel Map(CutGroupInputModel model)
        {
            return new CutGroupBusinessModel()
            {
                Id = model.Id,
                Name = model.Name,
            };
        }
    }
}
