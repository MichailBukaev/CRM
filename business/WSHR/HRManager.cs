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
            hR = new HR();
            _cache = new HRCache();
            storage = new StabStorage(this);
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


    }
}
