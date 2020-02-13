using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.Storage
{
    public class ReaderSkillsLead : IReader
    {
        public IEnumerable<IEntity> Read(string TKey, string TValue, IEnumerable<IEntity> entities)
        {
            List<SkillsLead> primariSkillsLead = (List<SkillsLead>)entities;
            List<SkillsLead> skillsLead;
            if (SkillsLead.Fields.LeadId.ToString() == TKey) { skillsLead = primariSkillsLead.Where(p => p.LeadId == Convert.ToInt32(TValue)).ToList(); }
            else if (SkillsLead.Fields.SkillsId.ToString() == TKey) { skillsLead = primariSkillsLead.Where(p => p.SkillsId == Convert.ToInt32(TValue)).ToList(); }

            else { skillsLead = primariSkillsLead; }
            return skillsLead;

        }
    }




}
