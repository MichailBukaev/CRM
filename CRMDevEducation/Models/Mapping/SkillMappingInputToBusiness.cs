using business.Models;
using CRMDevEducation.Models.Input;
using CRMDevEducation.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping
{
    public class SkillMappingInputToBusiness
    {
        public static SkillBusinessModel Map(InputSkillModel model)
        {
            return new SkillBusinessModel()
            {
                IdSkill = model.IdSkill,
                NameSkill = model.NameSkill
            };
        }
    }
}
