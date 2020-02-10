using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.Storage
{
    public class ReaderLead : IReader
    {
        public IEnumerable<IEntity> Read(string TKey, string TValue, Read crudCommand)
        {
            List<Lead> primariLeads = (List<Lead>)crudCommand.Execute<Lead>();
            List<Lead> leads;
            if (Lead.Fields.Id.ToString() == TKey){ leads = primariLeads.Where(p => p.Id == Convert.ToInt32(TValue)).ToList();}
            else if(Lead.Fields.FName.ToString() == TKey) { leads = primariLeads.Where(p => p.FName ==TValue).ToList(); }
            else if (Lead.Fields.SName.ToString() == TKey) { leads = primariLeads.Where(p => p.SName == TValue).ToList(); }
            else if (Lead.Fields.DateBirthday.ToString() == TKey) { leads = primariLeads.Where(p => p.DateBirthday == TValue).ToList(); }
            else if (Lead.Fields.DateRegistration.ToString() == TKey) { leads = primariLeads.Where(p => p.DateRegistration == TValue).ToList(); }
            else if (Lead.Fields.Numder.ToString() == TKey) { leads = primariLeads.Where(p => p.Numder == Convert.ToInt32(TValue)).ToList(); }
            else if (Lead.Fields.EMail.ToString() == TKey) { leads = primariLeads.Where(p => p.EMail == TValue).ToList(); }
            else if (Lead.Fields.AccessStatus.ToString() == TKey) { leads = primariLeads.Where(p => p.AccessStatus == Convert.ToBoolean(TValue)).ToList(); }
            else if (Lead.Fields.GroupId.ToString() == TKey) { leads = primariLeads.Where(p => p.GroupId == Convert.ToInt32(TValue)).ToList(); }
            else if (Lead.Fields.StatusId.ToString() == TKey) { leads = primariLeads.Where(p => p.StatusId == Convert.ToInt32(TValue)).ToList(); }
            else if (Lead.Fields.CourseId.ToString() == TKey) { leads = primariLeads.Where(p => p.CourseId == Convert.ToInt32(TValue)).ToList(); }
            else { leads = primariLeads; }
            return leads;
        }
    }
}
