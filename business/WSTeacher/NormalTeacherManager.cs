﻿using business.Cache;
using business.Models;
using business.WSTeacher.Cache;
using business.WSTeacher.Cache.CacheEntity;
using business.WSUser.interfaces;
using data.StorageEntity;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace business.WSTeacher
{
    public class NormalTeacherManager : TeacherManager
    {
        HistoryWriter historyWriter;

        public NormalTeacherManager(int teacherId)
        {
            _storage = new StorageTeacher();
            List<Teacher> teachers = (List<Teacher>)_storage.GetAll();
            _teacher = teachers.FirstOrDefault(p => p.Id == teacherId);
            _cache = new TeacherManagerCache(_teacher);
            historyWriter = new HistoryWriter();
            SetCache();
        }

        public override bool AddSkillsForLead(int skillId, int LeadId)
        {
            bool ok = false;

            LeadBusinessModel lead = null;
            GroupBusinessModel group = null;
            for(int i = 0; i<_cache.Leads.Count; i++)
            {
                if (!_cache.Leads[i].FlagActual)
                    ReconstructorTeacherManagerCache.UpdateCacheLeads(_cache.Leads[i]);
                lead = _cache.Leads[i].Leads.FirstOrDefault(p => p.Id == LeadId);
                if (lead != null)
                {
                    if(!_cache.Group.FlagActual)
                        ReconstructorTeacherManagerCache.UpdateCacheGroup(_cache.Group, _teacher);
                    group = _cache.Group.Groups.FirstOrDefault(p => p.Id == _cache.Leads[i].GroupId);
                    break;
                }
            }
            SkillBusinessModel skill = _cache.Skills.Skills.FirstOrDefault(p => p.IdSkill == skillId);
            if (lead != null && skill != null)
            {
                PublishingHouse publishingHouse = PublishingHouse.Create();
                PublisherChangesInDB publisher = publishingHouse.CombineByGroup[group.Id];
                _storage = new StorageSkillsLead();
                SkillsLead skillsLead = new SkillsLead() { 
                    LeadId = lead.Id,
                    SkillsId = skill.IdSkill
                };
                IEntity entity = skillsLead;
                _storage = new StorageSkillsLead();
                historyWriter.AddSkills(LeadId, skill.NameSkill);
                ok = _storage.Add(ref entity);
                publisher.Notify();
            }
            return ok;
        }

        public override List<CourseBusinessModel> GetAllCourse()
        {
            if (!_cache.Course.FlagActual)
                ReconstructorTeacherManagerCache.UpdateCacheCourses(_cache.Course, _teacher);
            List<CourseBusinessModel> courses = _cache.Course.Courses;
            return courses;
        }

        public override List<GroupBusinessModel> GetAllGroupe()
        {
            if (!_cache.Group.FlagActual)
                ReconstructorTeacherManagerCache.UpdateCacheGroup(_cache.Group, _teacher);
            List<GroupBusinessModel> groups = _cache.Group.Groups;
            return groups;
        }

        public override IModelsBusiness GetLead(int id)
        {
            LeadBusinessModel leadBusinesses = null;
            foreach (CacheLeadsCombineByGroup item in _cache.Leads)
            {
                leadBusinesses = item.Leads.FirstOrDefault(x => x.Id == id);
                if (leadBusinesses != null)
                    return leadBusinesses;
            }
            return leadBusinesses;
        }

        public override List<TaskWorkBusinessModel> GetMyselfTask()
        {
            return _cache.TaskWorkMyself.TasksWork;
        }

        public override IModelsBusiness GetTacher(int teacherId)
        {
            if (!_cache.Teachers.FlagActual)
                ReconstructorTeacherManagerCache.UpdateCacheTeachers(_cache.Teachers, _teacher);
            return _cache.Teachers.Teachers.FirstOrDefault(p => p.Id == teacherId);
        }

        public override bool SetAttendence(DayInLogBusinessModel dayLog)
        {
            PublishingHouse publishingHouse = PublishingHouse.Create();
            PublisherChangesInDB publisher = publishingHouse.Group;
            _storage = new StorageLog();
            bool ok = true;
            for (int i = 0; i < dayLog.StudentsInLog.Count; i++)
            {
                IEntity log = new Log()
                {
                    Date = dayLog.Date,
                    LeadId = dayLog.StudentsInLog[i].Lead.Id
                };
                if (!_storage.Add(ref log))
                    ok = false;
                else
                    publisher.Notify();
            }
            return ok;
        }

        public override bool SetSelfTask(string task, DateTime deadLine, int tasksStatusId)
        {
            PublishingHouse publishingHouse = PublishingHouse.Create();
            publishingHouse.CombineByExecuter[_teacher.Login].Notify(_teacher.Login);
            return true;
        }

        private void SetCache()
        {
            TeacherEntityCache entityCache = new FillEntityCache(_teacher).Fill();
            _cache = new FillTeacherManagerCache(entityCache, _teacher).Fill();
        }

      
    }
}
