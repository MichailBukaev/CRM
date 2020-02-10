using models;
using System.Collections.Generic;

namespace business.WSTeacher
{
    public class TeacherCache
    {
        public List<Lead> Leads { get; set; }
        public List<Group> Groups { get; set; }
        public List<Course> Courses { get; set; }
        public List<HistoryGroup> HistoryGroups { get; set; }
        public List<History> Histories { get; set; }
        public List<Skills> Skills { get; set; }
        public List<SkillsLead> SkillsLeads { get; set; }
        public List<Log> Logs { get; set; }
        public bool FlagActual { get; set; }

        public TeacherCache()
        {
            FlagActual = false;

        }

        public void ReadChange(IEntity entity)
        {
            FlagActual = false;

        }

    }
}