using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.Storage
{
    public class ReaderGroup : IReader
    {
        public IEnumerable<IEntity> Read(string TKey, string TValue, IEnumerable<IEntity> entities)
        {
            List<Group> primariGroups = (List<Group>)entities;
            List<Group> groups;
            if (Group.Fields.Id.ToString() == TKey) { groups = primariGroups.Where(p => p.Id == Convert.ToInt32(TValue)).ToList(); }
            else if (Group.Fields.NameGroup.ToString() == TKey) { groups = primariGroups.Where(p => p.NameGroup == TValue).ToList(); }
            else if (Group.Fields.CourseId.ToString() == TKey) { groups = primariGroups.Where(p => p.CourseId == Convert.ToInt32(TValue)).ToList(); }
            else if (Group.Fields.StartDate.ToString() == TKey) { groups = primariGroups.Where(p => p.StartDate == TValue).ToList(); }
            else if (Group.Fields.TeacherId.ToString() == TKey) { groups = primariGroups.Where(p => p.TeacherId == Convert.ToInt32(TValue)).ToList(); }
            else if (Group.Fields.Log.ToString() == TKey) { groups = primariGroups.Where(p => p.Log == TValue).ToList(); }

            else { groups = primariGroups; }
            return groups;
        }
        
    }
}
