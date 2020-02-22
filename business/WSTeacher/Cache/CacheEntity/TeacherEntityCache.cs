using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSTeacher
{
    public class TeacherEntityCache
    {
        public List<Teacher> Teachers { get; set; }//
        public List<Group> Groups { get; set; }//
        public List<HistoryGroup> HistoryGroups { get; set; }//
        public List<Lead> Leads { get; set; }//
        public List<History> Histories { get; set; }//
        public List<SkillsLead> SkillsLeads { get; set; }//
        public List<Skills> Skills { get; set; }//
        public List<Status> Statuses { get; set; }
        public List<Log> Logs { get; set; }//
        public List<Course> Courses { get; set; }//
        public List<LinkTeacherCourse> LinkTeacherCourses { get; set; }//


    }
}
