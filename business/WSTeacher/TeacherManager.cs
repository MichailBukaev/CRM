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
        PublisherChangesInBD _publisher; 

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

        public IEnumerable<Lead> GetLeads(string Tkey, string TValue)
        {
            storage.GetAll<Lead>(Tkey, TValue);
            return _cache.Leads;
        }

        public IEnumerable<Group> GetGroups(string Tkey, string TValue)
        {
            return _cache.Groups;
        }

        public IEnumerable<History> GetHistory(string Tkey, string TValue)
        {
            return _cache.Histories;
        }

        public IEnumerable<HistoryGroup> GetHistoryGroups(string Tkey, string TValue)
        {
            return _cache.HistoryGroups;
        }

        public IEnumerable<Log> GetLog(string Tkey, string TValue)
        {
            return _cache.Logs;
        }

        public IEnumerable<Skills> GetSkills(string Tkey, string TValue)
        {
            return _cache.Skills;
        }

        public IEnumerable<SkillsLead> GetSkillsLead(string Tkey, string TValue)
        {
            return _cache.SkillsLeads;
        }

        public IEnumerable<Course> GetCourses(string Tkey, string TValue)
        {
            return _cache.Courses;
        }

        #region Create
        public bool CreatLead(Dictionary<string, string> _models)
        {
            Lead lead = new Lead()
            {
                Id = Convert.ToInt32(_models["Id"]),
                FName = _models["Name"],
                SName = _models["SName"],
                DateBirthday = _models["DateBirthday"],
                Numder = Convert.ToInt32(_models["Numder"]),
                EMail = _models["EMail"],
                AccessStatus = Convert.ToBoolean(_models["AccessStatus"]),
                DateRegistration = _models["IdDateRegistration"],
                GroupId = Convert.ToInt32(_models["GroupId"]),
                StatusId = Convert.ToInt32(_models["StatusId"]),
                CourseId = Convert.ToInt32(_models["CourseId"])

            };

            bool okey = storage.Add(lead);
            if (okey)
                _publisher.Notify(lead);
            return okey;
        }

        public bool CreateLog(Dictionary<string, string> _models)
        {
            Log log = new Log()
            {
                Date = Convert.ToDateTime(_models["Date"]),
                LeadId = Convert.ToInt32(_models["LeadId"])
            };
            bool okey = storage.Add(log);
            if (okey)
                _publisher.Notify(log);
            return okey;
        }

        public bool CreateSkills(Dictionary<string, string> _models)
        {
            Skills skill = new Skills()
            {
                Id = Convert.ToInt32(_models["Id"]),
                NameSkills = _models["NameSkils"]
            };
            bool okey = storage.Add(skill);
            if (okey)
                _publisher.Notify(skill);
            return okey;
        }

        public bool CreateSkillsLead(Dictionary<string, string> _models)
        {
            SkillsLead skillsLead = new SkillsLead()
            {
                LeadId = Convert.ToInt32(_models["LeadId"]),
                SkillsId = Convert.ToInt32(_models["SkillsId"])
            };
            bool okey = storage.Add(skillsLead);
            if (okey)
                _publisher.Notify(skillsLead);
            return okey;
        }

        public bool CreateStatus(Dictionary<string, string> _models)
        {
            Status status = new Status()
            {
                Id = Convert.ToInt32(_models["Id"]),
                Name = _models["Name"]
            };
            bool okey = storage.Add(status);
            if (okey)
                _publisher.Notify(status);
            return okey;
        }

        public bool CreateTeacher(Dictionary<string, string> _models)
        {
            Teacher teacher = new Teacher()
            {
                Id = Convert.ToInt32(_models["Id"]),
                FName = _models["FName"],
                SName = _models["SName"],
                PhoneNumber = Convert.ToInt32(_models["PhoneNumber"]),
                Login = _models["Login"],
                Password = _models["Pasword"]
            };
            bool okey = storage.Add(teacher);
            if (okey)
                _publisher.Notify(teacher);
            return okey;
        }
        #endregion


    }
}
