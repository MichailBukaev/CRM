using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.WSHR
{
    public class HRManager
    {
        HR hR;
        HRCache _cache;
        StabStorage storage;
        PublisherChangesInBD _publisher;
        public HRManager(HR hR)
        {
            this.hR = hR;
            _cache = new HRCache();
            storage = new StabStorage(hR);
            _publisher = PublisherChangesInBD.GetPublisher();
            SetCache();
        }

        //метод заполнения cache
        public void SetCache()
        {
            if (_cache.FlagActual == false)
            {
                _cache.Leads = (List<Lead>)storage.GetAll<Lead>();
                _cache.Groups = (List<Group>)storage.GetAll<Group>();
                _cache.Historys = (List<History>)storage.GetAll<History>();
                _cache.HistoryGroups = (List<HistoryGroup>)storage.GetAll<HistoryGroup>();
                _cache.Skills = (List<Skills>)storage.GetAll<Skills>();
                _cache.SkillsLeads = (List<SkillsLead>)storage.GetAll<SkillsLead>();
                _cache.Teachers = (List<Teacher>)storage.GetAll<Teacher>();
                _cache.Statuses = (List<Status>)storage.GetAll<Status>();
                _cache.Courses = (List<Course>)storage.GetAll<Course>();
                _cache.FlagActual = true;
            }
        }

        public IEnumerable<IEntity> GetLeads()
        {
            return _cache.Leads;
        }
        public IEnumerable<IEntity> GetGroup()
        {
            return _cache.Groups;
        }
        public IEnumerable<IEntity> GetCourse()
        {
            return _cache.Courses;
        }
        public IEnumerable<IEntity> GetStatus()
        {
            return _cache.Statuses;
        }
        public IEnumerable<IEntity> GetTeachers()
        {
            return _cache.Leads;
        }
        public IEnumerable<IEntity> GetHistorys()
        {
            return _cache.Historys;
        }
        public IEnumerable<IEntity> GetHistoryGroups()
        {
            return _cache.HistoryGroups;
        }
        public IEnumerable<IEntity> GetSkillsLeads()
        {
            return _cache.SkillsLeads;
        }
        public IEnumerable<IEntity> GetLeads(string TKey, string TValue)
        {
            List<Lead> leads = _cache.Leads;
            foreach (var item in leads)
            {
                
            }
            return storage.GetAll<Lead>(TKey, TValue);
        }
        #region Create
        public bool CreateLead(Dictionary<string, string> _models)
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
                DateRegistration = Convert.ToString(DateTime.UtcNow),
                GroupId = Convert.ToInt32(_models["GroupId"]),
                StatusId = Convert.ToInt32(_models["StatusId"]),
                CourseId = Convert.ToInt32(_models["CourseId"])
            };

            bool okey = storage.Add(lead);
            if (okey)
                _publisher.Notify(lead);
            return okey;
        }
        public bool CreateGroup(Dictionary<string, string> _models)
        {
            Group group = new Group()
            {
                Id = Convert.ToInt32(_models["Id"]),
                NameGroup = _models["Name"],
                CourseId = Convert.ToInt32(_models["CourseId"]),
                StartDate = _models["StartDate"],
                TeacherId = Convert.ToInt32(_models["TeacherId"]),
                Log = _models["Log"]
            };
            bool okey = storage.Add(group);
            if (okey)
                _publisher.Notify(group);
            return okey;
        }
        public bool CreateCourse(Dictionary<string, string> _models)
        {
            Course course = new Course()
            {
                Id = Convert.ToInt32(_models["Id"]),
                Name = _models["Name"],      
                CourseInfo = _models["CourseInfo"]
            };
            bool okey = storage.Add(course);
            if (okey)
                _publisher.Notify(course);
            return okey;
        }
        public bool CreateHistory(Dictionary<string, string> _models)
        {
            History history = new History()
            {
                LeadId = Convert.ToInt32(_models["Id"]),
                HistoryText = _models["HistoryText"]
            };
            bool okey = storage.Add(history);
            if (okey)
                _publisher.Notify(history);
            return okey;
        }

        public bool CreateHistoryGroup(Dictionary<string, string> _models)
        {
            HistoryGroup historygroup = new HistoryGroup()
            {
                GroupId = Convert.ToInt32(_models["Id"]),
                HistoryText = _models["HistoryText"]
            };
            bool okey = storage.Add(historygroup);
            if (okey)
                _publisher.Notify(historygroup);
            return okey;
        }
        public bool CreateHR(Dictionary<string, string> _models)
        {
            HR hr = new HR()
            {
                Id = Convert.ToInt32(_models["Id"]),
                FName = _models["FName"],
                SName = _models["SName"],
                Login = _models["Login"],
                Password = _models["Password"]
            };
            bool okey = storage.Add(hr);
            if (okey)
                _publisher.Notify(hr);
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
        public bool UpdateLead(int id, Dictionary<string, string> _model)
        {
         
        }

    }
}
