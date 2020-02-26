using business.Models;
using CRMDevEducation.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping.MappingCutModel
{
    public static class GroupeMappingBusinessToCutOutput
    {
        public static CutGroupOutputModel Map(GroupBusinessModel model)
        {
            return new CutGroupOutputModel()
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
