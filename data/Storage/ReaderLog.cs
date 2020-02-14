using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.Storage
{
    public class ReaderLog : IReader
    {
        public IEnumerable<IEntity> Read(string TKey, string TValue, IEnumerable<IEntity> entities)
        {
            List<Log> primariLogs = (List<Log>)entities;
            List<Log> logs;
            if (Log.Fields.LeadId.ToString() == TKey) { logs = primariLogs.Where(p => p.LeadId == Convert.ToInt32(TValue)).ToList(); }
            else if (Log.Fields.Date.ToString() == TKey) { logs = primariLogs.Where(p => p.Date == DateTime.Parse(TValue)).ToList(); }
            else if (Log.Fields.Visit.ToString() == TKey) { logs = primariLogs.Where(p => p.Visit == Convert.ToBoolean(TValue)).ToList(); }
            else { logs = primariLogs; }
            return logs;
        }
    }
}
