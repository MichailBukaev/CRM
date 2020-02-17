﻿using business.Models;
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
        public TeacherCache Cache { get { return _cache; } }
        public Teacher Teacher { get { return _teacher; } }
        public abstract List<GroupBusinessModel> GetAllGroupe();
        protected abstract void SetCache();
        public abstract bool SetAttendence(DayInLogBusinessModel dayLog);
        public abstract bool AddSkillsForLead(SkillsForLeadBusinessModel model);
    }
}
