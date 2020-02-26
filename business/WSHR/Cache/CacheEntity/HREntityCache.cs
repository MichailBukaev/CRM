using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSHR.Headhr.Cache
{
    public class HREntityCache
    {
        public List<Teacher> Teachers { get; set; }
        public List<Group> Groups { get; set; }
        public List<HistoryGroup> HistoryGroups { get; set; }
        public List<Lead> Leads { get; set; }
        public List<History> Histories { get; set; }
        public List<SkillsLead> SkillsLeads { get; set; }
        public List<Skills> Skills { get; set; }
        public List<Status> Statuses { get; set; }
        public List<Log> Logs { get; set; }
        public List<Course> Courses { get; set; }
        public List<LinkTeacherCourse> LinkTeacherCourses { get; set; }
        public List<HR> HRs { get; set; }
        public List<TaskWork> TaskWorks { get; set; }
        public List<TasksStatus> TasksStatuses { get; set; }
        public HREntityCache()
        {
            Teachers = new List<Teacher>();
            Groups = new List<Group>();
            HistoryGroups = new List<HistoryGroup>();
            Leads = new List<Lead>();
            Histories = new List<History>();
            SkillsLeads = new List<SkillsLead>();
            Skills = new List<Skills>();
            Statuses = new List<Status>();
            Logs = new List<Log>();
            Courses = new List<Course>();
            LinkTeacherCourses = new List<LinkTeacherCourse>();
            HRs = new List<HR>();
            TaskWorks = new List<TaskWork>();
            TasksStatuses = new List<TasksStatus>();
        }
    }
}
