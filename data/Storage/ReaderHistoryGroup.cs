using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.Storage
{
    public class ReaderHistoryGroup : IReader
    {
        public IEnumerable<IEntity> Read(string TKey, string TValue, IEnumerable<IEntity> entities)
        {
            List<HistoryGroup> primariStoryGroups = (List<HistoryGroup>)entities;
            List<HistoryGroup> storyGroups;
            if (HistoryGroup.Fields.GroupId.ToString() == TKey) { storyGroups = primariStoryGroups.Where(p => p.GroupId == Convert.ToInt32(TValue)).ToList(); }
            else if (HistoryGroup.Fields.HistoryText.ToString() == TKey) { storyGroups = primariStoryGroups.Where(p => p.HistoryText == TValue).ToList(); }

            else { storyGroups = primariStoryGroups; }
            return storyGroups;
        }

    }
}
