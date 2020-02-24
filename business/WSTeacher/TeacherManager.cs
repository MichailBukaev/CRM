using business.Models;
using business.WSUser;
using business.WSUser.interfaces;
using data.Storage;
using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSTeacher
{
    public abstract class TeacherManager : IUserManager
    {
        protected IStorage _storage;
        protected TeacherManagerCache _cache;
        protected Teacher _teacher;
        public TeacherManagerCache Cache { get { return _cache; } }
        public Teacher Teacher { get { return _teacher; } }
        public abstract List<GroupBusinessModel> GetAllGroupe();
        public abstract List<CourseBusinessModel> GetAllCourse();
        public abstract bool SetAttendence(DayInLogBusinessModel dayLog);
        public abstract bool AddSkillsForLead(int skillId, int LeadId);
        public abstract bool SetSelfTask(string task, DateTime deadLine, int tasksStatusId);
    }
}
