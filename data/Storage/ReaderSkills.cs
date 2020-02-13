using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.Storage
{
    public class ReaderSkills : IReader
    {
        public IEnumerable<IEntity> Read(string TKey, string TValue, IEnumerable<IEntity> entities)
        {
            List<Skills> primariSkills = (List<Skills>)entities;
            List<Skills> skills;
            if (Skills.Fields.Id.ToString() == TKey) { skills = primariSkills.Where(p => p.Id == Convert.ToInt32(TValue)).ToList(); }
            else if (Skills.Fields.NameSkills.ToString() == TKey) { skills = primariSkills.Where(p => p.NameSkills == TValue).ToList(); }
            
            else { skills = primariSkills; }
            return skills;
        }

    }
}
