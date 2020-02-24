using business.Cache;
using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSTeacher
{
    public class TeacherManagerCache
    {
        public CacheTeachers Teachers { get; set; }
        public List<CacheLeadsCombineByGroup> Leads { get; set; }
        public CacheGroup Group { get; set; }
        public CacheCourse Course { get; set; }
        public CacheSkills Skills { get; set; }
        public CacheStatus Status { get; set; }
        public CacheTaskWorkMyself TaskWorkMyself { get; set; }
        public List<CacheTaskWorkForSlavesCombineByExecuter> TaskWorkForSlavesCombineByExecuters { get; set; }
        public CacheTasksStatus TasksStatus { get; set; }

        public TeacherManagerCache(Teacher _teacher)
        {
            Teachers = new CacheTeachers();
            Leads = new List<CacheLeadsCombineByGroup>();
            Group = new CacheGroup();
            Course = new CacheCourse();
            Skills = new CacheSkills();
            Status = new CacheStatus();
            TasksStatus = new CacheTasksStatus();
            TaskWorkMyself = new CacheTaskWorkMyself(_teacher.Login);
            TaskWorkForSlavesCombineByExecuters = new List<CacheTaskWorkForSlavesCombineByExecuter>();
        }
    }
}
