using business.Models;
using CRMDevEducation.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping
{
    public class LogMappingInputToBusiness
    {
        public static LogBusinessModel Map(InputLogModel model)
        {
            return new LogBusinessModel()
            {
                Date = model.Date,
                LeadsVisit = model.LeadsVisit,               
            };
        }
    }
}
