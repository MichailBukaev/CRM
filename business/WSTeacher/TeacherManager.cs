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

        #region GetAll
        public IEnumerable<IEntity> GetLeads(string Tkey, string TValue)
        {
            return storage.GetAll<Lead>(Tkey, TValue);
            
        }

        public IEnumerable<IEntity> GetGroups(string Tkey, string TValue)
        {
            return _cache.Groups;
        }

        public IEnumerable<IEntity> GetHistory(string Tkey, string TValue)
        {
            return _cache.Histories;
        }

        public IEnumerable<IEntity> GetHistoryGroups(string Tkey, string TValue)
        {
            return _cache.HistoryGroups;
        }

        public IEnumerable<IEntity> GetLog(string Tkey, string TValue)
        {
            return _cache.Logs;
        }

        public IEnumerable<IEntity> GetSkills(string Tkey, string TValue)
        {
            return _cache.Skills;
        }

        public IEnumerable<IEntity> GetSkillsLead(string Tkey, string TValue)
        {
            return _cache.SkillsLeads;
        }

        public IEnumerable<IEntity> GetCourses(string Tkey, string TValue)
        {
            return _cache.Courses;
        }

        #endregion

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
            foreach(SkillsLead item in _cache.SkillsLeads)
            {
                if (Convert.ToInt32(_models["LeadId"]) == item.LeadId &&
                   Convert.ToInt32(_models["SkillsId"]) == item.SkillsId)
                    return false;
            }
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

       /* public bool CreateTeacher(Dictionary<string, string> _models)
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
        }*/
        #endregion

        #region Update
        public bool UpdateLead(int id, Dictionary<string, string> _models)
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

            bool okey = storage.Update(lead);
            if (okey)
                _publisher.Notify(lead);
            return okey;
        }

        public bool UpdateGroup(Dictionary<string, string> _models)
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
            bool okey = storage.Update(group);
            if (okey)
                _publisher.Notify(group);
            return okey;
        }
        public bool UpdateCourse(Dictionary<string, string> _models)
        {
            Course course = new Course()
            {
                Id = Convert.ToInt32(_models["Id"]),
                Name = _models["Name"],
                CourseInfo = _models["CourseInfo"]
            };
            bool okey = storage.Update(course);
            if (okey)
                _publisher.Notify(course);
            return okey;
        }
        public bool UpdateHistory(Dictionary<string, string> _models)
        {
            History history = new History()
            {
                LeadId = Convert.ToInt32(_models["Id"]),
                HistoryText = _models["HistoryText"]
            };
            bool okey = storage.Update(history);
            if (okey)
                _publisher.Notify(history);
            return okey;
        }

        public bool UpdateHistoryGroup(Dictionary<string, string> _models)
        {
            HistoryGroup historygroup = new HistoryGroup()
            {
                GroupId = Convert.ToInt32(_models["Id"]),
                HistoryText = _models["HistoryText"]
            };
            bool okey = storage.Update(historygroup);
            if (okey)
                _publisher.Notify(historygroup);
            return okey;
        }

        #endregion

        #region Delete
        public bool DeleteLead(int id)
        {
            Lead _obj = null;
            foreach (Lead item in _cache.Leads)
            { 
                if(item.Id == id)
                {
                    _obj = item;
                    break;
                }
            }
            if(_obj != null )
            {
                bool okey = storage.Delete(_obj);
                if (okey)
                    _publisher.Notify(_obj);
                return okey;
            }
            return false;
        }

        public bool DeleteGroup(int id)
        {
            Group _obj = null;
            foreach (Group item in _cache.Groups)
            {
                if (item.Id == id)
                {
                    _obj = item;
                    break;
                }
            }
            if (_obj != null)
            {
                bool okey = storage.Delete(_obj);
                if (okey)
                    _publisher.Notify(_obj);
                return okey;
            }
            return false;
        }

        public bool DeleteLog(DateTime dateTime, int leadId) /////
        { 
            bool okey = false;
            foreach (Log item in _cache.Logs)
            {
                if (item.Date == dateTime && item.LeadId == leadId)
                {
                    okey = storage.Delete(item);
                    if (okey)
                        _publisher.Notify(item);
                    else
                        return okey;

                }
                
            }
            return okey;
        }

        public bool DeleteCourse(int id)
        {
            Course _obj = null;
            foreach (Course item in _cache.Courses)
            {
                if (item.Id == id)
                {
                    _obj = item;
                    break;
                }
            }
            if (_obj != null)
            {
                bool okey = storage.Delete(_obj);
                if (okey)
                    _publisher.Notify(_obj);
                return okey;
            }
            return false;
        }

        public bool DeleteHistory(int idLead, string historyText)
        { 
            bool okey = false;
            foreach (History item in _cache.Histories)
            {
                if (item.LeadId == idLead && item.HistoryText == historyText)
                {
                    okey = storage.Delete(item);
                    if (okey)
                        _publisher.Notify(item);
                    else
                        return okey;

                }

            }
            return okey;
        }
        public bool DeleteHistoryGroup(int idGroup, string historyText) /////
        {
            bool okey = false;
            foreach (HistoryGroup item in _cache.HistoryGroups)
            {
                if (item.GroupId == idGroup && item.HistoryText == historyText)
                {
                    okey = storage.Delete(item);
                    if (okey)
                        _publisher.Notify(item);
                    else
                        return okey;

                }

            }
            return okey;
        }

        public bool DeleteSkill(int id)
        {
            Skills _obj = null;
            foreach (Skills item in _cache.Skills)
            {
                if (item.Id == id)
                {
                    _obj = item;
                    break;
                }
            }
            if (_obj != null)
            {
                bool okey = storage.Delete(_obj);
                if (okey)
                    _publisher.Notify(_obj);
                return okey;
            }
            return false;
        }

        public bool DeleteSkillsLead(int idLead, int idSkill)
        {
            SkillsLead _obj = null;
            foreach (SkillsLead item in _cache.SkillsLeads)
            {
                if (item.LeadId == idLead && item.SkillsId == idSkill)
                {
                    _obj = item;
                    break;
                }
            }
            if (_obj != null)
            {
                bool okey = storage.Delete(_obj);
                if (okey)
                    _publisher.Notify(_obj);
                return okey;
            }
            return false;
        }



        #endregion
    }
}
