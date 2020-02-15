using business.Models;
using CRMDevEducation.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping
{
    public class TeacherMappingInputToBusiness
    {
        public static TeacherBusinessModel Map(InputTeacherModel model)
        {
            return new TeacherBusinessModel()
            {
           
                SName = model.SName,
                FName = model.FName,
                PhoneNumber = model.PhoneNumber,
                Login = model.Login,
                Password = model.Password,
                Head = model.Head
            };
        }
    }
}
