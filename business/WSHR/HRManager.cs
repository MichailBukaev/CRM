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
        public IEnumerable<IEntity> GetSkillsLeads(string TKey, string TValue)
        {
            return _cache.SkillsLeads;
        }

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

            return storage.Add(lead);
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
            return storage.Add(group);
        }
        public bool CreateCourse(Dictionary<string, string> _models)
        {
            Course course = new Course()
            {
                Id = Convert.ToInt32(_models["Id"]),
                Name = _models["Name"],      
                CourseInfo = _models["CourseInfo"]
            };
            return storage.Add(course);
        }
        public bool CreateHistory(Dictionary<string, string> _models)
        {
            History history = new History()
            {
                LeadId = Convert.ToInt32(_models["Id"]),
                HistoryText = _models["HistoryText"]
            };
            return storage.Add(history);
        }

        public bool CreateHistoryGroup(Dictionary<string, string> _models)
        {
            HistoryGroup historygroup = new HistoryGroup()
            {
                GroupId = Convert.ToInt32(_models["Id"]),
                HistoryText = _models["HistoryText"]
            };
            return storage.Add(historygroup);
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
            return storage.Add(hr);
        }

        public bool UpdateLead(int id, Dictionary<string, string> _model)
        {

        }

    }
}
