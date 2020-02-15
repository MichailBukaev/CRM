using business.Models;
using CRMDevEducation.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping
{
    public class LogMappingBusinessToOutput
    {
        public static OutputLogModel Map(LogBusinessModel model)
        {
            return new OutputLogModel()
            {
                GroupId = model.GroupId,
                GroupName = model.GroupName,
                Days = DayInLogMappingBusinessToOutput.Map(model.Days)
            };          
        }
    }
}
