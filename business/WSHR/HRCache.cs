using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSHR
{
    class HRCache
    {
        List<Teacher> Teachers { get; set; }
        List<Lead> Leads { get; set; }
        List<Group> Groups { get; set; }
        List<Course> Courses { get; set; }
        List<Skills> Skills { get; set; }
        List<History> Historys { get; set; }
        List<HistoryGroup> HistoryGroups { get; set; }
        List<Status> Statuses { get; set; }
        List<SkillsLead> SkillsLeads { get; set; }
        
        public bool FlagActual { get; set; }

        public HRCache()
        {
            FlagActual = true;
            PublisherChangesInBD publisher = PublisherChangesInBD.GetPublisher();
            publisher.Event += this.ReadChange;
        }

        public void ReadChange(IEntity entity)
        {
            FlagActual = false;
        }



    }
}
