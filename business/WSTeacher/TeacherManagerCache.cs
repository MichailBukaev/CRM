using business.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSTeacher
{
    public class TeacherManagerCache
    {
        public CacheTeachers Teachers { get; set; }
        public List <CacheLeadsCombineByGroup> Leads { get; set; }
        public CacheGroup Group { get; set; }
        public CacheCourse Course { get; set; }
        public CacheSkills Skills { get; set; }
        public CacheStatus Status { get; set; }
        
    }
}
