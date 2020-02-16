using business.Models;
using CRMDevEducation.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping
{
    public class UpdateGroupeTeacherMappingInputToBusiness
    {
        public static UpdateGroupeTecherModelBusinessModel Map(InputUpdateGroupeTecherModel model) 
        {
            return new UpdateGroupeTecherModelBusinessModel()
            {
                TeaherId = model.TeaherId,
                GroupId = model.GroupId
            };
        }
    }
}
