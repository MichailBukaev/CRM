using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSHR
{
    class HRCache
    {
        public List<Lead> Leads { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Group> Groups { get; set; }
        public List<Course> Courses { get; set; }
        public List<Skills> Skills { get; set; }
        public List<History> Historys { get; set; }
        public List<HistoryGroup> HistoryGroups { get; set; }
        public List<Status> Statuses { get; set; }
        public List<SkillsLead> SkillsLeads { get; set; }
        
        public bool FlagActual { get; set; }

        public HRCache()
        {
            FlagActual = false;
            PublisherChangesInBD publisher = PublisherChangesInBD.GetPublisher();
            publisher.Event += this.ReadChange;
        }

        public void ReadChange(IEntity entity)
        {
            FlagActual = false;
        }



    }
}
