using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.Storage
{
    public class ReaderLog : IReader
    {
        public IEnumerable<IEntity> Read(string TKey, string TValue, Read crudCommand)
        {
            List<Log> primariLogs = (List<Log>)crudCommand.Execute<Log>();
            List<Log> logs;
            if (Log.Fields.LeadId.ToString() == TKey) { logs = primariLogs.Where(p => p.LeadId == Convert.ToInt32(TValue)).ToList(); }
            // else if (Log.Fields.Date.ToString() == TKey) { logs = primariLogs.Where(p => p.Date ==TValue).ToList(); } ругается на поле datetime
            else { logs = primariLogs; }
            return logs;
        }
    }
}
