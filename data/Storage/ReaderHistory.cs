using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.Storage
{
    public class ReaderHistory : IReader
    {
        public IEnumerable<IEntity> Read(string TKey, string TValue, Read crudCommand)
        {
            List<History> primariStories = (List<History>)crudCommand.Execute<History>();
            List<History> stories;
            if (History.Fields.LeadId.ToString() == TKey) { stories = primariStories.Where(p => p.LeadId == Convert.ToInt32(TValue)).ToList(); }
            else if (History.Fields.HistoryText.ToString() == TKey) { stories = primariStories.Where(p => p.HistoryText == TValue).ToList(); }
            
            else { stories = primariStories; }
            return stories;
        }

    }
}
