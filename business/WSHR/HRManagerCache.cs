using business.Cache;
using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSHR
{
    public class HRManagerCache
    {
        public List<CacheLeadsCombineByStatus> Leads { get; set; }
        public CacheCourse Courses { get; set; } 
        public CacheGroup Groups { get; set; }
        public CacheHRs HRs { get; set; }
        public CacheSkills Skills { get; set; }
        public CacheStatus Statuses { get; set; }
        public CacheTeachers Teachers { get; set; }
        public CacheTaskWorkMyself TaskWorkMyself { get; set; }
        public List<CacheTaskWorkForSlavesCombineByExecuter> TaskWorkForSlavesCombineByExecuters { get; set; }
        public CacheTasksStatus TasksStatus { get; set; }

        public HRManagerCache(HR _hr)

        {
            Statuses = new CacheStatus();
            Leads = new List<CacheLeadsCombineByStatus>();
            Courses = new CacheCourse();
            Groups = new CacheGroup();
            HRs = new CacheHRs();
            Skills = new CacheSkills();            
            Teachers = new CacheTeachers();
            TaskWorkMyself = new CacheTaskWorkMyself(_hr.Login);
            TaskWorkForSlavesCombineByExecuters = new List<CacheTaskWorkForSlavesCombineByExecuter>();
            TasksStatus = new CacheTasksStatus();
        }
    }
}
