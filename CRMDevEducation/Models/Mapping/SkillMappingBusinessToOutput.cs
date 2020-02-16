using business.Models;
using CRMDevEducation.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Mapping
{
    public class SkillMappingBusinessToOutput
    {
        public static OutputSkillModel Map(SkillBusinessModel model)
        {
            return new OutputSkillModel()
            {
                IdSkill = model.IdSkill,
                NameSkill = model.NameSkill
            };
        }

    }
}

