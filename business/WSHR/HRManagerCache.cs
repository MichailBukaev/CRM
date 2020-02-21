using business.Cache;
using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSHR
{
    class HRManagerCache
    {
        public List<CacheLeadsCombineByStatus> Leads { get; set; }
        public CacheCourse Courses { get; set; } 
        public CacheGroup Groups { get; set; }
        public CacheHRs HRs { get; set; }
        public CacheSkills Skills { get; set; }
        public CacheStatus Statuses { get; set; }
        public CacheTeachers Teachers { get; set; }
    }
}
