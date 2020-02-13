using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.Storage
{
    public class ReaderHR : IReader
    {
        public IEnumerable<IEntity> Read(string TKey, string TValue, IEnumerable<IEntity> entities)
        {
            List<HR> primariHRs = (List<HR>) entities;
            List<HR> HRs;
            if (HR.Fields.Id.ToString() == TKey) { HRs = primariHRs.Where(p => p.Id == Convert.ToInt32(TValue)).ToList(); }
            else if (HR.Fields.FName.ToString() == TKey) { HRs = primariHRs.Where(p => p.FName == TValue).ToList(); }
            else if (HR.Fields.SName.ToString() == TKey) { HRs = primariHRs.Where(p => p.SName == TValue).ToList(); }
            else if (HR.Fields.Login.ToString() == TKey) { HRs = primariHRs.Where(p => p.Login == TValue).ToList(); }
            else if (HR.Fields.Password.ToString() == TKey) { HRs = primariHRs.Where(p => p.Password == TValue).ToList(); }
            
            else { HRs = primariHRs; }
            return HRs;
        }      
    }
}
