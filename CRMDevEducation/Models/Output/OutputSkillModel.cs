using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMDevEducation.Models.Output
{
    public class OutputSkillModel: IModelOutput
    {
        public int IdSkill { get; set; }
        public string NameSkill { get; set; }
    }
}
