using business.Models;
using CRMDevEducation.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping
{
    public class HRMappingInputToBusiness
    {
        public static HRBusinessModel Map(InputHRModel model)
        {
            return new HRBusinessModel()
            {
           
                SName = model.SName,
                FName = model.FName,
                Login = model.Login,
                Password = model.Password,
                Head = model.Head
            };
        }

        
    }
}
