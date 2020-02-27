using business.Models;
using CRMDevEducation.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping
{
    public static class StatusMappingBusinessToOutput
    {
        public static OutputStatusModel Map(StatusBusinessModel model)
        {
            return new OutputStatusModel() { Id=model.Id, Name = model.Name };

        }
    }
}
