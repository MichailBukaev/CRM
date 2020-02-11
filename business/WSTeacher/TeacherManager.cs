using System;
using System.Collections.Generic;
using System.Text;
using models;

namespace business.WSTeacher
{
    public class TeacherManager
    {
        Teacher _teacher;
        TeacherCache _cache;
        StabStorage storage;

        public TeacherManager(Teacher teacher)
        {
            _teacher = teacher;
            _cache = new TeacherCache();
            storage = new StabStorage(teacher);
            SetCache();
        }

        //метод заполнения
        public void SetCache()
        {
            if (!_cache.FlagActual)
            {
                _cache.Leads = (List<Lead>)storage.GetAll<Lead>();
                _cache.Groups = (List<Group>)storage.GetAll<Group>();
                _cache.Histories = (List<History>)storage.GetAll<History>();
                _cache.HistoryGroups = (List<HistoryGroup>)storage.GetAll<HistoryGroup>();
                _cache.Logs = (List<Log>)storage.GetAll<Log>();
                _cache.Skills = (List<Skills>)storage.GetAll<Skills>();
                _cache.SkillsLeads = (List<SkillsLead>)storage.GetAll<SkillsLead>();
                _cache.Courses = (List<Course>)storage.GetAll<Course>();

                _cache.FlagActual = true;
            }
        }

        public IEnumerable<Lead> GetLeads()
        {
            return _cache.Leads;
        }

        public IEnumerable<Group> GetGroups()
        {
            return _cache.Groups;
        }

        public IEnumerable<History> GetHistory()
        {
            return _cache.Histories;
        }

        public IEnumerable<HistoryGroup> GetHistoryGroups()
        {
            return _cache.HistoryGroups;
        }

        public IEnumerable<Log> GetLog()
        {
            return _cache.Logs;
        }

        public IEnumerable<Skills> GetSkills()
        {
            return _cache.Skills;
        }

        public IEnumerable<SkillsLead> GetSkillsLead()
        {
            return _cache.SkillsLeads;
        }

        public IEnumerable<Course> GetCourses()
        {
            return _cache.Courses;
        }
    }
}
