using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.Storage
{
    public class ReaderStatus : IReader
    {
        public IEnumerable<IEntity> Read(string TKey, string TValue, IEnumerable<IEntity> entities)
        {
            List<Status> primariStatus = (List<Status>)entities;
            List<Status> statuses;
            
            if (Status.Fields.Id.ToString() == TKey) { statuses = primariStatus.Where(p => p.Id == Convert.ToInt32(TValue)).ToList(); }
            else if (Status.Fields.Name.ToString() == TKey) { statuses = primariStatus.Where(p => p.Name == TValue).ToList(); }

            else { statuses = primariStatus; }
            return statuses;
        }

    }
}
