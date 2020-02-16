using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using business.Models;
using CRMDevEducation.Models.Input;

namespace CRMDevEducation.Models.Mapping
{
    public class SkillsForLeadMappingInputToBusiness
    {
        public static SkillsForLeadBusinessModel Map(InputSkillsForLeadModel model)
        {

            return new SkillsForLeadBusinessModel()
            {
                IdLead = model.LeadId,
                IdSkills = model.SkillsId
            };
        }
    }
}
