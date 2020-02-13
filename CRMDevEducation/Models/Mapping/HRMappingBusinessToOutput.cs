using business.Models;
using CRMDevEducation.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping
{
    public class HRMappingBusinessToOutput
    {
        public static OutputHRModel Map(HRBusinessModel model)
        {
            return new OutputHRModel()
            {
                Id = model.Id,
                FName = model.FName,
                SName = model.SName
            };
        }
    }
}
