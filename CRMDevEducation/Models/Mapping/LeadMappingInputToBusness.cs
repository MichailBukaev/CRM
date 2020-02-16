using business.Models;
using CRMDevEducation.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping
{
    public class LeadMappingInputToBusness 
    {
        public static LeadBusinessModel Map(InputLeadModel model)
        {
            return new LeadBusinessModel()
            {
                FName = model.FName,
                SName = model.SName,
                Numder = model.Numder,
                DateBirthday = model.DateBirthday,
                EMail = model.EMail,
                Status = model.Status,
                Login = model.Login,
                Password = model.Password
            };
        }
    }
}
