using business.Models;
using data.Storage;
using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSTeacher
{
    public abstract class TeacherManager
    {
        protected IStorage _storage;
        protected TeacherCache _cache;
        protected Teacher _teacher;
        public abstract List<GroupBusinessModel> GetAllGroupe();
        protected abstract void SetCache();
        public abstract void SetAttendence(DayInLogBusinessModel dayLog);
        public abstract void AddSkillsForLead(SkillsForLeadBusinessModel model);
    }
}
